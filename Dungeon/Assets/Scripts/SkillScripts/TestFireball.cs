using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Similar to PlayerAttack class, which also launches a fireball. Testing purposes only
public class TestFireball : Skills {

    public GameObject fireball; //Used to create the fireball prefab
    int playerAttack = 1;   //Temporary, pls remove
    float playerAttackSpeed = 750f; //Temporary, pls remove

    // Use this for initialization
    void Start () {
        activeSkill = true; //This is an active skill
        maxSkillCooldown = 0.5f;
        fireball = (GameObject)Resources.Load("Fireball");
        power = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        skillCooldown -= 1 * Time.deltaTime;
	}

    public override void Activate()
    {
        if (skillCooldown <= 0)
        {
            //Initiate cooldown
            skillCooldown = maxSkillCooldown;

            //Create fireball
            GameObject newRAttack = Instantiate(fireball, transform.position, transform.rotation);
            newRAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, playerAttackSpeed));
            newRAttack.GetComponent<PlayerAttack>().damage = (int)power * playerAttack;
        }
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
