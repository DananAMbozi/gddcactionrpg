using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    SpriteRenderer damageIndicator;
    private float damageCooldown = 0.1f;
    private bool damaged = false;
    public int health = 10;
    public int reward = 1;
    public bool isEnemy;
    public bool isDead = false;

    private void Awake()
    {
        damageIndicator = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (damaged)
        {
            damageCooldown -= 1 * Time.deltaTime;
            if (damageCooldown <= 0)
            {
                damaged = false;
                damageIndicator.color = new Color(1, 1, 1);
            }
        }
    }

    public void TakeDamageFromPlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ChangePoints(reward);
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        health -= damage;

        if (damage != 0)
        {
            damageIndicator.color = new Color(Mathf.Sign(damage), -Mathf.Sign(damage), 0f);
            damaged = true;
            damageCooldown = 0.1f;
        }
        if (health <= 0)
        {
            isDead = true;
            GameObject.Find("Player").GetComponent<PlayerHealth>().ChangePoints(reward);
            Destroy(gameObject);
      //      if (isEnemy)
     //       {
      //          transform.parent.GetChild(2).GetComponent<DoorLocks>().EnemyDied();
        //    }
        }
    }

}
