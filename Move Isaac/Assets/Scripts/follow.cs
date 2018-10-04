using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*this script will cause an object to follow a specified target*/

public class follow : MonoBehaviour {

    public Transform targetTransform;
    public float movementSpeed;

    private Vector3 targetDirection;
    private Transform spritePosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        targetDirection = targetTransform.position - transform.position;
        targetDirection.Normalize();
        transform.position += targetDirection * movementSpeed;
    }
}
