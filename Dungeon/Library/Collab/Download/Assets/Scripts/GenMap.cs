using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour
{
    public int NumRooms;
    public static int MapSizeX = 42;
    public static int MapSizeY = 42;
    public GameObject MapMaker;
    private int temp;
    private int move = 0;

    //private int[,] Room = new int[MapSizeX, MapSizeY];

    public void Start()
    {
        MapSizeX = 2*(NumRooms+1);
        MapSizeY = 2 * (NumRooms + 1);

        int[,] floor = new int[MapSizeX, MapSizeY];

        for (int column = 0; column < MapSizeY; column++)
        {
            for (int row = 0; row < MapSizeX; row++)
            {
                floor[row, column] = 0;
            }
        }

        floor[Mathf.RoundToInt(MapSizeX / 2), Mathf.RoundToInt(MapSizeY / 2)] = 1;

        if (!(MapSizeX % 2 == 0))
        {
            temp = MapSizeX + 1;
        }
        else
        {
            temp = MapSizeX;
        }
        int posX = temp / 2;

        if (!(MapSizeY % 2 == 0))
        {
            temp = MapSizeY + 1;
        }
        else
        {
            temp = MapSizeY;
        }
        int posY = temp / 2;

        int NumSpawned = 1;

        while (NumSpawned < NumRooms)
        {
            //int move = Random.Range(-2, 3);

            while (move == 0)
            {
                move = Random.Range(-2, 3);
            }

            //Debug.Log(move);

            if (move % 2 == 0)
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
}
