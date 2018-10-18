using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public bool selfDestruct = false;
    public float diameterOfObject = 1;
    private float tE = 0;
    private float tF = 0;
    private bool exploding = false;
    private float scale = 1;
    private bool finishedExploding = false;

    void Start()
    {
        diameterOfObject = gameObject.GetComponent<Renderer>().bounds.size.x;
    }

    public void Explode()
    {
        exploding = true;
        gameObject.GetComponent<ChasePlayer>().StopChasing();
    }

    void Update()
    {
        if (exploding)
        {
            tE += Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1) * (1 + 0.5f * tE * tE * Mathf.Sin(5 * tE * (1 - Mathf.Pow(tE, 1.25f))));
            if (tE >= 1.87)
            {
                scale = (1 + 0.5f * tE * tE * Mathf.Sin(5 * tE * (1 - Mathf.Pow(tE, 1.25f))));
                if (selfDestruct)
                {
                    Destroy(gameObject);
                }
                exploding = false;
                finishedExploding = true;
            }
        }

        if (finishedExploding)
        {
            tE = 0;
            scale -=  Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1) * scale;
            if (scale <= 1)
            {
                scale = 1;
                transform.localScale = new Vector3(1, 1, 1);
                finishedExploding = false;
                gameObject.GetComponent<ChasePlayer>().StartChasing();
                tF = 0;
            }
        }
    }
}
