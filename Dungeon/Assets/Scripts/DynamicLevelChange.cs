using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicLevelChange : MonoBehaviour
{

    public Vector2 position;
    public string levelName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
            other.SendMessage("ChangePosition", position, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void SetTargetLevel(string targetLevel)
    {
        levelName = targetLevel;
    }

}
