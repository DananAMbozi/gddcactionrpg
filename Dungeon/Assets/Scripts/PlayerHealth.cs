using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 50;
    public static int health;
    public static int points = 0;

    public void Start()
    {
        startingHealth = PlayerStats.health;
        health = startingHealth;
    }

    public void TakeDamageFromEnemy(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene("Menu");
            health = startingHealth;
            points = 0;
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
