using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for status effects/buffs/debuffs. W.I.P.
public abstract class StatusEffect : MonoBehaviour {

    protected float buffTimer;    // Duration of the effect.
    protected float maxBuffTimer;
    protected bool dispellable; // If the effect can be dispelled or not in-game.
    protected bool buff = true; // Whether buff or debuff

    protected string buffName;  // Name of the buff.

    protected Skills parentSkill = null;   // The skill that assigned this buff. Can also be assigned null.

    public float GetBuffTimer()
    {
        return buffTimer;
    }

    public void SetBuffTimer(float setTimer)
    {
        maxBuffTimer = setTimer;
    }

    public string GetBuffName()
    {
        return buffName;
    }

    public void SetBuffName(string name)
    {
        buffName = name;
    }

    public abstract void Init();    //Initializing the buff
    public abstract void Activate();    // Buff effect.
    public abstract void Stack();   // What happens when another buff of the same type is applied.
    public abstract string buffDescription();   // String description of the buff.
    public abstract void buffDestroy(); // What happens when the buff duration runs out.
}
