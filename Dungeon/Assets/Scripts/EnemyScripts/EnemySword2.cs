using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword2 : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    private float coolDownCounter = 3;
    GameObject player;
    int state = 0;
    bool finishedAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0: // Track player
                if (player != null)
                {
                    if (finishedAttack)
                    {
                        coolDownCounter -= Time.deltaTime;

                        if (Mathf.Abs(player.transform.position.x - transform.position.x) < Mathf.Abs(player.transform.position.y - transform.position.y))
                        {
                            if (player.transform.position.y > transform.position.y)
                            {
                                anim.SetInteger("orientation", 1);
                                anim.Play("SwordEnemyAttackBack", 0, 0);
                            }
                            else
                            {
                                anim.SetInteger("orientation", 3);
                                anim.Play("SwordEnemyAttackFront", 0, 0);
                            }
                        }
                        else
                        {
                            if (player.transform.position.x > transform.position.x)
                            {
                                anim.SetInteger("orientation", 0);
                                anim.Play("SwordEnemyAttackRight", 0, 0);
                            }
                            else
                            {
                                anim.SetInteger("orientation", 2);
                                anim.Play("SwordEnemyAttackLeft", 0, 0);
                            }
                        }
                        anim.speed = 0;
                        if ((Mathf.Abs(player.transform.position.x - transform.position.x) < 5) || (Mathf.Abs(player.transform.position.y - player.transform.position.y) < 5))
                        {
                            if (coolDownCounter <= 0)
                            {
                                coolDownCounter = 3;
                                state = 1;
                            }
                        }
                    }
                }
                else
                    player = GameObject.FindGameObjectWithTag("Player");
                break;
            case 1: // Attack player
                anim.speed = 1;
                finishedAttack = false;
                player.GetComponent<PlayerHealth>().TakeDamage(15);
                state = 0;
                break;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && coolDownCounter <= 0)
        {
            coolDownCounter = 3;
            player.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }

    void FinishedAttack()
    {
        finishedAttack = true;
    }
}
