using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{

    public int health = 10;
    public int reward = 1;
    public bool isEnemy;

    public void TakeDamageFromPlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ChangePoints(reward);
            Destroy(gameObject);
        }
    }

    public void TakeDamageFromEnemy(int damage)
    {
        if (!isEnemy)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
