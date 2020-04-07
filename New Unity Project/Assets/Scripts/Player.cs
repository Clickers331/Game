using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 
    //Variables
    [SerializeField] private float horizontal;
    [SerializeField] public float speed = 10f;
    [SerializeField] public float jumpHeight = 10f;
    [SerializeField] private bool isGrounded;
    [SerializeField] Rigidbody2D rb;

   
    void Start()
    {
        //Getting rigidbody from gameobject
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Functions
        Movement();
    }

     private void OnCollisionEnter2D(Collision2D other) 
    {
        //It is on the ground now
        isGrounded = true;
        
    }
 

    private void Movement() 
    {
        //Horizontal Movement
        horizontal = Input.GetAxis("Horizontal"); 
        rb.velocity = new  Vector2(horizontal*speed,rb.velocity.y);
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
  
}
