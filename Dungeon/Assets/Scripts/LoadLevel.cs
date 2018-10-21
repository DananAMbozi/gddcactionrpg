using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string LeveltoLoad;
    public Vector2 position;

    public void StartGame()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(LeveltoLoad);
            other.SendMessage("ChangePosition", position, SendMessageOptions.DontRequireReceiver);
        }
    }
}
