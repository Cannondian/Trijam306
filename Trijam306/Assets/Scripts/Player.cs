using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    private float moveX;
    private float moveY;

    public int swarmCount;
    public GameObject leadSwarm;

    public bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        SwitchActiveControl();

        if (isActive)
        {
            // Simple Movement
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(moveX*moveSpeed, moveY*moveSpeed);
        }
        

        // Flip direction based on horizontal input (TO DO)
        if (moveX != 0)
        {

        }
    }

    void SwitchActiveControl()
    {
        if (swarmCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (isActive)
                {
                    rb.velocity = new Vector2(0,0);
                    isActive = false;
                    leadSwarm.GetComponent<SwarmNode>().isActive = true;
                }
                else
                {
                    isActive = true;
                    leadSwarm.GetComponent<SwarmNode>().isActive = false;
                }
                
            }
        }
    }

    void ShootSwarm()
    {

    }

    public void CollectSwarmNode(GameObject swarmNode)
    {
        swarmCount++;
        leadSwarm = swarmNode;
        swarmNode.GetComponent<SwarmNode>().collected = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Swarm")
        {
            CollectSwarmNode(other.gameObject);
        }
    }



}
