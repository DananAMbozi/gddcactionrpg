using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSkillSwap : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("SwapSkill", SkillAssigner.SkillNames.TESTFIREBALL, SendMessageOptions.DontRequireReceiver);
        }
    }
}
