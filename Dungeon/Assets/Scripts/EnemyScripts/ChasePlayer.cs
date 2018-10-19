using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{

    private Rigidbody2D box;
    private GameObject player;
    public float boxSpeed;
    public int roomSize = 25;
    private bool chase;
    public bool autochase = true;

    void Awake()
    {
        box = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;
        Vector2 boxPos = box.position;
        Vector2 displacement = playerPos - boxPos;
        if (autochase)
        {
            if (displacement.magnitude < roomSize)
            {
                chase = true;
            }
            else
            {
                chase = false;
            }
        }
        if (chase)
        {
            Vector2 dir = Move(displacement);
            Rotate(dir); //may want to merge this with turn towards player script
        }
    }

    Vector2 Move(Vector2 d)
    {
        box.position += (boxSpeed * Time.deltaTime / 10) * d;
        return d.normalized;
    }
    void Rotate(Vector2 direction)
    {
        if (direction.magnitude < (boxSpeed / 50)) return;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.y);
        transform.localEulerAngles = new Vector3(0, 0, -angle);
    }

    public void StopChasing()
    {
        autochase = false;
        chase = false;
    }

    public void StartChasing()
    {
        autochase = true;
    }
}
