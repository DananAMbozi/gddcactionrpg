using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMap : MonoBehaviour
{

    public GameObject RoomBox;
    public GameObject[] Rooms;

    public void MakeMap(Map map)
    {
        //       int temp = map.X * map.Y; E- I commented this out and it didn't break anything

        for (int column = 0; column < map.Y; column++)
        {
            transform.localPosition = new Vector3(-445, 205 - column * 45, 0);
            for (int row = 0; row < map.X; row++)
            {
                transform.localPosition += new Vector3(80, 0, 0);
                if ((map.HasRoom(column, row)))
                {
                    Debug.Log(row + "," + column + "," + map.Y);


                    //do adjacent rooms exist
                    bool N = false;
                    bool E = false;
                    bool S = false;
                    bool W = false;
                    //I have a feeling that east and west are switched because of camera, will try swapping them
                    //maybe both N&S and E&W were swappped, trying now
                    //it worked
                    //not working
                    //working with crude fixes
                    //camera flipped in editor view, need to fix that

                    if (row != map.Y - 1)
                    {
                        S = map.HasRoom(column, row + 1);
                    }
                    if (column != map.X - 1)
                    {
                        W = map.HasRoom(column + 1, row);

                    }
                    if (row > 1)
                    {
                        N = map.HasRoom(column - 1, row);

                    }
                    if (column > 1)
                    {
                        E = map.HasRoom(column, row - 1);

                    }

                    //room type, described below
                    int roomType = 0;

                    if (N && E && S && W)
                    {
                        roomType = 2;
                    }
                    else if (!N && E && S && W)
                    {
                        roomType = 3;
                    }
                    else if (N && !E && S && W)
                    {
                        roomType = 6; //
                    }
                    else if (N && E && !S && W)
                    {
                        roomType = 4; //idk
                    }
                    else if (N && E && S && !W)
                    {
                        roomType = 5; //idk
                    }
                    else if (N && E && !S && !W)
                    {
                        roomType = 10;//
                    }
                    else if (!N && E && S && !W)
                    {
                        roomType = 12; //idk
                    }
                    else if (!N && !E && S && W)
                    {
                        roomType = 8;//
                    }
                    else if (N && !E && !S && W)
                    {
                        roomType = 11;//idk
                    }
                    else if (N && !E && S && !W)
                    {
                        roomType = 7;//idk //
                    }
                    else if (!N && E && !S && W)
                    {
                        roomType = 9;//idk//
                    }
                    else if (N && !E && !S && !W)
                    {
                        roomType = 13;
                    }
                    else if (!N && E && !S && !W)
                    {
                        roomType = 16;//
                    }
                    else if (!N && !E && S && !W)
                    {
                        roomType = 14; //idk
                    }
                    else if (!N && !E && !S && W)
                    {
                        roomType = 15; //idk
                    }
                    else
                    {
                        roomType = 0;
                    }

                    GameObject newbox = Instantiate(Rooms[roomType], transform.position, transform.rotation);
                    //GameObject newbox = Instantiate(RoomBox, transform.position, transform.rotation/*,transform*/);


                    newbox.transform.parent = transform.parent;

                    //newbox.transform.localPosition = new Vector3(0, 0, 0);
                    newbox.transform.localScale = new Vector3(1, 1, 1);

                }
            }
        }
    }
}

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
