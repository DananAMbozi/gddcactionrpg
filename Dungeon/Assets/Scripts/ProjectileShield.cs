using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShield : MonoBehaviour {

    private int hp = 1;

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int newHp)
    {
        hp = newHp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hp -= 1;
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}
