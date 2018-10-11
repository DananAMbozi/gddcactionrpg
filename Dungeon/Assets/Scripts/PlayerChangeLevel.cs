using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChangeLevel : MonoBehaviour
{

    public Vector2 position;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
            other.SendMessage("ChangePosition", position, SendMessageOptions.DontRequireReceiver);
        }
    }

}
