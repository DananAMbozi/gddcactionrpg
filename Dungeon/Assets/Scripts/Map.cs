using System;

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


    internal bool HasRoom(int column, int row)
    {
        return Rooms[row, column] == 1;
    }
}

//maybe not use
public class Room
{
    int roomType = 0;
    int roomNumber = 100;
    //    bool finishedAdjacentRooms = false;

    public Room(int Type)
    {
        roomType = Type;

    }

    public Room()
    {
        roomType = 0;
        int roomNumber = 100;

    }


    public void SetType(int type)
    {
        roomType = type;
    }

    //public void FinishRoom()
    //{
    //    finishedAdjacentRooms = true;
    //}

    public int GetRoomType()
    {
        return roomType;
    }

    public void SetNumber(int number)
    {
        roomNumber = number;
    }

    public int GetNumber()
    {
        return roomNumber;
    }

    //public bool GetFinished()
    //{ 
    //    return finishedAdjacentRooms;
    //}

}
