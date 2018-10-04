using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*attach this script to any game object and it will "shoot" shootingItem using the arrow keys*/

public class Shooter : MonoBehaviour {

    public Rigidbody2D shootingItem;
    public float projectileSpeed;
    public float fireRate;
    public float projectileOffset;

    //used to keep track of last firing instance -> calculate fire rate
    private float nextFire;

    //shooting -> creating copies of a rigidbody
    private Rigidbody2D shootingItemClone;
	
    // Use this for initialization
	void Start () {
        nextFire = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time > nextFire)
        {
            //offset is used so that the projectile is not instantiated directly ontop of the player, which causes collision issues
            if (Input.GetKey(KeyCode.RightArrow))
            {
                nextFire = Time.time + fireRate;
                Vector3 offset = new Vector3(projectileOffset, 0, 0);
                shootingItemClone = Instantiate(shootingItem, transform.position + offset, Quaternion.identity);
                shootingItemClone.velocity = new Vector2(1 * projectileSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                nextFire = Time.time + fireRate;
                Vector3 offset = new Vector3(-projectileOffset, 0, 0);

                shootingItemClone = Instantiate(shootingItem, transform.position + offset, Quaternion.identity);
                shootingItemClone.velocity = new Vector2(-1 * projectileSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                nextFire = Time.time + fireRate;
                Vector3 offset = new Vector3(0, projectileOffset, 0);
                shootingItemClone = Instantiate(shootingItem, transform.position + offset, Quaternion.identity);
                shootingItemClone.velocity = new Vector2(0, 1 * projectileSpeed);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                nextFire = Time.time + fireRate;
                Vector3 offset = new Vector3(0, -projectileOffset, 0);

                shootingItemClone = Instantiate(shootingItem, transform.position + offset, Quaternion.identity);
                shootingItemClone.velocity = new Vector2(0, -1 * projectileSpeed);
            }
        }
    }
}
