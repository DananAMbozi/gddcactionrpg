using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTimeSlow : Skills {

    GameObject[] targets;
    BuffSlow slow;
    bool playerSkill = true;

    void Awake()
    {
        skillImage = Resources.Load("Art/TimeSlowIcon", typeof(Sprite)) as Sprite;
        activeSkill = true;
        maxSkillCooldown = 20f;
        power = 5f;
    }

    public override void Activate()
    {
        if(skillCooldown <= 0)
        {
            if (playerSkill)
            {
                string[] tags = { "Enemy", "Boss", "GunEnemy", "EnemyAttack" };
                ApplyDebuff(tags);
            }
            else
            {
                string[] tags = { "Player", "PlayerAttack" };
                ApplyDebuff(tags);
            }

            skillCooldown = maxSkillCooldown;
        }
    }

    private void ApplyDebuff(string[] tagName)
    {
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
