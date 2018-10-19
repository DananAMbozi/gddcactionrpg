using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelboundsTagger : MonoBehaviour {

	void Start () {
        foreach (Transform t in transform)
        {
            t.gameObject.tag = "Levelbounds";
        }
        gameObject.tag = "Levelbounds";
    }
}
