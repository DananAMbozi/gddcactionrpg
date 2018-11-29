using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDog : MonoBehaviour {

    private int pos = 0;    // 0 = right, 1 = down, 2 = left, 3 = up
    private int state = 0;  // 0 = idle, 1 = firing, transition, 2 = dead
    private float stateTimer = 10f;
    private bool fired = false;
    private float offsetDistance = 2.5f;
    private bool dead = false;

    GameObject artillery;
    Transform player;
    Transform changePosition;
    Animator anim;

	// Use this for initialization
	void Start () {
        GameObject snowEmitter = GameObject.FindWithTag("SnowEmitter");
        if(snowEmitter != null)
            snowEmitter.GetComponent<SnowEmitter>().EnableArtillery(false);
        player = GameObject.FindWithTag("Player").transform;

        artillery = (GameObject)Resources.Load("Enemies/SnowCrosshair");
        anim = gameObject.GetComponent<Animator>();
        changePosition = gameObject.transform;
        changePosition.position = new Vector3(offsetDistance, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (!dead)
        {
            switch (state)
            {
                case 0:
                    stateTimer -= Time.deltaTime;

                    if ((fired) && (stateTimer <= 0))
                    {
                        fired = false;
                        stateTimer = 10f;
                        anim.ResetTrigger("firing");
                        state = 1;
                    }
                    else if ((!fired) && (stateTimer <= 5f))
                    {
                        fired = true;
                        anim.SetTrigger("firing");
                        if (player != null)
                            Instantiate(artillery, player.position, Quaternion.identity);
                    }
                    break;
                case 1:
                    pos = Random.Range(0, 4);
                    changePosition.position = new Vector3(((1 - pos) % 2) * (offsetDistance + 2), ((2 - pos) % 2) * offsetDistance, 0f);
                    anim.SetInteger("orientation", pos);
                    if (transform.position.x >= 0)
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    else
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    state = 0;
                    break;
                default:
                    state = 0;
                    break;
            }
        }
	}

    public void SetDeath()
    {
        dead = true;
        anim.SetBool("isDead", true);
    }
}
