using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffForgotten : StatusEffect {

    GameObject timerTextObject;
    Text timerText;
    bool init = false;

    private void Awake()
    {
        buff = false;
        stackable = false;
        maxBuffTimer = 50f;
        buffTimer = maxBuffTimer;
        buffName = "Lost Memory";
    }

    // Update is called once per frame
    void Update () {
        buffTimer -= Time.deltaTime;

        if (buffTimer < 10f)
            timerText.color = Color.red;
        timerText.text = "Death in: " + Mathf.RoundToInt(buffTimer).ToString();

        if(buffTimer <= 0)
        {
            gameObject.GetComponent<PlayerHealth>().TakeDamage(gameObject.GetComponent<PlayerHealth>().GetHealth());
            buffDestroy();
        }
	}

    public override void Activate()
    {
    }

    public override string buffDescription()
    {
        return buffName + ": Slowly fade to nothing";
    }

    public override void buffDestroy()
    {
        Destroy(timerTextObject);
        Destroy(this);
    }

    public override void Init()
    {
  //      button = new GameObject();
   //     timer = button.AddComponent<Button>();
   //     button.transform.position = new Vector3(Camera.main.orthographicSize, Camera.main.orthographicSize + 2);
        timerTextObject = new GameObject();
        timerText = timerTextObject.AddComponent<Text>();
        timerText.alignment = TextAnchor.UpperCenter;
        Font font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        timerText.font = font;
        timerText.transform.position = new Vector3(Camera.main.orthographicSize, Camera.main.orthographicSize + 5);
        //timerText.transform.SetParent(button.transform);
        gameObject.GetComponent<DisplaySkillStatus>().AddUIElement(timerTextObject);//(button);
    }

    public override void Stack(StatusEffect sameEffect)
    {
    }

    public override void TransferBuff(GameObject target)
    {
    }
}

