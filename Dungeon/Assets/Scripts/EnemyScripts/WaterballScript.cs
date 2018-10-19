using UnityEngine;

public class WaterballScript : MonoBehaviour
{

    private int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (/*!other.CompareTag("Enemy") && !other.CompareTag("Attack") && */!other.CompareTag("low") && !other.CompareTag("collisiondetector") && !other.CompareTag("GunEnemy"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
