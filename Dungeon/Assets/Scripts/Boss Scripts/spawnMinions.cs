using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMinions : MonoBehaviour {
	private GameObject player;
	public float spawnRate;
	private float spawnRadius = 5;

	//spawning enemies
	public Transform shootEn;
    //public Transform followEn;
    //public Transform explodeEn;
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -3;
    public float maxY = 3;

	private float spawnDelay = 10;
	private float nextSpawnTime;		//when can boss spawn a new minion


	// Use this for initialization
	void Start () {
        nextSpawnTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		int max = 4;

        if(Time.time > nextSpawnTime){
            SpawnObj(shootEn, 8, true);
            nextSpawnTime = Time.time + nextSpawnTime + 10/spawnRate;
        }
		/*
        int numberShootEn = (int)(max * Random.value);
        SpawnObj(shootEn, numberShootEn, true);

        int numFollowEn = (int)(max * Random.value);
        SpawnObj(followEn, numFollowEn, false);

        int numExplodeEn = (int)(max * Random.value);
        SpawnObj(explodeEn, numExplodeEn, false);
		*/
	}

    void SpawnObj(Transform t, int num, bool rotate)
    {
        float spawnAngle = 0;
        float spawnIncrement = 360/num;
        for (int i = 0; i < num; i++)
        {
            Quaternion q = Quaternion.identity;
            if (rotate)
            {
                q = Quaternion.Euler(0, 0, Random.Range(0, 7) * 45);
            }
            float cosAngle = (float)System.Math.Cos(spawnAngle * System.Math.PI / 180);
            float sinAngle = (float)System.Math.Sin(spawnAngle * System.Math.PI / 180);
            Debug.Log(gameObject.transform.position.x+ spawnRadius * cosAngle);
            Debug.Log(gameObject.transform.position.y+ spawnRadius * sinAngle);
            Vector3 spawnPos = new Vector3(gameObject.transform.position.x + spawnRadius * cosAngle, gameObject.transform.position.y + spawnRadius * sinAngle, 0);
            Transform newObj = Instantiate(t, spawnPos, q);
            spawnAngle += spawnIncrement;
        }
    }
}
