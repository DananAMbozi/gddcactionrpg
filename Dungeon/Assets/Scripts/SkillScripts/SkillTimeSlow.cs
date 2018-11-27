using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skill that can slow down enemy and projectile movements
public class SkillTimeSlow : Skills {

    GameObject[] targets;   // List of tags to identify which side to slow
    BuffSlow slow;
    bool playerSkill = true;    // If the object activating this skill is the player or an enemy

    void Awake()
    {
        skillImage = Resources.Load("Art/TimeSlowIcon", typeof(Sprite)) as Sprite;
        activeSkill = true;
        maxSkillCooldown = 20f;
        power = 5f; // Power referring to slow duration
    }

    public override void Activate()
    {
        if(skillCooldown <= 0)
        {
            // If this skill is activated by the player
            if (playerSkill)
            {
                string[] tags = { "Enemy", "Boss", "GunEnemy", "EnemyAttack" };
                ApplyDebuff(tags);
            }
            else // If this skill is activated by an enemy
            {
                string[] tags = { "Player", "PlayerAttack" };
                ApplyDebuff(tags);
            }

            skillCooldown = maxSkillCooldown;
        }
    }

    private void ApplyDebuff(string[] tagName)
    {
        // This function finds all gameobjects with the given string[] tagName and applies the slow debuff to them
        for (int j = 0; j < tagName.Length; j++)
        {
            targets = GameObject.FindGameObjectsWithTag(tagName[j]);
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].GetComponent<BuffHandler>() != null)
                {
                    slow = targets[i].AddComponent<BuffSlow>();
                    slow.SetBuffTimer(power);
                    targets[i].GetComponent<BuffHandler>().AddBuff(slow);
                }
            }
        }
        targets = null; // Reset
    }

    public override void DestroySkill()
    {
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Slows down time for " + power + " seconds";
    }
	
	// Update is called once per frame
	void Update () {
        skillCooldown -= Time.deltaTime;
	}
}
