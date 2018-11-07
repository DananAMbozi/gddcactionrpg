using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    /* 
     * This class is used to create a pop-up tooltips box, which gives the skill description when 
     * the corresponding skill icon is hovered over on the UI.
     * This class is assigned by DisplaySkillStatus.cs, which also contains the EventSystem and RayCaster
    */

    string skillDescription = "";   // Store the description from Skills.SkillDescription()

    GameObject toolTips;    // Prefab for tooltips
    GameObject toolTipsClone;   // Clone of prefab

    public void Init(string skillDescription)
    {
        // Initialize the tooltips
        toolTips = (GameObject)Resources.Load("ToolTips");
        toolTips.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);    // Set the alpha of the image to 0.5
        this.skillDescription = skillDescription;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Destroy if exists
        if (toolTipsClone != null)
            Destroy(toolTipsClone);

        // Instantiate the tooltips prefab and place it on the canvas
        toolTipsClone = Instantiate(toolTips);
        toolTipsClone.transform.SetParent(gameObject.GetComponentInParent<Transform>(), true);
        Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
        // Offsetting the position
        toolTipsClone.transform.position = new Vector3(parentPosition.x, parentPosition.y + gameObject.GetComponentInParent<Image>().GetComponentInParent<RectTransform>().rect.height / 2 + toolTipsClone.GetComponent<Image>().GetComponent<RectTransform>().rect.height / 2);
        toolTipsClone.GetComponentInChildren<Text>().text = skillDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Destroy if exists
        if (toolTipsClone != null)
            Destroy(toolTipsClone);
    }
}
