using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage = 10;
    public float delay = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Breakable"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Debug.Log(damage);
            if (delay <= 0)
            {
                endAttack();
            }

            else
            {
                destroyDelay(delay);
            }
        }
    }

    public void endAttack()
    {
        Destroy(gameObject);
        Debug.Log("1");
    }

    public void destroyDelay(float timer)
    {
        if (timer <= 0)
        {
            endAttack();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
