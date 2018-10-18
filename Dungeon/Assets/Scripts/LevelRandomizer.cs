﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomizer : MonoBehaviour
{
    private GameObject player;

    public Transform box;
    public Transform rock;
    //public Transform statEn;
    public Transform shootEn;
    public Transform followEn;
    public Transform explodeEn;
    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -3;
    public float maxY = 3;


    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<MaxEnemies>().addMax();
        int max = player.GetComponent<MaxEnemies>().GetMax();
        if (PlayerStats.randomLevel)
        {
            max = 10;
        }

        int numberOfBoxes = (int)(3 * Random.value) + 2;
        SpawnObj(box, numberOfBoxes, false);

        int numberOfRocks = (int)(3 * Random.value);
        SpawnObj(rock, numberOfRocks, false);

        int numberShootEn = (int)(max * Random.value);
        SpawnObj(shootEn, numberShootEn, true);

        int numFollowEn = (int)(max * Random.value);
        SpawnObj(followEn, numFollowEn, false);

        int numExplodeEn = (int)(max * Random.value);
        SpawnObj(explodeEn, numExplodeEn, false);
    }
    void SpawnObj(Transform t, int num, bool rotate)
    {
        for (int i = 0; i < num; i++)
        {
            Quaternion q = Quaternion.identity;
            if (rotate)
            {
                q = Quaternion.Euler(0, 0, Random.Range(0, 7) * 45);
            }
            Transform newObj = Instantiate(t, new Vector3(0, 0, 0), q);
            Vector3 newPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            newObj.position = transform.position;
            newObj.localPosition += newPos;
        }
    }
}

