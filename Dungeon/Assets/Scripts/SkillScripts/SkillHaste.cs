using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHaste : Skills
{
    /*
     * Active skill that speeds the player up by a specific amount for a bit.
     * Also gives slight red tint.
     */
    private float maxBuffTimer = 1f;

    void Awake()
    {
        skillImage = Resources.Load("Art/HasteIcon", typeof(Sprite)) as Sprite;
        activeSkill = true;
        maxSkillCooldown = 5f;
        power = 0.5f;
    }

    void Update()
    {
        skillCooldown -= 1 * Time.deltaTime;
    }

    public override void Activate()
    {
        if (skillCooldown <= 0)
        {
            BuffSpeedUp tempHaste = gameObject.AddComponent<BuffSpeedUp>();
            tempHaste.SetBuffName("Haste");   // Set the name of the buff
            tempHaste.SetBuffTimer(maxBuffTimer);    // Set the timer of the buff
            tempHaste.SetSpeedUp(power);
            tempHaste.Init();    // Call the init() for the buff class
            skillCooldown = maxSkillCooldown;
        }
    }

    public override void DestroySkill()
    {
        Destroy(this);
    }

    public override string SkillDescription()
    {
        return "Sprint for a short time.";
    }
}
