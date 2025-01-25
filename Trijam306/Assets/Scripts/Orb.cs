using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public bool sparked = false;
    public SpriteRenderer spriteRend;
    public GameObject orbLock;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spark")
        {
            sparked = true;
            spriteRend.color = Color.red;
            orbLock.SetActive(false);

        }
    }
}
