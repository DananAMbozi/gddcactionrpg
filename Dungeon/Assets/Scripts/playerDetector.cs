using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetector : MonoBehaviour {

    private Transform self;
    private Vector3 oldPosition;
    // Use this for initialization
    void Start () {
        self = transform.parent;
        oldPosition = self.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = self.position;
        Vector3 direction = newPosition - oldPosition;
        direction = direction.normalized;
        oldPosition = self.position;
        transform.localPosition = new Vector3(direction.y,direction.x);
    }
}
