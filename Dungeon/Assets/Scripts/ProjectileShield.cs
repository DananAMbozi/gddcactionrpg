using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class shields that can block projectiles. Their health is based on number of hits rather than how much damage
public class ProjectileShield : MonoBehaviour {

    private int hp = 1;
    public string targetTag = "EditorOnly"; // Arbitrary tag name

    public void SetTag(string handleTag)
    {
        gameObject.tag = "Attack";  // Temporary solution
        if (handleTag == "Enemy")
        {
            targetTag = "Attack";
            // gameObject.tag = "EnemyAttack";
        }
        else
        {
            targetTag = "EnemyAttack"; // Default: assume the shield is set by the player whether true or not
            // gameObject.tag = "Attack";
        }
    }

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
        if (other.CompareTag(targetTag))
        {
            Destroy(other.gameObject);
            hp -= 1;
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}
