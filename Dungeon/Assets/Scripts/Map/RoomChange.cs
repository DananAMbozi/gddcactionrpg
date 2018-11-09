using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{

    private string LeveltoLoad;
    private Vector3 playerPos;
    public Vector3 change;
    private GameObject player;
    private GameObject cam;
    private int distance;
    private bool passed = false; //player seems to be triggering collision multiple times

    void OnEnable()
    {
        //0711 horizontaltp not synced after room resize
        //how far to teleport player
        distance = PlayerStats.distanceBtwnRooms;
        if (distance == 0)
        {
            distance = 90; //default
        }
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        //playerPos = player.GetComponent<LocationOnMap>().GetLocation(); //x,y pos on map
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !passed)
        {
            //player.GetComponent<LocationOnMap>().UpdateLocation(change); //updates x,y pos on map
            //playerPos = player.GetComponent<LocationOnMap>().GetLocation(); //gets new x,y pos on map
            cam.GetComponent<CameraScript>().center += 100 * new Vector3(Mathf.RoundToInt(change.x), Mathf.RoundToInt(change.y), 0);
            cam.transform.position += 100 * new Vector3(Mathf.RoundToInt(change.x), Mathf.RoundToInt(change.y), 0);
            player.transform.position += distance * change; //moves physical location in gamespace
            passed = true;
        }
    }
    void Update()
    {
        Vector3 displacement = transform.position - player.transform.position;
        if (displacement.magnitude > 20)
        {
            passed = false;
        }
    }
}
