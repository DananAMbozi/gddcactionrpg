using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
//<<<<<<< HEAD
        if (!other.CompareTag("collisiondetector") && !other.CompareTag("Player") && !other.CompareTag("Attack") && !other.CompareTag("low") && !other.CompareTag("collisiondetector"))
//=======
        if (!other.CompareTag("Player") && !other.CompareTag("Invincible"))
//>>>>>>> e406dd28007d45dd390ba28e892c8eed66e76a7a
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
