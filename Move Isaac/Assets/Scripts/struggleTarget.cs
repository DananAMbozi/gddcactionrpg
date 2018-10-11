using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class struggleTarget : MonoBehaviour {

	public GameObject target;
	public bool a;

	private bool onTarget;
	private bool lastKeyHitRight;
	private int keyPressCounter;
	private float T1;
	private float T2;

	private Vector3 holdHere;

	// Use this for initialization
	void Start () {
		onTarget = false;
		lastKeyHitRight = true;
		T1 = 0;
		T2 = 0;
		keyPressCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
		}


		if(onTarget) {
			target.transform.position = holdHere;
			if (Input.GetKeyDown(KeyCode.D) && !lastKeyHitRight)
			{
				updateKeyCounter();
				lastKeyHitRight = true;
			}

			else if (Input.GetKeyDown(KeyCode.A) && lastKeyHitRight) {
				updateKeyCounter();
				lastKeyHitRight = false;
			}

			if(keyPressCounter >=10){Destroy(gameObject);}
		}
	}

	private void updateKeyCounter() {
		T1 = T2;
		T2 = Time.time;

		if(T2 - T1 < 0.5)
		{
			keyPressCounter ++;
			Debug.Log(keyPressCounter);
		}
		else {
			keyPressCounter = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(target.tag))
		{
			onTarget = true;
			holdHere = col.transform.position;
			gameObject.GetComponent<Collider2D>().enabled = false;
		}
    }
}
