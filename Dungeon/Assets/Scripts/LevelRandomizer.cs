using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomizer : MonoBehaviour {

    public Transform box;
    public Transform rock;
    public Transform statEn;
    public Transform shootEn;

    void Start()
    {
        int numberOfBoxes = (int)(3 * Random.value) + 2;
        for (int i = 0; i < numberOfBoxes; i++)
        {
            Instantiate(box, new Vector3(Random.Range(-10, 12), Random.Range(-3, 3), 0), Quaternion.identity);
        }
        int numberOfRocks = (int)(3 * Random.value);
        for (int i = 0; i < numberOfRocks; i++)
        {
            Instantiate(rock, new Vector3(Random.Range(-10, 12), Random.Range(-3, 3), 0), Quaternion.identity);
        }
        int numberStaEn = (int)(3 * Random.value);
        for (int i = 0; i < numberStaEn; i++)
        {
            Instantiate(statEn, new Vector3(Random.Range(-10, 12), Random.Range(-3, 3), 0), Quaternion.identity);
        }
        int numberShootEn = (int)(3 * Random.value);
        for (int i = 0; i < numberShootEn; i++)
        {
            Instantiate(shootEn, new Vector3(Random.Range(-10, 12), Random.Range(-3, 3), 0), Quaternion.Euler(new Vector3(0, 0, (int)(Random.Range(0, 3))*90)));
        }

    }
}

