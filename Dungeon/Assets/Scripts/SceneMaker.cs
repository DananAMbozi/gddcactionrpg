//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SceneMaker : MonoBehaviour
//{


//    public int numRooms = 5;
//    public GameObject[] walls;
//    public GameObject levelBounds;
//    // Use this for initialization
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void GenerateScenes(Map map)
//    {
//        int roomsCreated2 = 4;
//        for (int i = 1; i < (2 * numRooms) + 1; i++) //will be x
//        {
//            for (int j = 1; j < (2 * numRooms) + 1; j++) //will be y
//            {
//                if (map.Rooms[i, j] != 0)
//                {
//                    map[i, j].SetNumber(roomsCreated2);
//                    SceneManager.CreateScene("Room " + roomsCreated2);
//                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Room " + roomsCreated2));
//                    Instantiate(walls[map[i, j].GetRoomType()], Vector3.zero, Quaternion.identity);
//                    GameObject newLevelBounds = Instantiate(levelBounds, Vector3.zero, Quaternion.identity); //need to make level bounds function to make levels link to each other properly



//                    roomsCreated2++;
//                }
//            }
//        }

//        int roomsCreated3 = 4;
//        for (int i = 1; i < (2 * numRooms) + 1; i++) //will be x
//        {
//            for (int j = 1; j < (2 * numRooms) + 1; j++) //will be y
//            {
//                //get small compnents and go from there, look in room array for room types of adjacent rooms and if type non zero set levelname to roomnumber
//                if (map[i, j + 1].GetNumber() != 0)
//                {
//                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Room " + roomsCreated3));
//                    GameObject Top = GameObject.FindWithTag("Top");
//                    if (map[i, j + 1].GetNumber() != 100)
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i, j + 1].GetNumber();
//                    }
//                    else
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
//                    }

//                    GameObject Right = GameObject.FindWithTag("Right");
//                    if (map[i + 1, j].GetNumber() != 100)
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i + 1, j].GetNumber();
//                    }
//                    else
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
//                    }

//                    GameObject Bot = GameObject.FindWithTag("Bot");
//                    if (map[i, j - 1].GetNumber() != 100)
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i, j - 1].GetNumber();
//                    }
//                    else
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
//                    }

//                    GameObject Left = GameObject.FindWithTag("Bot");
//                    if (map[i - 1, j].GetNumber() != 100)
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i - 1, j].GetNumber();
//                    }
//                    else
//                    {
//                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
//                    }



//                    //want to do levelname, but adjacent rooms might not have roomnumbers yet
//                    //                  newLevelBounds.transform.GetChild(0).GetChild(0).GetComponent<DynamicLevelChange>();
//                }

//                //               newLevelBounds.GetComponent<DynamicLevelChange>().levelName = ("Room " + roomsCreated3); // that's not it lol, inifinitely klooping same room
//            }
//        }
//    }
//}

