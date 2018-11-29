using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Needs to be revisited once the number of skills (passive and active) can be confirmed
public class DisplaySkillStatus : MonoBehaviour {
    /*
     * This class is used to create the skill HUD that is displayed on the player's screen. It is a component that must be
     * attached to the player GameObject.
     * 
     * Attached by PlayerSkillSet.cs
     * */

    public int numSkills = 3;//4; The number of (active, not passive?) skills to be displayed

    // Canvas
    Canvas canvas;  // Canvas on which the UI skills will be placed
    RectTransform canvasPosition;   // Required for setting skill icons relative to the canvas
    private GameObject parentCanv;  // The gameobject that the canvas will attach to. Cannot create canvas directly

    // Skill Icons
    Image[] skillImage; // Image of the skill icons
    RectTransform[] imagePosition;  // Used for manipulation of position of skill icons on canvas
    private int offset = 50;    // Used for offsetting the image icons from each other
    Sprite defaultSprite;   // skillImage[] is assigned a default sprite if the skill does not have a sprite
    private float alpha;    // Alpha value of the skill icon is modified when on cooldown

    // Key buttons
    Text[] skillKey;    // Text that outputs the keybutton used to activate the skill
    RectTransform[] textPosition;   // Used for manipulation of position of text on skill icon on canvas
    private Font font;  // Font of the text

    private Skills[] skillList; // Skills from the player. Required to access cooldown, skill icon and skill description

    private bool onCooldown = false;    // When a skill is activated, this becomes true and the skill icons will display cooldown

    // Used to detect mouse events when hovering over the skill icons (tooltip display)
    private EventSystem eventSystem;
    private GraphicRaycaster rayCaster;

    private void Start()
    {
        DontDestroyOnLoad(parentCanv);
    }

    public void Init(int numberOfSkills = 3)
    {
        // Initialize EVERYTHING
        numSkills = numberOfSkills;
        defaultSprite = Resources.Load("Art/ShieldBubble", typeof(Sprite)) as Sprite;
        skillImage = new Image[numSkills];
        imagePosition = new RectTransform[numSkills];
        skillKey = new Text[numSkills];
        textPosition = new RectTransform[numSkills];
        skillList = new Skills[numSkills];
        font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;


        GameObject canv;    // GameObject that the image will attach to. Parent = canvas
        GameObject textCanv;    // GameObject that the keyboard text will attach to. Parent = skill icons

        // Create the canvas
        parentCanv = new GameObject();
        canvas = parentCanv.AddComponent<Canvas>();
        canvasPosition = canvas.GetComponent<RectTransform>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;  // Set the canvas to cover the viewable screen
        rayCaster = parentCanv.AddComponent<GraphicRaycaster>();    // Allow the mouse position to be translated to canvas

        for (int i = 0; i < numSkills; i++) // Create the skill icons for the UI (skills not assigned)
        {
            if (skillImage[i] != null)  // "Garbage collector"
            {
                Destroy(skillImage[i].gameObject);
                Destroy(skillKey[i].gameObject);
            }

            // Setting up the skill image UI onto the canvas
            canv = new GameObject();
            canv.transform.SetParent(canvas.transform, true);
            skillImage[i] = canv.AddComponent<Image>();
            canv.AddComponent<ToolTipDisplay>();    // Script that allows skill description to be displayed when hovered over
            skillImage[i].sprite = (defaultSprite);
            imagePosition[i] = skillImage[i].GetComponent<RectTransform>();
            imagePosition[i].sizeDelta = new Vector2(40f, 40f); //Arbitrary value. Hardcoded
            imagePosition[i].transform.position = new Vector3(canvasPosition.rect.width - (i + 1) * offset, canvasPosition.rect.height / 10, 0f);

            // Setting up the key button text
            textCanv = new GameObject();
            textCanv.transform.SetParent(canv.transform, true);
            skillKey[i] = textCanv.AddComponent<Text>();
            skillKey[i].font = font;
            skillKey[i].fontSize = 10;  // Arbitrary font size, so long as it fits within the image
            skillKey[i].alignment = TextAnchor.LowerCenter;
            textPosition[i] = skillKey[i].GetComponent<RectTransform>();
            textPosition[i].sizeDelta = new Vector2(40f, 40f);  // Arbitrary value. Hardcoded
            textPosition[i].transform.position = imagePosition[i].transform.position;
        }
 
        // Create the event system so that the UI can detect if the mouse is hovering over it (ToolTipDisplay.cs)
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
        // This function is called by the player gameobject whenever a skill button is pressed
        onCooldown = true;
    }

    public void EquipSkill(Dictionary<KeyCode, Skills> key2Skill)
    {
        // This function is called whenever the player switches skills
        int skillNum = 0;   // Temporary counter
        foreach(KeyValuePair<KeyCode, Skills> skill in key2Skill)
        {
            // For each skill icon, store the keycode and the skill, and assign the images
            if (skillNum < numSkills)
            {
                skillKey[skillNum].GetComponent<Text>().text = skill.Key.ToString();
                skillList[skillNum] = skill.Value;

                if (skill.Value != null)
                {
                    if (skillList[skillNum].skillImage != null)
                        skillImage[skillNum].sprite = skill.Value.skillImage;
                    skillImage[skillNum].GetComponent<ToolTipDisplay>().Init(skill.Value.SkillDescription());   // Since a new skill is equipped, need to re-init the tooltip
                }
                else
                {
                    // If the skill does not exist
                    skillImage[skillNum].sprite = defaultSprite;
                    skillImage[skillNum].GetComponent<ToolTipDisplay>().Init("");
                }
                skillNum++;
            }
        }
    }

    public bool DisplayCooldown()
    {
        // Called only when onCooldown == true. Returns false if all skill cooldowns have been reset. Otherwise, show skill cooldowns
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
                skillImage[i].color = new Color(1, 1, 1, 1);    // Reset the skill cooldown alpha

        }
        return coolDown;
    }

    public void AddUIElement(GameObject UIElement)
    {
        UIElement.transform.SetParent(canvas.transform, false);
    }
}
