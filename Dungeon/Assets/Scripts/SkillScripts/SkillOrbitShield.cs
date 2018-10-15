using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOrbitShield : SkillOrbits {

    // Use this for initialization
    void Start () {
        activeSkill = false;
        maxSkillCooldown = 3f;
        maxOrbits = 3;
        radius = 2f;
        orbitObject = (GameObject)Resources.Load("Shield");
        power = 1f;
        speed = -4f;
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