using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGrenade : MonoBehaviour {

    float rotate = 30f;
    float speed = 400f;
    float destructionTimer;
    bool explodeState = false;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.GetComponent<Animator>().speed = 0;
	}
	
	// Update is called once per frame
	void Update () {

        // Might be able to integrate BombEnemy into this later
        if (!explodeState)
        {
            destructionTimer -= Time.deltaTime;
            if (destructionTimer <= 0)
                explodeState = true;

            transform.Rotate(new Vector3(0f, 0f, rotate));

            if ((player != null) && (player.tag == "Player") && (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) < 1.5f))
            {
                BuffFreeze freeze = player.AddComponent<BuffFreeze>();
                player.GetComponent<BuffHandler>().AddBuff(freeze);

                explodeState = true;
            }
            else
                player = GameObject.FindGameObjectWithTag("Player");
        }
        else
            gameObject.GetComponent<Animator>().speed = 1;
    }

    // Called from event in Animator component
    public void Explode()
    {
        Destroy(gameObject);
    }

    public void SetTarget(Transform targetLocation)
    {
        float distance = Vector3.Distance(targetLocation.position, transform.position);
        destructionTimer = 3f;
        float targetX = targetLocation.position.x - transform.position.x + Random.Range(-2f, 2f);
        float targetY = targetLocation.position.y - transform.position.y + Random.Range(-2f, 2f);
        float angle = 0;

        if (targetX != 0)
            angle = Mathf.Atan2(targetY, targetX);

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed);
    }
}
