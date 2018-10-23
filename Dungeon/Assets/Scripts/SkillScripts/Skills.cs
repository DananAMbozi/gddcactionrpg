using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Parent class from which all skills derive from. Activate(), SkillDescription() and DestroySkill()
 * must be overriden in child classes
 * 
 * DestroySkill() is how skill scripts will remove themselves from the gameobject. Do not remove elsewhere.
 *  */
public abstract class Skills : MonoBehaviour{
    
    protected float maxSkillCooldown;    //Cooldown of the skill
    protected float skillCooldown;    //Current cooldown of the skill
    protected float power;  //Power of the skill, whether it's dmg or healing (1.00 = 100%)
    protected float speed; //Movespeed of attack (750 for fireball, 0 for mine)
    protected bool activeSkill = true;  //Whether the skill is active or passive
   // public GameObject caster = null;

    public float GetSkillCooldown()
    {
        //Returns the current skill if on cooldown
        return skillCooldown;
    }

    public float GetMaxSkillCooldown()
    {
        //Returns the maximum cooldown of the skill
        return maxSkillCooldown;
    }
    
    public float GetPower()
    {
        //Returns the power of the skill
        return power;
    }

    public void SetMaxSkillCooldown(float cooldown)
    {
        //Sets the maximum cooldown of the skill to a new cooldown
        maxSkillCooldown = cooldown;

        //If the current skill cooldown is > max, will be brought down to max
        if (skillCooldown > maxSkillCooldown)
            skillCooldown = maxSkillCooldown;
    }

    public void AdjustCooldown(float adjustedAmount)
    {
        //Increments the current skill cooldown by the adjusted amount
        skillCooldown += adjustedAmount;
    }

    public void SetPower(float setPower)
    {
        //Sets the power of the skill
        power = setPower;
        if (power < 0)
            power = 0;
    }


    //All inherited classes will need to define what their activated effect is.
    public abstract void Activate();

    //Same as above, if angles are needed
    public virtual void Activate(Vector3 direction)
    {
        Activate();
        return;
    }

    //All inherited classes will need to write their own skill description.
    public abstract string SkillDescription();

    //If there is anything that needs to be done before destroying skill.
    public abstract void DestroySkill();
}
