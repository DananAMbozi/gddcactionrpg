using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CreateLevelFromMap : MonoBehaviour
{
    public GameObject[] walls;
    //from walls folder, note walls outdated (mismatch camera)
    //these are just for collision
    //still only support one size room
    private int distanceBetweenRooms;
    public GameObject dynamicLevelBounds;
    public void CreateLevel(Map map)
    {
        distanceBetweenRooms = PlayerStats.distanceBtwnRooms;
        if (distanceBetweenRooms == 0)
        {
            distanceBetweenRooms = 100;
        }
        List<Room> rooms = map.GetRooms();

        //traverses rooms, instantiate new /rooms/ in correct (ish) positions, on a grid sized distanceBetweenRooms
        foreach (Room r in rooms)
        {
            transform.position = distanceBetweenRooms * (new Vector3(r.X, r.Y));
            GameObject newWalls = Instantiate(walls[r.type], transform.position, Quaternion.identity); 
            GameObject bounds = Instantiate(dynamicLevelBounds, transform.position, Quaternion.identity);
        }

        GameObject.Find("Player").transform.position = distanceBetweenRooms * new Vector3((PlayerStats.numRooms + 1), (PlayerStats.numRooms + 1), 0);
    }
}
