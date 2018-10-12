using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemySword : MonoBehaviour
{

    // Use this for initialization
    public GameObject Sword;
    private float coolDown = 1; //seconds
    private float coolDownCounter = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coolDownCounter -= Time.deltaTime;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && coolDownCounter <= 0)
        {
            coolDownCounter = coolDown;
            Attack();
        }
    }
    void Attack()
    {
        Quaternion right = Quaternion.FromToRotation(Vector3.up, Vector3.right);
        GameObject newSword = Instantiate(Sword, transform.position + Vector3.right, right);
        newSword.transform.SetParent(transform);
    }

}
