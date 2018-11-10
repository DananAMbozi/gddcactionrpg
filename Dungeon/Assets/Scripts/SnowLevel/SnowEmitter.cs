using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEmitter : MonoBehaviour {

    GameObject snowEmitter;
    GameObject snowEmitterClone;
    GameObject blankScreen;
    GameObject blankScreenClone;

    bool init = false;
    int numParticles = 5;
    int maxParticles = 100;
    float alpha;

	// Use this for initialization
	void Start () {
        snowEmitter = (GameObject)Resources.Load("Snow");
        blankScreen = (GameObject)Resources.Load("SnowBackground");

        snowEmitterClone = Instantiate(snowEmitter);
        blankScreenClone = Instantiate(blankScreen);
        blankScreenClone.GetComponent<SpriteRenderer>().sortingOrder = 5;
        blankScreenClone.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

        snowEmitterClone.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + Camera.main.orthographicSize * 2, 0f);
        snowEmitterClone.transform.SetParent(Camera.main.transform, true);

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(blankScreenClone);
        DontDestroyOnLoad(snowEmitterClone);
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
