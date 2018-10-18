using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEdamage : MonoBehaviour {

   public bool attack = true;
   public int damage = 25;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

}
