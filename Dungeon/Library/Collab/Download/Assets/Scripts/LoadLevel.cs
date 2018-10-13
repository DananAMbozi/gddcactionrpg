using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string LeveltoLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
}
