using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTower : MonoBehaviour {

    float maxCoolDownTimer = 10f;
    float coolDownTimer;
    int power = 10;
    bool enrage = false;
    float enrageRange = 10f;

	// Use this for initialization
	void Start () {
        coolDownTimer = maxCoolDownTimer;
	}
	
	// Update is called once per frame
	void Update () {
        coolDownTimer -= 1 * Time.deltaTime;

        if ((!enrage) && (gameObject.GetComponent<ObjectHealth>().health < 30))
        {
            enrage = true;
            maxCoolDownTimer = 3f;
            coolDownTimer = maxCoolDownTimer;
        }
        if (coolDownTimer <= 0)
        {
            coolDownTimer = maxCoolDownTimer;
            Activate();
        }
	}

    void Activate()
    {
        if (!enrage)
        {
            GameObject[] listOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            for(int i = 0; i < listOfEnemies.Length; i++)
            {
                listOfEnemies[i].GetComponent<ObjectHealth>().TakeDamage(-power);
            }
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if ((player != null) && (Mathf.Sqrt(Mathf.Pow(player.transform.position.x - transform.position.x, 2)  + Mathf.Pow(player.transform.position.y - transform.position.y, 2)) < enrageRange))
            {
                player.GetComponent<PlayerHealth>().TakeDamage(power);
            }
        }
    }
}
