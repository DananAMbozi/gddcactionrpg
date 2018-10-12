using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMine : Skills
{

    public GameObject mine;

    void Start()
    {
        activeSkill = true; //This is an active skill
        maxSkillCooldown = 0.5f;
        mine = (GameObject)Resources.Load("Mine");
        power = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        skillCooldown -= 1 * Time.deltaTime;
    }

    public override void Activate()
    {
        if (skillCooldown <= 0)
        {
            skillCooldown = maxSkillCooldown;
            GameObject newRAttack = Instantiate(mine, transform.position, new Quaternion(0,0,0,0));
        }
    }

    public override void DestroySkill()
    {
        //Remove self from gameobject
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Drops a mine that deals 50 damage.";
    }
}
