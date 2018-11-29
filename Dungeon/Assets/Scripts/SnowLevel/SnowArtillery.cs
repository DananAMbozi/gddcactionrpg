using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowArtillery : MonoBehaviour {

    // TEMPORARY: SnowCrosshair prefab is created by SnowEmitter.cs (but it should be the level handler)
    float timer = 1f;
    bool explode = false;
    GameObject player;
    int power = 20;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<ParticleSystem>().Pause();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Create explosion particle effect for a set duration before destroying self
            if (!explode)
            {
                gameObject.GetComponent<ParticleSystem>().Play();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                timer = 1f;
                explode = true;
                player = GameObject.FindGameObjectWithTag("Player");

                // If distance to player is < 3, apply freeze and slow debuff
                if ((player != null) && (Vector3.Distance(player.transform.position, transform.position) < 3))
                {
                    player.GetComponent<PlayerHealth>().TakeDamage(power);
                    BuffFreeze freeze = player.AddComponent<BuffFreeze>();
                    player.GetComponent<BuffHandler>().AddBuff(freeze);

                    BuffSlow slow = player.AddComponent<BuffSlow>();
                    slow.SetBuffTimer(5f);
                    player.GetComponent<BuffHandler>().AddBuff(slow);
                }
            }
            else
                Destroy(gameObject);
        }
	}
}
