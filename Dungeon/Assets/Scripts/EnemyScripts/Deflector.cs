using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy that is summoned by the snow boss. W.I.P.
public class Deflector : MonoBehaviour {

    Rigidbody2D reflect;    // Used to obtain the rigidbody of the projectile so that its force can be manipulated
    Transform reflectAngle; // Used to obtain the transform of the projectile so that its rotation can be manipulated
    float life = 10f;
	
	// Update is called once per frame
	void Update () {
        life -= Time.deltaTime;
        if (life <= 0)
            Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // May make bouncing more realistic (consider change in momentum etc) some time later
        if (collision.tag == "Attack")
        {
            reflect = collision.GetComponent<Rigidbody2D>();
            reflect.velocity = -reflect.velocity;   // Bounce directly back

            // If non-zero velocity
            if (reflect.velocity != Vector2.zero)
            {
                reflectAngle = collision.GetComponent<Transform>();
                reflectAngle.eulerAngles = reflectAngle.eulerAngles + 180f * Vector3.back;
            }
        }
    }
}
