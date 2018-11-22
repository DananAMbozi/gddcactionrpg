using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Similar to PlayerAttack class, which also launches a fireball. Testing purposes only
public class TestFireball : Skills {

    public GameObject fireball; //Used to create the fireball prefab

    // Use this for initialization
    void Awake()
    {
        activeSkill = true; //This is an active skill
        maxSkillCooldown = 0.5f;
        fireball = (GameObject)Resources.Load("Fireball");
        power = 10f;
        speed = 750;
	}
	
	// Update is called once per frame
	void Update () {
        skillCooldown -= Time.deltaTime;
	}

    public override void Activate(Vector3 direction)
    {
        if (skillCooldown <= 0)
        {
            //Initiate cooldown
            skillCooldown = maxSkillCooldown;

            float tempAngle = Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.y);

            //Create fireball
            GameObject newRAttack = Instantiate(fireball, transform.position, Quaternion.AngleAxis(tempAngle, Vector3.back));

            newRAttack.AddComponent<BuffHandler>();
            gameObject.GetComponent<BuffHandler>().TransferBuffs(newRAttack);

            // Had to replace AddRelativeForce with AddForce due to problems with Quaternion.rotation on instantiation
            newRAttack.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * direction.x, speed * direction.y));
            newRAttack.GetComponent<PlayerAttack>().damage = (int)power;
        }
    }

    public override void Activate()
    {
        /*
        if (skillCooldown <= 0)
        {
            //Initiate cooldown
            skillCooldown = maxSkillCooldown;

            //Create fireball
            GameObject newRAttack = Instantiate(fireball, transform.position, transform.rotation);

            // Had to replace AddRelativeForce with AddForce due to problems with Quaternion.rotation on instantiation
            newRAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, speed));
            newRAttack.GetComponent<PlayerAttack>().damage = (int)power;
        }*/
        return;
    }

    public override void DestroySkill()
    {
        //Remove self from gameobject
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Hurls a fireball dealing " + (power * 100).ToString() + "% damage";
    }
}
