using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    private Rigidbody2D box;
    public float boxSpeed;
    private GameObject player;

	// Use this for initialization
	void Awake () {
        box = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 dir = Move();
        Rotate(dir);
	}

    Vector2 Move()
    {        
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;
        Vector2 boxPos = box.position;
        Vector2 displacement = playerPos - boxPos;
        box.position += (boxSpeed*Time.deltaTime/10)*displacement;
        return displacement.normalized;
    }
    void Rotate(Vector2 direction)
    {
        if (direction.magnitude < (boxSpeed / 50)) return;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.y);
        transform.localEulerAngles = new Vector3(0, 0, -angle);
    }
}
