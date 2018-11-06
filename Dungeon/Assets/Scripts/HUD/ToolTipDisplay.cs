using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    string skillDescription = "";
    Sprite toolTipBoxSprite;

    GameObject toolTips;
    GameObject toolTipsClone;

    public void Init(string skillDescription)
    {
        toolTips = (GameObject)Resources.Load("ToolTips");
        toolTips.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        this.skillDescription = skillDescription;
        toolTipBoxSprite = Resources.Load("Art/ToolTipBox", typeof(Sprite)) as Sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (toolTipsClone != null)
            Destroy(toolTipsClone);

        toolTipsClone = Instantiate(toolTips);
        toolTipsClone.transform.SetParent(gameObject.GetComponentInParent<Transform>(), true);
        Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
        toolTipsClone.transform.position = new Vector3(parentPosition.x - toolTipsClone.GetComponent<Image>().GetComponent<RectTransform>().rect.width / 2, parentPosition.y + gameObject.GetComponentInParent<Image>().GetComponentInParent<RectTransform>().rect.height / 2 + toolTipsClone.GetComponent<Image>().GetComponent<RectTransform>().rect.height / 2);
        toolTipsClone.GetComponentInChildren<Text>().text = skillDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (toolTipsClone != null)
            Destroy(toolTipsClone);
    }
}
