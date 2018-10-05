using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterballScript : MonoBehaviour {

    private int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Breakable") || other.CompareTag("Enemy"))
        {
            other.SendMessage("TakeDamageFromEnemy", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
