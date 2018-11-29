using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Same as ChasePlayer, but without rotation
public class SnowBatChasePlayer : MonoBehaviour
{

    private Rigidbody2D box;
    private GameObject player;
    public float boxSpeed;
    public int roomSize = 25;
    private bool chase;
    public bool autochase = true;

    void Awake()
    {
        box = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player == null)
            player = GameObject.Find("Player");
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;
        Vector2 boxPos = box.position;
        Vector2 displacement = playerPos - boxPos;
        if (autochase)
        {
            if (displacement.magnitude < roomSize)
            {
                chase = true;
            }
            else
            {
                chase = false;
            }
        }
        if (chase)
        {
            Vector2 dir = Move(displacement);
        }
    }

    Vector2 Move(Vector2 d)
    {
        box.position += (boxSpeed * Time.deltaTime / 10) * d;
        return d.normalized;
    }

    public void StopChasing()
    {
        autochase = false;
        chase = false;
    }

    public void StartChasing()
    {
        autochase = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag ==  "Player")
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(3);
    }
}
