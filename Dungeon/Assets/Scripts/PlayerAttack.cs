using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Level") && !other.CompareTag("Invincible"))
        {
            other.SendMessage("TakeDamageFromPlayer", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
