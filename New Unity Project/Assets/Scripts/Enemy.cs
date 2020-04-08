using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    [SerializeField] public float range = 10f;
    [SerializeField] public float speed = 10f;
    [SerializeField] public GameObject throwable;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private RaycastHit2D hit;
    void Start()
    {
        hit = Physics2D.Raycast(transform.position,transform.right);
    }

    // Update is called once per frame
    void Update()
    {
       //Functions
       Movement();
    }

    void Movement()
    {
        if(hit.gameObject.CompareTag("Player"))
        {
            //Move towards the player if it sees him
            Vector2.MoveTowards(transform.position, hit.gameobject.transform.position,speed*Time.deltaTime);
        }
    }
}
