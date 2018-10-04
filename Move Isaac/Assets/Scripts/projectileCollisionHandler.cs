using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        /*if statment used to prevent projectiles from colliding with other projectiles as well as colliding with the player*/
        if (!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Projectile")) Destroy(gameObject);
    }
    
}
