using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used for the phantom enemy, which bounces off objects and slows the player on contact
public class Phantom : MonoBehaviour {

    private float lifeSpan = 10f;    // Lifespan of 10 seconds

    // Use this for initialization
    void Start() {
        // -1 + 2 * Random.Range(0, 2) is just a way to get either -1 or 1 randomly (no 0)
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 + 2 * Random.Range(0, 2) * Random.Range(2f, 3f), -1 + 2 * Random.Range(0, 2) * Random.Range(2f, 3f));
    }
	
	// Update is called once per frame
	void Update () {
        lifeSpan -= Time.deltaTime;

        // Face direction of movement according to the x-axis
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        if (lifeSpan <= 0)
            Destroy(gameObject);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If hit player, inflict slow for 3 seconds. Also destroy self
        if(collision.gameObject.tag == "Player")
        {
            BuffSlow slow = collision.gameObject.AddComponent<BuffSlow>();
            slow.SetBuffTimer(3f);
            collision.gameObject.GetComponent<BuffHandler>().AddBuff(slow);
            Destroy(gameObject);
        }
    }
}
