using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxEnemies : MonoBehaviour {

    public int maxEnemies { get; private set; }

    public int GetMax()
    {
        return maxEnemies;
    }
    public void addMax()
    {
        maxEnemies++;
    }
    public void resetMax()
    {
        maxEnemies = 0;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
