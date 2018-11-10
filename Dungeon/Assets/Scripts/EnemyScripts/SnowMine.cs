using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Similar to AOEdamage.cs, Explosion.cs, BombEnemy.cs, but with modifications. Consider integrating
public class SnowMine : MonoBehaviour {

    private int damage = 25;
    private bool activate = false;
    private float explosionTimer = 3f;
    GameObject player;
    CircleCollider2D explosionRadius;

    private void Awake()
    {
        explosionRadius = gameObject.GetComponent<CircleCollider2D>();
        explosionRadius.radius = 2.5f;
        explosionTimer = gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update () {
        if (activate)
        {
            explosionTimer -= 1 * Time.deltaTime;
            if (explosionTimer <= 0)
            {
                if ((player != null) && (Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2)) < explosionRadius.radius))
                    player.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
	}

    public float GetRadius()
    {
        return explosionRadius.radius;
    }

    public void SetRadius(float newRadius)
    {
        explosionRadius.radius = newRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && (!activate))
        {
            player = collision.gameObject;
            gameObject.GetComponent<Animator>().enabled = true;
            activate = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
