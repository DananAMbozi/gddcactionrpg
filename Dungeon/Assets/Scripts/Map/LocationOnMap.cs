using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationOnMap : MonoBehaviour {
    //this is (x,y) location on map
    public Vector2 location;
    
    public Vector2 GetLocation()
    {
        return location;
    }

    public void UpdateLocation(Vector2 change)
    {
        location += change;
    }

    public void SetLocation(Vector2 newLocation)
    {
        location = newLocation;
    }
}
