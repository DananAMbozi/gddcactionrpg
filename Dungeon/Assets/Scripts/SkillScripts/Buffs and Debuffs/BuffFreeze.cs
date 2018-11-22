using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFreeze : StatusEffect {

    SpriteRenderer freezeEffect;

    private void Update()
    {
        buffTimer -= Time.deltaTime;

        if (buffTimer <= 0)
            buffDestroy();
    }

    public override void Activate()
    {
        freezeEffect = gameObject.GetComponent<SpriteRenderer>();
        freezeEffect.color = freezeEffect.color + new Color(-0.5f, -0.5f, 0f); 
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerSkillSet>().enabled = false;
    }

    public override string buffDescription()
    {
        return buffName + ": Frozen";
    }

    public override void buffDestroy()
    {
        freezeEffect.color = freezeEffect.color - new Color(-0.5f, -0.5f, 0f);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<PlayerSkillSet>().enabled = true;
        Destroy(this);
    }

    public override void Init()
    {
        buff = false;
        stackable = false;
        buffName = "Freeze";
        maxBuffTimer = 3f;
        buffTimer = maxBuffTimer;
        Activate();
    }

    public override void Stack(StatusEffect sameEffect)
    {
        buffTimer = maxBuffTimer;
    }

    public override void TransferBuff(GameObject target)
    {
    }
}
