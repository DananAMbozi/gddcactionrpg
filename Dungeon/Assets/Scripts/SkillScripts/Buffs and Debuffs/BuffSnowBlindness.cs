using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Debuff that makes the player's screen more difficult to see by adding more snow on screen for a period of time.
public class BuffSnowBlindness : StatusEffect {

    GameObject snowEmitter; // There is a snow emitter on the level that this enemy will access
    int snowAmount;

    private void Update()
    {
        buffTimer -= 1 * Time.deltaTime;
        if (buffTimer < 0)
            buffDestroy();
    }
    public override void Activate()
    {
        snowEmitter.GetComponent<SnowEmitter>().AddSnow(snowAmount);
    }

    public override string buffDescription()
    {
        return buffName + ": It seems to fall harder here";
    }

    public override void buffDestroy()
    {
        if (snowEmitter != null)
            snowEmitter.GetComponent<SnowEmitter>().AddSnow(-snowAmount);

        gameObject.GetComponent<BuffHandler>().RemoveBuff(this);
        Destroy(this);
    }

    public override void Init()
    {
        stackable = true;
        maxBuffTimer = 10f;
        buffTimer = maxBuffTimer;
        buff = false;
        buffName = "Snow Blindness";
        snowAmount = Random.Range(10, 25);
        snowEmitter = GameObject.FindGameObjectWithTag("SnowEmitter");

        if (snowEmitter == null)
            Destroy(this);
        Activate();
    }

    public override void Stack(StatusEffect sameEffect)
    {
    }

    public override void TransferBuff(GameObject target)
    {
    }
}
