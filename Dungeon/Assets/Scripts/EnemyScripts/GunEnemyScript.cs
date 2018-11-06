using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyScript : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D box;
    public int roomSize = 25;
    float cooldown = 1;
    float cooldownElapsed;

    void Awake () {
        box = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        cooldownElapsed = -1.5f;
    }

    void Update () {
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;
        Vector2 boxPos = box.position;
        Vector2 displacement = playerPos - boxPos;
        if (displacement.magnitude < roomSize)
        {
            cooldownElapsed += Time.deltaTime;
        if (cooldownElapsed >= cooldown)
        {
            cooldownElapsed = 0;
            Attack(speed);
        }

        }

    }

    public GameObject Waterball;

    private float speed = 750;

    private void FixedUpdate()
    {

    }

    void Attack(float s)
    {
        GameObject newRAttack = Instantiate(Waterball, transform.position, transform.rotation);
        newRAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, s));
    }
}
