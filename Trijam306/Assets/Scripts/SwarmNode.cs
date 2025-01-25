using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwarmNode : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject sparkRadius;

    public float moveSpeed = 10;
    private float moveX;
    private float moveY;

    public bool collected = false;
    public bool seperated = false;

    public bool isActive = false;

    private Vector2 target;

    public float randomLow = -2;
    public float randomHigh = 2;
    public float randomVariance = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        randomVariance = Random.Range(randomLow,randomHigh);
        if (isActive)
        {
            // Simple Movement
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(moveX*moveSpeed, moveY*moveSpeed);

            // Spark

        }

        if (!isActive)
        {
            rb.velocity = new Vector2(0,0);
            if (collected)
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isActive)
                {
                    target = GameObject.FindGameObjectWithTag("Player").transform.position;
                }
                else
                {
                    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().leadSwarm.transform.position;
                }
                
                float step = moveSpeed * Time.deltaTime * 2;
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.x+randomVariance,target.y+randomVariance), step);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ActivateSpark());
        }
    }

    public void CollectedStatus()
    {
        collected = true;
    }

    IEnumerator ActivateSpark()
    {

        sparkRadius.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        sparkRadius.SetActive(false);
    }
}
