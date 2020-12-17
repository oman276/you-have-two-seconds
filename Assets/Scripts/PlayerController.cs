using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 10f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LevelManager gameLevelManager;
    private Animator animator;
    public ParticleSystem electrocution;

    public float fJumpPressedRemember;
    public float fJumpPressedTime = 0.2f;
    public float fGroundedRemember;
    public float fGroundedTime = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameLevelManager = FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
        electrocution = GetComponentInChildren<ParticleSystem>();
        electrocution.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal");
        if (movement != 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            
            if (movement > 0f)
            {
                transform.localScale = new Vector2(0.1856474f, 0.1856474f);
            }
            else
            {
                transform.localScale = new Vector2(-0.1856474f, 0.1856474f);
            }

        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        fGroundedRemember -= Time.deltaTime;
        if (isGrounded)
        {
            fGroundedRemember = fGroundedTime;
        }


        fJumpPressedRemember -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            fJumpPressedRemember = fJumpPressedTime;
        }

        if (fJumpPressedRemember > 0 && fGroundedRemember > 0)
        {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            FindObjectOfType<AudioController>().Play("PlayerJump");


        }

        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        animator.SetBool("isGrounded", isGrounded);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fall Detector")
        {
            FindObjectOfType<AudioController>().Play("PlayerDies");
            gameLevelManager.Respawn();
        }

        if (other.tag == "Exit Door")
        {
            gameLevelManager.NextLevel();
        }

        if(other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = other.transform;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
       if(other.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = null;
        }
    }

    public void Die()
    {
        FindObjectOfType<AudioController>().Play("PlayerZapped");

        animator.SetBool("isExploded", true);
        electrocution.gameObject.SetActive(true);
        //gameObject.SetActive(false);
        
       
        gameLevelManager.Respawn();
    }

}
