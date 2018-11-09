using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSnowBlindness : StatusEffect {

    GameObject snowEmitter;
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
        return "It falls harder here.";
    }

    public override void buffDestroy()
    {
        if (snowEmitter != null)
            snowEmitter.GetComponent<SnowEmitter>().AddSnow(-snowAmount);

        Destroy(this);
    }

    public override void Init()
    {
        maxBuffTimer = 10f;
        buffTimer = maxBuffTimer;
        dispellable = true;
        buff = false;
        buffName = "Snow Blindness";
        snowAmount = Random.Range(10, 25);
        snowEmitter = GameObject.FindGameObjectWithTag("SnowEmitter");

        if (snowEmitter == null)
            Destroy(this);
        Activate();
    }

    public override void Stack()
    {
    }
}
