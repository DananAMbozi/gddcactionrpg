using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FiniteMapGeneration : MonoBehaviour
{


    public int numRooms = 5;
    public GameObject[] walls;
    public GameObject levelBounds;


    // Use this for initialization

    //room directory:


    //wall prefabs named by this convention
    //N - north, E - east, S - south, W - west, show where doors are
    //adj - adjacent, acr - across
    //0 - empty
    //1 - Home room
    //2 - 4 doors
    //3 - 3 doors, ESW 
    //4 - 3 doors, NSW
    //5 - 3 doors, NEW
    //6 - 3 doors, NES
    //7 - 2 doors adj, NE
    //8 - 2 doors adj, ES
    //9 - 2 doors adj, SW
    //10 - 2 doors adj, NW
    //11 - 2 doors acr, NS
    //12 - 2 doors acr, EW
    //13 - 1 doors, N
    //14 - 1 doors, E
    //15 - 1 doors, S
    //16 - 1 doors, W
    //17 0 doors (not implemented)
    //18 boss room (not implemented, and probably won't be, because with this scheme we'd have to make lots of boss rooms, one for each door setup)

    //nvm this is bad, they're all gonna be four door rooms

    void Start()
    {
        //        Room[,] map = new Room[(2 * numRooms) + 3, (2 * numRooms) + 3]; //map[x,y]
        Room[,] map = new Room[((2 * numRooms) + 3), ((2 * numRooms) + 3)]; //map[x,y]

        int roomsCreated = 0;

        //old        bool[,] check = new bool[(2 * numRooms) + 1, (2 * numRooms) + 1]; //create room array and visted array

        //create home room and 4 adjacent 4 door rooms

        //old arrays

        //test
        //map[((2 * numRooms) + 2), ((2 * numRooms) + 2)] = 0;

        //for (int i = 0; i < ((2 * numRooms) + 1); i++) //will be x
        //{
        //    for (int j = 0; i < ((2 * numRooms) + 1); j++) //will be y
        //    {
        //        map[i, j]=0;
        //    }
        //}

        for (int i = 1; i < (2 * numRooms) + 1; i++) //will be x
        {
            for (int j = 1; j < (2 * numRooms) + 1; j++) //will be y
            {
                map[i, j] = new Room();
            }
        }


                map[numRooms, numRooms].SetType(1);
        map[numRooms, numRooms].SetNumber(0);


        map[numRooms, numRooms + 1].SetType(2);
        map[numRooms, numRooms + 1].SetNumber(1);


        map[numRooms + 1, numRooms].SetType(2);
        map[numRooms + 1, numRooms].SetNumber(2);


        map[numRooms, numRooms - 1].SetType(2);
        map[numRooms, numRooms - 1].SetNumber(3);


        map[numRooms - 1, numRooms].SetType(2);
        map[numRooms - 1, numRooms].SetNumber(4);


        roomsCreated = 4;
        //create map
        int x = numRooms;
        int y = numRooms;

        //test room
        //        Room testRoom = new Room(17, false, false);
        while (roomsCreated < numRooms)
        {
            int checkCounter = 0;
            while (checkCounter < 10) //want to do limited number of checks (10)
            {
                int direction = (int)Random.Range(13, 16); // by one door values eg N is 13, E is 14, S is 15, S is 16
                switch (direction)
                {
                    case 13:
                        if (y < (2 * numRooms))
                        {
                            y++;
                        }; break;
                    case 14:
                        if (x < (2 * numRooms))
                        {
                            x++;
                        }; break;
                    case 15:
                        if (y > 2)
                        {
                            y--;
                        }
                        break;
                    case 16:
                        if (x > 2)
                        {
                            x--;
                        }
                        break;
                }
                checkCounter++;
                if (map[x, y].GetRoomType() == 0)
                { checkCounter = 8; }
            }
            while (map[x, y].GetRoomType() == 0)
            {
                if (y == (2 * numRooms) + 1)
                {
                    x++;
                }
                else
                    y++;
            }
            map[x, y].SetType(2);
            roomsCreated++;
        }


        bool N = false;
        bool E = false;
        bool S = false;
        bool W = false;
        for (int i = 1; i < (2 * numRooms) + 1; i++) //will be x
        {
            for (int j = 1; j < (2 * numRooms) + 1; j++) //will be y
            {
                if (map[i, j + 1].GetRoomType() != 0)
                {
                    N = true;
                }
                if (map[i + 1, j].GetRoomType() != 0)
                {
                    E = true;
                }
                if (map[i, j - 1].GetRoomType() != 0)
                {
                    S = true;
                }
                if (map[i - 1, j].GetRoomType() != 0)
                {
                    S = true;
                }
                //maybe should not be else if
                else if (N && E && S && W) 
                {
                    map[i, j].SetType(2);
                }
                else if (E && S && W)
                {
                    map[i, j].SetType(3);
                }
                else if (N && S && W)
                {
                    map[i, j].SetType(4);
                }
                else if (N && E && W)
                {
                    map[i, j].SetType(5);
                }
                else if (N && E && S)
                {
                    map[i, j].SetType(6);
                }
                else if (N && E)
                {
                    map[i, j].SetType(7);
                }
                else if (E && S)
                {
                    map[i, j].SetType(8);
                }
                else if (S && W)
                {
                    map[i, j].SetType(9);
                }
                else if (N && W)
                {
                    map[i, j].SetType(10);
                }
                else if (N && S)
                {
                    map[i, j].SetType(11);
                }
                else if (E && W)
                {
                    map[i, j].SetType(12);
                }
                else if (N)
                {
                    map[i, j].SetType(13);
                }
                else if (E)
                {
                    map[i, j].SetType(14);
                }
                else if (S)
                {
                    map[i, j].SetType(15);
                }
                else if (W)
                {
                    map[i, j].SetType(16);
                }
                else
                {
                    map[i, j].SetType(0);
                }
            }
        }

        int roomsCreated2 = 4;
        for (int i = 1; i < (2 * numRooms) + 1; i++) //will be x
        {
            for (int j = 1; j < (2 * numRooms) + 1; j++) //will be y
            {
                if (map[i, j].GetRoomType() != 0)
                {
                    map[i, j].SetNumber(roomsCreated2);
                    SceneManager.CreateScene("Room " + roomsCreated2);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Room " + roomsCreated2));
                    Instantiate(walls[map[i, j].GetRoomType()], Vector3.zero, Quaternion.identity);
                    GameObject newLevelBounds = Instantiate(levelBounds, Vector3.zero, Quaternion.identity); //need to make level bounds function to make levels link to each other properly

                    

                    roomsCreated2++;
                }
            }
        }

        int roomsCreated3 = 4;
        for (int i = 1; i < (2 * numRooms) + 1; i++) //will be x
        {
            for (int j = 1; j < (2 * numRooms) + 1; j++) //will be y
            {
                //get small compnents and go from there, look in room array for room types of adjacent rooms and if type non zero set levelname to roomnumber
                if (map[i, j + 1].GetNumber() != 0)
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Room " + roomsCreated3));
                    GameObject Top = GameObject.FindWithTag("Top");
                    if(map[i,j+1].GetNumber() != 100)
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i, j + 1].GetNumber();
                    }
                    else
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
                    }

                    GameObject Right = GameObject.FindWithTag("Right");
                    if (map[i+1, j].GetNumber() != 100)
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i+1, j].GetNumber();
                    }
                    else
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
                    }

                    GameObject Bot = GameObject.FindWithTag("Bot");
                    if (map[i, j-1].GetNumber() != 100)
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i, j-1].GetNumber();
                    }
                    else
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
                    }

                    GameObject Left = GameObject.FindWithTag("Bot");
                    if (map[i-1, j].GetNumber() != 100)
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room " + map[i-1, j].GetNumber();
                    }
                    else
                    {
                        Top.GetComponent<DynamicLevelChange>().levelName = "Room 0";
                    }



                    //want to do levelname, but adjacent rooms might not have roomnumbers yet
                    //                  newLevelBounds.transform.GetChild(0).GetChild(0).GetComponent<DynamicLevelChange>();
                }

 //               newLevelBounds.GetComponent<DynamicLevelChange>().levelName = ("Room " + roomsCreated3); // that's not it lol, inifinitely klooping same room
            }
        }



            }
}


