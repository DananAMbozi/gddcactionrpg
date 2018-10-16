using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicLoad : MonoBehaviour
{

    private string LeveltoLoad;
    public Vector2 position;
    public Vector2 change;
    private GameObject player;

    void OnEnable()
    {
        player = GameObject.Find("Player");
        position = player.GetComponent<LocationOnMap>().GetLocation();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<LocationOnMap>().UpdateLocation(change);
        position = player.GetComponent<LocationOnMap>().GetLocation();
        LeveltoLoad = "" + position.x + "." + position.y;
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetSceneByName(LeveltoLoad).IsValid())
            {
                SceneManager.LoadScene(LeveltoLoad);
            }
            else
            {
                SceneManager.LoadScene("" + (PlayerStats.numRooms + 1) + "." + (PlayerStats.numRooms + 1));

            }
        }
        other.SendMessage("ChangePosition", position, SendMessageOptions.DontRequireReceiver);
    }
}
