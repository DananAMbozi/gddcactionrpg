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
    private float evasionChance = 0f;

    private void Awake()
    {
        // Used to change the colour of the object on taking damage/healing
        damageIndicator = gameObject.GetComponent<SpriteRenderer>();
        // Attach BuffHandler script to the object if they contain the following tags. This script lets them handle buffs/debuffs
        if((gameObject.tag ==  "Enemy") || (gameObject.tag == "Boss") || (gameObject.tag == "GunEnemy"))
            gameObject.AddComponent<BuffHandler>();
    }

    private void Update()
    {
        // If the object has taken damage or healed, they will change colour for a brief period of time
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

    public void SetEvasion(float newEvasion)
    {
        evasionChance = newEvasion;
    }
    public float GetEvasion()
    {
        return evasionChance;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        float hitChance = Random.Range(0, 1f);

        if (hitChance >= evasionChance)
        {
            health -= damage;

            // If the object has taken damage or healed, they will flash red or green for a set amount of time
            if ((damage != 0) && (!damaged))
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
            if (isEnemy)
            {
                transform.parent.GetChild(2).GetComponent<DoorLocks>().EnemyDied();
            }
            }
        };
    }
}
