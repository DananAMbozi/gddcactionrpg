using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{

    public enum Options { None, Spawn };
    public Options options;
    public GameObject toSpawn;
    public bool isDead = false;
    public static bool isQuitting = false;

    private void Start()
    {
        isQuitting = false;
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void Update()
    {
        if (options == Options.Spawn && isDead)
        {
            GameObject spawnObj = Instantiate(toSpawn, transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(gameObject);
        }
        else if (isDead)
        {
            Destroy(gameObject);
        }
    }
}
