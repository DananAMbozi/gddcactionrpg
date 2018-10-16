using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string LeveltoLoad;
    public Vector2 position;

    public void StartGame()
    {
        OnDeath.isQuitting = true;
        SceneManager.LoadScene(LeveltoLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnDeath.isQuitting = true;
            SceneManager.LoadScene(LeveltoLoad);
            other.SendMessage("ChangePosition", position, SendMessageOptions.DontRequireReceiver);
        }
    }
}
