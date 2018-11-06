using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplaySkillStatus : MonoBehaviour {

    RectTransform[] imagePosition;
    RectTransform[] textPosition;
    Canvas canvas;
    RectTransform canvasPosition;
    Image[] skillImage;
    Text[] skillKey;
    public int numSkills = 3;//4;
    private GameObject player;
    private Skills[] skillList;
    private int offset = 50;
    Sprite defaultSprite;
    private float alpha;
    private GameObject parentCanv;
    private bool onCooldown = false;

    private EventSystem eventSystem;
    private GraphicRaycaster rayCaster;

    public void Init(GameObject player)
    {
        // Initialize EVERYTHING
        defaultSprite = Resources.Load("Art/ShieldBubble", typeof(Sprite)) as Sprite; // Default sprite if no skill attached
        skillImage = new Image[numSkills];  // Holds the image of the skills in UI
        imagePosition = new RectTransform[numSkills];   // Holds the position of the skill images (above)
        skillKey = new Text[numSkills]; // Text value of the keys corresponding to the skills
        textPosition = new RectTransform[numSkills];
        skillList = new Skills[numSkills];

        GameObject canv;
        GameObject textCanv;

        this.player = player;   // Assign the player to this script
        parentCanv = new GameObject();  // Create an empty game object that a canvas can attach to
        canvas = parentCanv.AddComponent<Canvas>();
        canvasPosition = canvas.GetComponent<RectTransform>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;  // Set the canvas to cover the viewable screen

        rayCaster = parentCanv.AddComponent<GraphicRaycaster>();

        for (int i = 0; i < numSkills; i++)
        {
            if (skillImage[i] != null)  // "Garbage collector"
            {
                Destroy(skillImage[i].gameObject);
                Destroy(skillKey[i].gameObject);
            }

            // Setting up the skill image UI
            canv = new GameObject();    // Create an empty gameObject that the skillImage[i] can attach to
            canv.transform.SetParent(canvas.transform, true);   // Set the canvas as the parent
            skillImage[i] = canv.AddComponent<Image>();
            canv.AddComponent<ToolTipDisplay>();

            textCanv = new GameObject();
            textCanv.transform.SetParent(canv.transform, true);
            skillKey[i] = textCanv.AddComponent<Text>();

            skillImage[i].sprite = (defaultSprite);
            imagePosition[i] = skillImage[i].GetComponent<RectTransform>();
            imagePosition[i].sizeDelta = new Vector2(40f, 40f); //Arbitrary value. Hardcoded
            imagePosition[i].transform.position = new Vector3(canvasPosition.rect.width - (i + 1) * offset, canvasPosition.rect.height / 10, 0f);

            textPosition[i] = skillKey[i].GetComponent<RectTransform>();
            textPosition[i].transform.position = imagePosition[i].transform.position;
        }
 
        GameObject eventSys = new GameObject();
        eventSystem = eventSys.AddComponent<EventSystem>();
        eventSys.transform.SetParent(canvas.transform, true);
        eventSys.AddComponent<StandaloneInputModule>();
    }

    private void Update()
    {
        if (onCooldown)
            onCooldown = DisplayCooldown();
    }

    public void skillCooldown()
    {
        onCooldown = true;
    }

    public void EquipSkill(Dictionary<KeyCode, Skills> key2Skill)
    {
        int skillNum = 0;
        foreach(KeyValuePair<KeyCode, Skills> skill in key2Skill)
        {
            if (skillNum <= numSkills)
            {
                skillKey[skillNum].text = skill.Key.ToString();
                skillList[skillNum] = skill.Value;

                if (skill.Value != null)
                {
                    if (skillList[skillNum].skillImage != null)
                        skillImage[skillNum].sprite = skill.Value.skillImage;
                    skillImage[skillNum].GetComponent<ToolTipDisplay>().Init(skill.Value.SkillDescription());
                }
                else
                {
                    skillImage[skillNum].sprite = skillList[skillNum].skillImage;
                    skillImage[skillNum].GetComponent<ToolTipDisplay>().Init("");
                }
                skillNum++;
            }
        }
    }

    public bool DisplayCooldown()
    {
        bool coolDown = false;
        for (int i = 0; i < skillList.Length; i++)
        {
            if ((skillList[i] != null) && (skillList[i].GetMaxSkillCooldown() != 0) && (skillList[i].GetSkillCooldown() > 0))
            {
                alpha = 1 - skillList[i].GetSkillCooldown() / skillList[i].GetMaxSkillCooldown();
                skillImage[i].color = new Color(1, 1, 1, alpha);
                coolDown = true;
            }
            else
                skillImage[i].color = new Color(1, 1, 1, 1);

        }
        return coolDown;
    }
}
