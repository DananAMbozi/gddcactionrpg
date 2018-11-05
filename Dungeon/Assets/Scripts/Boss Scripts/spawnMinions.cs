using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMinions : MonoBehaviour {
	private GameObject player;

	//spawning enemies
	public Transform shootEn;
    public Transform followEn;
    public Transform explodeEn;
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -3;
    public float maxY = 3;

	private float spawnDelay = 10;
	private float nextSpawnTime;		//when can boss spawn a new minion


	// Use this for initialization
	void Start () {
		nextSpawnTime = 0.0f;
		player = GameObject.Find("Player");
        player.GetComponent<MaxEnemies>().addMax();
        int max = player.GetComponent<MaxEnemies>().GetMax();
        if (PlayerStats.randomLevel)
        {
            max = 4;
        }
	}
	
	// Update is called once per frame
	void Update () {
		int max = 4;

		//add timing conditions
		/*
        int numberShootEn = (int)(max * Random.value);
        SpawnObj(shootEn, numberShootEn, true);

        int numFollowEn = (int)(max * Random.value);
        SpawnObj(followEn, numFollowEn, false);

        int numExplodeEn = (int)(max * Random.value);
        SpawnObj(explodeEn, numExplodeEn, false);
		*/
	}
}
