using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool damaged = false;
    private float damageCooldown = 0.1f;
    SpriteRenderer damageColour;
    Color offsetColour;

    public int startingHealth;
    public static int health = 50;
    public static int points = 0;
    public float immunityLength;
    private float immunityCD = 0;
    private GameObject player;

    public void Start()
    {
        offsetColour = new Color(1f, 1f, 1f);
        player = GameObject.Find("Player");
        damageColour = player.GetComponent<SpriteRenderer>();
        startingHealth = PlayerStats.health;
        if(startingHealth == 0)
        {
            startingHealth = 5000; //testing
        }
        health = startingHealth;
    }
    public void Update()
    {
        if (immunityCD != 0)
        {
            immunityCD -= Time.deltaTime;
        }

        if (damaged)
        {
            damageCooldown -= 1 * Time.deltaTime;

            if (damageCooldown <= 0)
            {
                damaged = false;
                damageColour.color -= offsetColour;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (immunityCD < immunityLength)
        {
            immunityCD = immunityLength;
            health -= damage;

            if ((damage != 0) && !(damaged))
            {
                offsetColour = new Color(Mathf.Sign(damage), -Mathf.Sign(damage), -1f);
                damageColour.color += offsetColour;
                damaged = true;
                damageCooldown = 0.1f;
            }
            if (health <= 0)
            {
                OnDeath.isQuitting = true;
                SceneManager.LoadScene("Menu");
                health = startingHealth;
                points = 0;
                player.GetComponent<MaxEnemies>().resetMax();
            }
        }

    }

    public int GetHealth()
    {
        return health;
    }

    public void ChangePoints(int summand)
    {
        points += summand;
    }


}
