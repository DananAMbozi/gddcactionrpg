using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public GameObject Fireball;

    private float speed;
    private int damage;

    public void Start()
    {
        speed = 750f;// PlayerStats.atkspeed;
        damage = 9001; //PlayerStats.damage;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(speed);
        }
    }

    void Attack(float s)
    {
        GameObject newRAttack = Instantiate(Fireball, transform.position, transform.rotation);
        newRAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, s));
        newRAttack.GetComponent<PlayerAttack>().damage = damage;
    }
}
