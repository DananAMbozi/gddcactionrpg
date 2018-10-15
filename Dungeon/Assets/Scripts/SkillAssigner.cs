using UnityEngine;

/*
 * This class is to be used whenever equipping a skill.
 * Skill names must be added to enum skillNames whenever a skill class
 * is designed
 * */
public static class SkillAssigner
{
    public enum SkillNames { TESTFIREBALL, SKILLMIST, SKILLHASTE, SKILLMINE, SHIELD };

    /*
     * Attaches skill script corresponding to int skillID onto the character equipping the skill.
     * skillID will be obtained from skill pickup objects (not implemented yet),
     * which will contain an ID in enum skillNames of the corresponding skill.
     * 
     * eg. Fireball skill pickup object has int skillID = SkillAssigner.skillNames.TESTFIREBALL.
     * When the player equips the pickup, its skillID is passed as a parameter for this
     * function.
     * */
    public static Skills AssignSkill(GameObject character, SkillNames skill)
    {
        switch (skill)
        {
            case SkillNames.TESTFIREBALL:
                return character.AddComponent<TestFireball>();
            case SkillNames.SKILLMIST:
                return character.AddComponent<SkillMist>();
            case SkillNames.SKILLHASTE:
                return character.AddComponent<SkillHaste>();
            case SkillNames.SKILLMINE:
                return character.AddComponent<SkillMine>();
            case SkillNames.SHIELD:
                return character.AddComponent<SkillShield>();
            default:
                return null;
        }
    }
}
