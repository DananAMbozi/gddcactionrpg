using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SAME AS CLASS PLAYERSKILLS
public class PlayerSkillSet : MonoBehaviour {

    //If the button for the skills are pressed. Only 1 skill is activated if buttons are mashed. May change
    private int skillKey = -1;
    private Skills[] skillSlot;//Where the skills are equipped

    // Use this for initialization
    void Start () {
        skillSlot = new Skills[3];  //2 skill slots for now, may add more later
        //Attach fireball script (temporary)
        skillSlot[0] = SkillAssigner.AssignSkill(gameObject, (int)SkillAssigner.skillNames.SKILLMINE);
        //Attach mist script (temporary)
        skillSlot[1] = SkillAssigner.AssignSkill(gameObject, (int)SkillAssigner.skillNames.SKILLHASTE);
        skillSlot[2] = SkillAssigner.AssignSkill(gameObject, (int)SkillAssigner.skillNames.SKILLMIST);
    }
	
	// Update is called once per frame
	void Update () {

        //Check if either of the skill keys have been pressed (space or lshift)
        if (Input.GetKeyDown(KeyCode.Space))
            skillKey = 0;
        else if (Input.GetKeyDown(KeyCode.LeftShift))
            skillKey = 1;
        else if (Input.GetKeyDown(KeyCode.E))
            skillKey = 2;

        //Check to see if any buttons have been pressed
        if (skillKey != -1)
        {
            if (skillSlot[skillKey] != null)   //If a skill is equipped, activate it.
                skillSlot[skillKey].Activate();
            skillKey = -1;
        }
    }

    void SwapSkill(int skillIndex)
    {
        // Unused currently. Used to equip and unequip skills. Refer to comments in SkillAssigner class
        if (skillSlot[skillIndex] != null)
            skillSlot[skillIndex].DestroySkill();   //Destroy the skill script
        skillSlot[skillIndex] = SkillAssigner.AssignSkill(gameObject, skillIndex);
    }
}
