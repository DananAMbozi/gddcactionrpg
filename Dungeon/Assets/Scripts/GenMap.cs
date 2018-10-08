﻿using UnityEngine;

public class GenMap : MonoBehaviour
{
    public int NumRooms;
    public static int MapSizeX = 42;
    public static int MapSizeY = 42;
    public GameObject MapMaker;
    private int temp;

    public void Start()
    {
        MapSizeX = 2 * (NumRooms + 1);
        MapSizeY = 2 * (NumRooms + 1);

        int[,] floor = new int[MapSizeX, MapSizeY];

        int midRoomX = Mathf.RoundToInt(MapSizeX / 2);
        int midRoomY = Mathf.RoundToInt(MapSizeY / 2);
        floor[midRoomX, midRoomY] = 1;

        int NumSpawned = 1;
        int posX = midRoomX;
        int posY = midRoomY;
        while (NumSpawned < NumRooms)
        {
            int move = Move();

            //Debug.Log(move);

            if (isEven(move))
            {
                if (0 <= posY + (move / 2) && posY + (move / 2) < MapSizeY)
                {
                    move = move / 2;
                    posY += move;
                }
            }
            else if (0 <= posX + move && posX + move < MapSizeX)
            {
                posX += move;
            }

            move = 0;

            if (floor[posX, posY] == 0)
            {
                floor[posX, posY] = 1;
                NumSpawned++;
                //Debug.Log(posX + " , " + posY);
            }
        }

        Map map = new Map(MapSizeX, MapSizeY, NumRooms, floor);
        MapMaker.GetComponent<DrawMap>().MakeMap(map);

    }

    private static bool isEven(int move)
    {
        return move % 2 == 0;
    }

    private static int Move()
    {
        int move = 0;

        while (move == 0)
        {
            move = Random.Range(-2, 3);
        }

        return move;
    }

    private class NewRoom
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
    }

}

