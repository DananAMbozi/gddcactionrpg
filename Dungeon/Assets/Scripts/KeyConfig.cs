using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyConfig : MonoBehaviour {

    public GameObject player;
    private Text[] keyTexts;
    public InputField[] inputs;
    public Button[] buttons;
    private KeyCode[] keyInput = new KeyCode[3];
    private bool init = false;

	// Use this for initialization
	void Start () {
       // inputs = new InputField[3];
	}

    private void Update()
    {
        if (!init)
        {
            if (player != null)
            {
                init = true;
        //        keyInput = player.GetComponent<PlayerSkillSet>().GetKeys();

                for (int i = 0; i < keyInput.Length; i++)
                {
                    buttons[i].GetComponentInChildren<Text>().text = keyInput[i].ToString();
                }
            }
        }
    }

    public void SetKey(string input)
    {
        if (input.Trim(' ') == "")
            return;

        // Check if that key has been binded already
        for(int i = 0; i < keyInput.Length; i++)
        {
            if ((keyInput[i].ToString() == input.ToUpper()) || ("ASDW".Contains(input.ToUpper())))
                return;
        }

        // Assign the new key binding
        string name = EventSystem.current.currentSelectedGameObject.name;
        int tempCounter = 0;
        while (tempCounter < inputs.Length)
        {
            if (inputs[tempCounter].name == name)
            {
                inputs[tempCounter].text = input.ToUpper();
                buttons[tempCounter].GetComponentInChildren<Text>().text = input.ToUpper();
                keyInput[tempCounter] = (KeyCode)System.Enum.Parse(typeof(KeyCode), input.ToUpper());
                print((KeyCode)System.Enum.Parse(typeof(KeyCode), input.ToUpper()));
                //player.GetComponent<PlayerSkillSet>().SetKeys(keyInput);
                tempCounter = inputs.Length;
                return;
            }
        }
    }
}
