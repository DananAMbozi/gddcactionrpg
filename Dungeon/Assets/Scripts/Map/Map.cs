using System;
using System.Collections.Generic;


public class Map
{
    public Map(int x, int y, int numRooms, int[,] floor)
    {
        X = x;
        Y = y;
        NumRooms = numRooms;
        Rooms = floor;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public int NumRooms { get; private set; }
    public int[,] Rooms { get; private set; }
    public int[,] RoomIndex { get; private set; }

    public void SetType(int column, int row, int type)
    {
        Rooms[row, column] = type;
    }
    public int GetRoomType(int column, int row)
    {
        return Rooms[row, column];
    }

    internal bool HasRoom(int column, int row)
    {
        return Rooms[row, column] != 0; //lol I think this is why things were backwards (opposite row/column)
    }
    public List<Room> GetRooms()
    {
        List<Room> rooms = new List<Room>();
        for (int i = 0; i < Rooms.GetLength(0); i++)
        {

            for (int j = 0; j < Rooms.GetLength(1); j++)
            {
                int t = Rooms[i, j];
                if (t != 0)
                {
                Room R = new Room(i, j, t);
                rooms.Add(R);
                }
            }
        }


                return rooms;
    }
}

public class Room
{

    public Room(int x, int y, int RoomType)
    {
        X = x;
        Y = y;
        type = RoomType;
    }
    public int X { get; private set; }
    public int Y { get; private set; }
    public int type { get; private set; }

}
