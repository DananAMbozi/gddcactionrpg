using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Freeze status effect that disables player movement and skills. (Untested on enemies)
public class BuffFreeze : StatusEffect {

    SpriteRenderer freezeEffect;

    private void Awake()
    {
        buff = false;
        stackable = false;
        buffName = "Freeze";
        maxBuffTimer = 3f;  // 3 seconds. Always want it at 3 seconds?
        buffTimer = maxBuffTimer;
    }

    private void Update()
    {
        buffTimer -= Time.deltaTime;

        if (buffTimer <= 0)
            buffDestroy();
    }

    public override void Activate()
    {
        // Change the colour of the player to a light blue, disable movement and skills for a duration
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
        // Re-enable movement and skills, change colour back
        freezeEffect.color = freezeEffect.color - new Color(-0.5f, -0.5f, 0f);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<PlayerSkillSet>().enabled = true;
        gameObject.GetComponent<BuffHandler>().RemoveBuff(this);
        Destroy(this);
    }

    public override void Init()
    {
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
