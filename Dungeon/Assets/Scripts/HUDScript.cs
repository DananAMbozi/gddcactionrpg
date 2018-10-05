using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour {

    public float playerScore = 0;
    public float playerHealth = 0;

    void Start()
    {
        
    }
    void Update()
    {
        playerHealth = PlayerHealth.health;
        playerScore = PlayerHealth.points;
        //playerScore += Time.deltaTime;
    }

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    void OnGUI()
    {
        //GUI.Label (new Rect(0.1 * Screen.Width, 0.1 * ScreenHeight, 100, 30), "Score: " + (int)(playerScore * 100));
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + (int)(playerHealth));
        GUI.Label(new Rect(10, 25, 100, 30), "Score: " + (int)(playerScore));
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)(playerScore));
    }
}
