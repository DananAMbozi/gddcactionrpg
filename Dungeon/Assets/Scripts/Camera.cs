using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public static bool CameraExists;
    public GameObject player;
    public bool follow;
    public Vector2 minPos;
    public Vector2 maxPos;
    //private Vector2 pos;
    //private Vector2 newPos;

    void Start()
    {
        if (follow)
        {
            player = GameObject.Find("Player");
        }

        if (!CameraExists)
        {
            CameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player == null);
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        if (follow && player != null)
        {
            transform.position = FollowCam(player.transform.position);
        }
    }

    Vector3 FollowCam(Vector3 pos)
    {
        Vector3 newpos;
        newpos = new Vector3(Mathf.Clamp(pos.x, minPos.x, maxPos.x), Mathf.Clamp(pos.y, minPos.y, maxPos.y), -10);
        return newpos;
    }
    public void FollowOn()
    {
        follow = true;
        player = GameObject.Find("Player");
        //Debug.Log(player == null);
        Vector2 v = new Vector2(1, 1);
        float range = 10000;
        minPos = -range * v;
        maxPos = range * v;

    }
}
