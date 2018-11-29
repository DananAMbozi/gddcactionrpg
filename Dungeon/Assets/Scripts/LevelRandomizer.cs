using System.Collections;
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
    public Transform brushEn;

    public float minX = -8.5f;
    public float maxX = 8.5f;
    public float minY = -3;
    public float maxY = 3;
    public int numEnemies = 0;


    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<MaxEnemies>().addMax();
        int max = player.GetComponent<MaxEnemies>().GetMax();
        if (PlayerStats.randomLevel)
        {
            max = 4;
        }

        int numberOfBoxes = (int)(3 * Random.value) + 2;
        SpawnObj(box, numberOfBoxes, false);

        int numberOfRocks = (int)(3 * Random.value);
        SpawnObj(rock, numberOfRocks, false);

        int numberShootEn = (int)(max * Random.value);
        SpawnObj(shootEn, numberShootEn, true);
        numEnemies += numberShootEn;

        int numFollowEn = (int)(max * Random.value);
        SpawnObj(followEn, numFollowEn, false);
        numEnemies += numFollowEn;

        int numExplodeEn = (int)(max * Random.value);
        SpawnObj(explodeEn, numExplodeEn, false);
        numEnemies += numExplodeEn;

        int numBrushEn = (int)(max * Random.value);
        SpawnObj(brushEn, numBrushEn, false);
        numEnemies += numBrushEn;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == "DoorsObject")
            {
                child.GetComponent<DoorLocks>().SetNumEnemies(numEnemies);
            }
        }

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
            newObj.SetParent(transform);
        }
    }
}

