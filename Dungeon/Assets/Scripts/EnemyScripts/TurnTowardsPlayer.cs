using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowardsPlayer : MonoBehaviour {

    private Rigidbody2D box;
    private GameObject player;

    void Awake () {
        box = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
	
	void Update () {
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;
        Vector2 boxPos = box.position;
        Vector2 displacement = playerPos - boxPos;
        if (displacement.magnitude < 50)
        {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(displacement.x, displacement.y);
        transform.localEulerAngles = new Vector3(0, 0, -angle);
        }
    }
}
