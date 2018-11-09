using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{

    public int health = 10;
    public int reward = 1;
    public bool isEnemy;
    public bool isDead = false;

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
