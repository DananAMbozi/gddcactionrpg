using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("collisiondetector") && !other.CompareTag("Player") && !other.CompareTag("Attack") && !other.CompareTag("low") && !other.CompareTag("collisiondetector"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
