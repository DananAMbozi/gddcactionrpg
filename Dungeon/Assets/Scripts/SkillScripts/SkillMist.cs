using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMist : Skills {
    /*
     * Active skill that turns the player invincible (mist) for a set amount of time.
     * Also makes them slightly transparent.
     */

    private float maxBuffTimer = 3f;    //Temporary, may move to buff instead of skill
    //private float buffTimer = 0f;   //Temporary, may move to buff instead of skill
    //private SpriteRenderer targetCharacter;

	// Use this for initialization
	void Start () {
        activeSkill = true;
        maxSkillCooldown = 8f;
        power = 0f;
        //targetCharacter = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        skillCooldown -= 1 * Time.deltaTime;

        /*
        if (buffTimer > 0)
        {
            buffTimer -= 1 * Time.deltaTime;

            if (buffTimer <= 0)
            {
                //Change baka
                transform.tag = "Player";
                targetCharacter.color = new Color(1f, 1f, 1f, 1f);
            }
        }*/
	}

    public override void Activate()
    {
        if (skillCooldown <= 0)
        {
            //Attach the buff to the character
            BuffInvincible tempMist = gameObject.AddComponent<BuffInvincible>();
            tempMist.SetBuffName("Mist");   // Set the name of the buff
            tempMist.SetBuffTimer(maxBuffTimer);    // Set the timer of the buff
            tempMist.Init();    // Call the init() for the buff class
            skillCooldown = maxSkillCooldown;
        }
        /*
        if ((skillCooldown <= 0) && (buffTimer <= 0))
        {
            skillCooldown = maxSkillCooldown;
            buffTimer = maxBuffTimer;

            transform.tag = "Invincible";
            targetCharacter.color = new Color(1f, 1f, 1f, 0.3f);
        }*/
    }

    public override void DestroySkill()
    {
        /*
        transform.tag = "Player";
        targetCharacter.color = new Color(1f, 1f, 1f, 1f);*/
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Turns into mist for 3 seconds, avoiding all damage";
    }
}
