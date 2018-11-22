using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEmitter : MonoBehaviour {

    GameObject snowEmitter;
    GameObject snowEmitterClone;
    GameObject blankScreen;
    GameObject blankScreenClone;
    GameObject snowBackground;

    // TEMPORARY. Let the level handler take care of artillery damage
    GameObject player;
    float artilleryTimer = 10f;
    GameObject artillery;

    int numParticles = 5;
    int maxParticles = 100;
    float alpha;

	// Use this for initialization
	void Start () {

        //Let the level handler take care of artillery damage
        player = GameObject.FindGameObjectWithTag("Player");
        artillery = (GameObject)Resources.Load("Enemies/SnowCrosshair");

        snowEmitter = (GameObject)Resources.Load("Snow");
        blankScreen = (GameObject)Resources.Load("SnowBackground");

        snowEmitterClone = Instantiate(snowEmitter);
        blankScreenClone = Instantiate(blankScreen);
        snowBackground = Instantiate(blankScreen);

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(blankScreenClone);
        DontDestroyOnLoad(snowEmitterClone);
        DontDestroyOnLoad(snowBackground);

        blankScreenClone.GetComponent<SpriteRenderer>().sortingOrder = 5;
        blankScreenClone.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        snowEmitterClone.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + Camera.main.orthographicSize * 2, 0f);
        snowEmitterClone.transform.SetParent(Camera.main.transform, true);
    }

    private void Update()
    {
        artilleryTimer -= Time.deltaTime;

        if (artilleryTimer < 0)
        {
            artilleryTimer = 10f;
            if (player != null)
            {
                GameObject artilleryClone = Instantiate(artillery, player.transform.position, Quaternion.identity);
            }
        }
    }

    public void AddSnow(int addParticles)
    {
        numParticles += addParticles;
        var eSnow = snowEmitterClone.GetComponent<ParticleSystem>().emission;
        eSnow.rateOverTime = numParticles;
        alpha = (float)(numParticles - 5) / (float)maxParticles;

        if (alpha > 1)
            alpha = 1;
        if (alpha < 0)
            alpha = 0;
        blankScreenClone.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
    }
}
