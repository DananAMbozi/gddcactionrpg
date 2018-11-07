using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOrbitShield : SkillOrbits {

    // Use this for initialization
    void Awake()
    {
        activeSkill = false;    // This is a PASSIVE SKILL
        maxSkillCooldown = 3f;  // 3 seconds (temporary)
        skillCooldown = maxSkillCooldown;
        maxOrbits = 3;  // 3 orbits max. This value can change
        radius = 2f;    // Radius of orbital movement
        orbitObject = (GameObject)Resources.Load("Shield");
        power = 1f; // Power is used as shield health in this case. Must be converted into int
        speed = -4f;    // Speed of movement
        SetMaxOrbits(maxOrbits);
	}
	
	// Update is called once per frame
	void Update () {
		if(orbits < maxOrbits)
        {
            skillCooldown -= 1 * Time.deltaTime;
            if (skillCooldown <= 0)
            {
                skillCooldown = maxSkillCooldown;
                orbits += 1;
                // All orbits (enemies, player) end up sharing same properties if orbitObject.GetComp<> is init at Start(). Do not put at Start()
                orbitObject.GetComponent<ProjectileShield>().SetHp((int)Mathf.Round(power));
                orbitObject.GetComponent<ProjectileShield>().SetTag(gameObject.tag);
                Activate();
            }
        }
	}

    public override void DestroySkill()
    {
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Spawns a shield every" + maxSkillCooldown + " seconds. Each shield blocks " + power + " shot(s)";
    }
}