using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 
    //Variables
    [SerializeField] private float horizontal;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpHeight = 10f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool isFlipped;
    [SerializeField] public Animator animator;
    [SerializeField] Rigidbody2D rb;

   
    void Start()
    {
        //Getting components automaticly
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator =  gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Functions
        Movement();
        FlipSystem();
    }

     private void OnCollisionEnter2D(Collision2D other) 
    {
        //It is on the ground now
        isGrounded = true;
        
    }
 

    private void Movement() 
    {
        //Horizontal Movement
        horizontal = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new  Vector2(horizontal*speed,rb.velocity.y);
        //Setting animation parameters
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
        animator.SetBool("Jump",isGrounded);
        //Jump only if it is on the ground and someone pressed space
        if(isGrounded&&Input.GetKey(KeyCode.Space))
        {
            //Jump
            Jump();
            //It isnt on the ground any more
            isGrounded = false ;

        }

    }   

    private void Jump()
    {
        //Set the y velocity higher than 0 so it jumps
        rb.velocity = new Vector2(rb.velocity.x,jumpHeight);

    }

    private void Flip()
    {
        transform.Rotate(0f,180f,0f);

    }
    private void FlipSystem()
    {

        if(isFlipped&&horizontal<0||!isFlipped&&horizontal>0)
        {
            Flip();
            isFlipped = !isFlipped;

        }

    }
  
}
