using System.Collections.Generic;
using UnityEngine;

//SAME AS CLASS PLAYERSKILLS
public class PlayerSkillSet : MonoBehaviour
{

    private Dictionary<KeyCode, Skills> key2skill = new Dictionary<KeyCode, Skills>();

    void Start()
    {
        key2skill.Add(KeyCode.Space, SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLMINE));
        key2skill.Add(KeyCode.LeftShift, SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLHASTE));
        key2skill.Add(KeyCode.E, SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLMIST));
        SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SHIELD);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            key2skill[KeyCode.Space].Activate();
        else if (Input.GetKeyDown(KeyCode.LeftShift))
            key2skill[KeyCode.LeftShift].Activate();
        else if (Input.GetKeyDown(KeyCode.E))
            key2skill[KeyCode.E].Activate();
    }

    public void SwapSkill(SkillAssigner.SkillNames skill)
    {
        SwapSkill(KeyCode.Space, skill);
    }


    private void SwapSkill(KeyCode key, SkillAssigner.SkillNames skill)
    {
        if (key2skill.ContainsKey(key))
        {
            key2skill[key] = SkillAssigner.AssignSkill(gameObject, skill);
        }
    }
}
