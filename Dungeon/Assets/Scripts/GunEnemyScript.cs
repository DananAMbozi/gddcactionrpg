using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    double cooldown = 1;
    double cooldownElapsed = 1;

    public GameObject Waterball;

    private float speed = 750;

    private void FixedUpdate()
    {
        cooldownElapsed += Time.deltaTime;
        if (cooldownElapsed >= cooldown)
        {
            cooldownElapsed = 0;
            Attack(speed);
        }
    }

    void Attack(float s)
    {
        GameObject newRAttack = Instantiate(Waterball, transform.position, transform.rotation);
        newRAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, s));
    }
}
