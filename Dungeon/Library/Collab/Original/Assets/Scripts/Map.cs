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

    internal bool HasRoom(int column, int row)
    {
        return Rooms[row, column] == 1;
    }
}
