using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject Sword;

    private GameObject sword;

    private float ms;
    private float atkcd;
    private int damage;
    private float cd;
    private float Matkcd;
    private int Mdamage;
    private float Mcd;

    public void Start()
    {
//<<<<<<< HEAD
        ms = PlayerStats.atkMS;
        damage = PlayerStats.damage;
        atkcd = PlayerStats.atkCD;
        if (ms == 0)
        {
            ms = 1500;
            damage = 100;
            atkcd = 0.5f;
        }
        if (Matkcd == 0)
        {
            Mdamage = 20;
            Matkcd = 0.5f;
        }
//=======
//        speed = 750f;// PlayerStats.atkspeed;
//        damage = 9001; //PlayerStats.damage;
//>>>>>>> e406dd28007d45dd390ba28e892c8eed66e76a7a
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Space") > 0 && cd <= 0) //tempChanging to key down Input.GetKeyDown(KeyCode.Space)
        {
            Attack(ms);
            cd = atkcd;
        }


        else
        {
            cd -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Z) && Mcd <= 0)
        {
            //sword.GetComponent<SwordAttack2>().MAttack();
            MAttack();
            Mcd = Matkcd;
        }
        else
        {
            Mcd -= Time.deltaTime;
        }
    }

    void Attack(float s)
    {
        GameObject newRAttack = Instantiate(Fireball, transform.position, transform.rotation);
        newRAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, s));
        newRAttack.GetComponent<PlayerAttack>().damage = damage;
    }

    void MAttack()
    {
        Quaternion right = Quaternion.FromToRotation(Vector3.up, Vector3.right);
        GameObject newSword = Instantiate(Sword, transform.position, right);                 //use transform.rotation later
                                                                                             //newSword.GetComponent<SwordAttack>().Mdamage = Mdamage;
    }
}
