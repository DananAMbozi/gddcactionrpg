using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestRuntimeSceneCreation : MonoBehaviour {
    //test stuff, comments inaccurate

    private Map map;
    public GameObject walls; //from walls folder, note walls outdated (mismatch camera)
    //these are just for collision
    public GameObject dynamicLevelBounds; //from mapgen folder, these store player x,y on map
                                          //still only support one size room
                                          // Use this for initialization
    void Start () {
        Instantiate(walls, new Vector3(20, 10,0), Quaternion.identity);
        SceneManager.CreateScene("test");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("test"));
        Instantiate(walls, Vector3.zero, Quaternion.identity);
        GameObject newLevelBounds = Instantiate(dynamicLevelBounds, Vector3.zero, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
