using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forgotten : MonoBehaviour {

    private BuffForgotten forgottenCurse;

    private int state;
    private int spawnBatOffset = 8;
    private float stateTimer = 3f;
    private float evasion = 0f;
    private bool damaged = false;
    private float phantomCooldown = 3f;
    private GameObject cannonDog;

    GameObject snowEmitter;
    GameObject player;
    GameObject phantom;
    GameObject reflector;
    GameObject snowBat;
    GameObject snowGrenade;
    GameObject snowMine;

    Animator anim;
    SpriteRenderer flipSprite;

	// Use this for initialization
	void Start () {
        GameObject cannon = (GameObject)Resources.Load("Enemies/CannonDog");

        cannonDog = Instantiate(cannon);

        phantom = (GameObject)Resources.Load("Enemies/Phantom");
        reflector = (GameObject)Resources.Load("Enemies/Deflector");
        snowBat = (GameObject)Resources.Load("Enemies/Snowbat");
        player = GameObject.FindGameObjectWithTag("Player");
        snowEmitter = GameObject.FindGameObjectWithTag("SnowEmitter");
        snowGrenade = (GameObject)Resources.Load("Enemies/BearGrenade");
        snowMine = (GameObject)Resources.Load("Enemies/SnowMine");

        anim = gameObject.GetComponent<Animator>();
        flipSprite = gameObject.GetComponent<SpriteRenderer>();

        if (player != null)
        {
            forgottenCurse = player.AddComponent<BuffForgotten>();
            player.GetComponent<BuffHandler>().AddBuff(forgottenCurse);
        }

        state = 0;
	}
	
	// Update is called once per frame
	void Update () {
        phantomCooldown -= Time.deltaTime;
        if ((!damaged) && (gameObject.GetComponent<ObjectHealth>().health < 50))
        {
            anim.SetBool("Damaged", true);
            damaged = true;

            if(snowEmitter != null)
            {
                snowEmitter.GetComponent<SnowEmitter>().AddSnow(35);
                Instantiate(phantom);
            }
        }

        // Set evasion chance based on how much snow there is
        gameObject.GetComponent<ObjectHealth>().SetEvasion(snowEmitter.GetComponent<SnowEmitter>().GetAlpha());

        if((phantomCooldown <= 0) && (snowEmitter.GetComponent<SnowEmitter>().GetAlpha() > 0.75f))
        {
            Instantiate(phantom);
            phantomCooldown = 3f;
        }

        switch (state)
        {
            case 0:
                stateTimer -= Time.deltaTime;

                if ((player != null) && (player.transform.position.x >= transform.position.x))
                    flipSprite.flipX = false;
                else
                    flipSprite.flipX = true;

                if (stateTimer <= 0)
                {
                    state = Random.Range(1, 5);
                    stateTimer = Random.Range(4, 6);
                }
                break;
            case 1: // Fire grenade
                anim.SetTrigger("attackState");
                state = 2;
                break;
            case 2: // Summon snow bats
                if(GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
                {
                    int spawnSide;
                    if (player.transform.position.x < Camera.main.orthographicSize)
                        spawnSide = 1;
                    else
                        spawnSide = -1;
                    GameObject snowBatClone;

                    for (int spawnEnemies = Random.Range(1, 3); spawnEnemies > 0; spawnEnemies--)
                    {
                        snowBatClone = Instantiate(snowBat, new Vector3(transform.position.x + spawnSide * spawnBatOffset, transform.position.y + Random.Range(0, 5)), transform.rotation);
                        gameObject.GetComponent<BuffHandler>().TransferBuffs(snowBatClone);
                    }
                    Instantiate(snowMine, new Vector3(Random.Range(-5, Camera.main.orthographicSize * 2 - 5), Random.Range(-5, Camera.main.orthographicSize * 2 - 5)), transform.rotation);
                }
                state = 0;
                break;
            case 3: // Spawn deflector
                Vector3 unitVector;
                if (Vector3.Distance(transform.position, player.transform.position) != 0)
                    unitVector = (player.transform.position - transform.position) / Vector3.Distance(transform.position, player.transform.position);
                else
                    unitVector = Vector3.forward;
                Instantiate(reflector, unitVector * 2, transform.rotation);
                state = 0;
                break;
            case 4: // If damaged, will spawn a phantom. Also, move to state 2
                if (damaged)
                    Instantiate(phantom);
                state = 2;
                break;
            default:
                state = 0;
                break;
        }

	}

    public void FireGrenade()
    {
        GameObject grenadeClone = Instantiate(snowGrenade, transform.position, Quaternion.identity);
        grenadeClone.GetComponent<SnowGrenade>().SetTarget(player.transform);
        gameObject.GetComponent<BuffHandler>().TransferBuffs(grenadeClone);
    }

    private void OnDestroy()
    {
        forgottenCurse.buffDestroy();
        if(cannonDog != null)
            cannonDog.GetComponent<CannonDog>().SetDeath();
        Destroy(snowEmitter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);

            if (collision.transform.position.x < transform.position.x)
                collision.transform.position += Vector3.left * 0.5f;
            else
                collision.transform.position += Vector3.right * 0.5f;
        }
    }
}
