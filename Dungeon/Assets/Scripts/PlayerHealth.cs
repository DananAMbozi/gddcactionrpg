using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 50;
    public static int health = 50;
    public static int points = 0;
    public float immunityLength;
    private float immunityCD = 0;
    private GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
        startingHealth = PlayerStats.health;
        health = startingHealth;
    }
    public void Update()
    {
        if(immunityCD != 0)
        {
            immunityCD -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (immunityCD < immunityLength)
        {
            immunityCD = immunityLength;
            health -= damage;
            if (health <= 0)
            {
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
