using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public bool forSpawn = false;
    private Rigidbody2D rb;

    public int gems = 1;

    private void Start()
    {
        if (forSpawn == true)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-200, 200), Random.Range(500, 600)), ForceMode2D.Force);
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                player.AddGems(gems);
                Destroy(this.gameObject);
            }
        }
    }
}
