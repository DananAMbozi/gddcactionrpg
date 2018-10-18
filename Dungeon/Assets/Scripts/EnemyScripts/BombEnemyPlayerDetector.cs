using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyPlayerDetector : MonoBehaviour {

    private int damage = 25;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponentInParent<Explosion>().Explode();
        }
    }
}
