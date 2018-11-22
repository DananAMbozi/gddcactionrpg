using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    SpriteRenderer damageIndicator;
    Color damageColour;
    private float damageCooldown = 0.1f;
    private bool damaged = false;
    public int health = 10;
    public int reward = 1;
    public bool isEnemy;
    public bool isDead = false;

    private void Awake()
    {
        damageIndicator = gameObject.GetComponent<SpriteRenderer>();
        if((gameObject.tag ==  "Enemy") || (gameObject.tag == "Boss") || (gameObject.tag == "GunEnemy"))
            gameObject.AddComponent<BuffHandler>();
    }

    private void Update()
    {
        if (damaged)
        {
            damageCooldown -= 1 * Time.deltaTime;
            if (damageCooldown <= 0)
            {
                damaged = false;
                damageIndicator.color -= damageColour;
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
            damageColour = new Color(Mathf.Sign(damage), -Mathf.Sign(damage), -1f, 0f);
            damageIndicator.color += damageColour;
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
