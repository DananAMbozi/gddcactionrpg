using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack2 : MonoBehaviour {

    public int Mdamage = 20;
    public float swingT = 0.5f;
    private GameObject player;
    private float swingDeg = 0;
    private float swingSpeed;
    private Vector3 playerDirectionV;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        swingT = PlayerStats.swingTime;
        swingSpeed = 180 / swingT; //in deg/s
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void MAttack()
    {

    }
}
