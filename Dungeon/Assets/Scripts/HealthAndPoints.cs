using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthAndPoints : MonoBehaviour {

    bool TextExists;
    public Text textbox;
    // Use this for initialization

    //void OnLevelWasLoaded()
    //{
    //    Scene currentScene = SceneManager.GetActiveScene();

    //    string sceneName = currentScene.name;

    //    var targetObj: Transform;

    //    if (sceneName != "Menu")
    //    {
    //        ScriptName targetScript = targetObj.GetComponent<ScriptName>();
    //    }
    //}
    void Start() {
        if (!TextExists)
        {
            TextExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        textbox = GetComponent<Text>();
    }   
	
	// Update is called once per frame
	void Update () {
        textbox.text = "Health: " + PlayerHealth.health;
    }
}
