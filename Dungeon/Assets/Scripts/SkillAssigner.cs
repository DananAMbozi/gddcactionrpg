using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SkillAssigner{

    /*
     * This class is to be used whenever equipping a skill.
     * Skill names must be added to enum skillNames whenever a skill class
     * is designed
     * */

    public enum skillNames{TESTFIREBALL, SKILLMIST, SKILLHASTE, SKILLMINE};

    public static Skills AssignSkill(GameObject character, int skillID)
    {
        /*
         * Attaches skill script corresponding to int skillID onto the character equipping the skill.
         * skillID will be obtained from skill pickup objects (not implemented yet),
         * which will contain an ID in enum skillNames of the corresponding skill.
         * 
         * eg. Fireball skill pickup object has int skillID = SkillAssigner.skillNames.TESTFIREBALL.
         * When the player equips the pickup, its skillID is passed as a parameter for this
         * function.
         * */
        switch(skillID)
        {
            case (int)skillNames.TESTFIREBALL:
                return character.AddComponent<TestFireball>();
            case (int)skillNames.SKILLMIST:
                return character.AddComponent<SkillMist>();
            case (int)skillNames.SKILLHASTE:
                return character.AddComponent<SkillHaste>();
            case (int)skillNames.SKILLMINE:
                return character.AddComponent<SkillMine>();
            default:
                return null;
        }
    }
}
