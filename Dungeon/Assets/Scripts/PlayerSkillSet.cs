using System.Collections.Generic;
using UnityEngine;

//SAME AS CLASS PLAYERSKILLS
public class PlayerSkillSet : MonoBehaviour
{

    private Dictionary<KeyCode, Skills> key2skill = new Dictionary<KeyCode, Skills>();
    private Skills[] equippedSkills = new Skills[4];
//    private KeyCode[] keyCodes = new KeyCode[3];
//    private Skills[] skills = new Skills[4];
//    private GameObject basicAttack;
    private Skills basicAttackSkill;
    private int offsetAngle = 90;    // Used to offset angles
    public Vector3 aimDirection;

    private DisplaySkillStatus skillUI;

    void Start()
    {
        skillUI = gameObject.AddComponent<DisplaySkillStatus>();//new DisplaySkillStatus();
        skillUI.Init();

//        basicAttack = (GameObject)Resources.Load("Fireball");

        /*
        // Use getaxis instead of keycode
        keyCodes[0] = KeyCode.Space;
        keyCodes[1] = KeyCode.LeftShift;
        keyCodes[2] = KeyCode.E;

        skills[0] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLMINE);
        skills[1] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLHASTE);
        skills[2] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLMIST);
        skills[3] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SHIELD);*/

        key2skill.Add(KeyCode.Space, equippedSkills[0] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLMINE));
        key2skill.Add(KeyCode.LeftShift, equippedSkills[1] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLHASTE));
        key2skill.Add(KeyCode.E, equippedSkills[2] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SKILLMIST));
        equippedSkills[3] = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.SHIELD);

        skillUI.EquipSkill(key2skill);

        basicAttackSkill = SkillAssigner.AssignSkill(gameObject, SkillAssigner.SkillNames.TESTFIREBALL);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for(int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
                skills[i].Activate();
            i = keyCodes.Length;
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            key2skill[KeyCode.Space].Activate(new Vector3(Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + offsetAngle)), Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + offsetAngle)), 0f));
            skillUI.skillCooldown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            key2skill[KeyCode.LeftShift].Activate(new Vector3(Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + offsetAngle)), Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + offsetAngle)), 0f));
            skillUI.skillCooldown();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            key2skill[KeyCode.E].Activate(new Vector3(Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + offsetAngle)), Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.z + offsetAngle)), 0f));
            skillUI.skillCooldown();
        }
        aimDirection = new Vector3(Input.GetAxisRaw("FireHorizontal"), Input.GetAxisRaw("FireVertical"), 0f);

        if (aimDirection != Vector3.zero)
            basicAttackSkill.Activate(aimDirection);
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
        skillUI.EquipSkill(key2skill);
    }

    public Dictionary<KeyCode, Skills> SkillEquips()
    {
        return key2skill;
    }
/*
    public void SetKeys(KeyCode[] keys)
    {
        keyCodes = keys;
    }

    public KeyCode[] GetKeys()
    {
        return keyCodes;
    }*/
}
