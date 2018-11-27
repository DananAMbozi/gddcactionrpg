using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy class that can heal all other enemies. When health becomes low enough, it will switch to damaging the player
public class HealTower : MonoBehaviour {

    float maxCoolDownTimer = 10f;   // Cooldown for healing/damaging
    float coolDownTimer;
    int power = 10;
    bool enrage = false;    // Healing or damaging mode. Once switched to damage mode, it will remain even if healed back
    float enrageRange = 10f;    // Range of attack when enraged

	// Use this for initialization
	void Start () {
        coolDownTimer = maxCoolDownTimer;
	}
	
	// Update is called once per frame
	void Update () {
        coolDownTimer -= 1 * Time.deltaTime;

        // If health drops below 30, it will switch from healing enemies to hurting the player every 3 seconds
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
                if(listOfEnemies[i].GetComponent<ObjectHealth>() != null)
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
