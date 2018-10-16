using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraFollow : MonoBehaviour {

    public void FollowPlayer()
    {
        GameObject camera = GameObject.Find("Main Camera");
        //camera.GetComponent<Camera>().follow = true;
        //Debug.Log(camera.GetComponent<Camera>().follow); //true, need to fix
        camera.GetComponent<Camera>().FollowOn();
        //camera.SendMessage("FollowOn", null, SendMessageOptions.DontRequireReceiver);
    }
}
