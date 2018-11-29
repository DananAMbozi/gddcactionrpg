using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffInvincible : StatusEffect {

    private SpriteRenderer targetCharacter;
    private string originalTag;

    private void Awake()
    {
        buffName = "Mist";
    }

    void Update()
    {
        buffTimer -= 1 * Time.deltaTime;
 
        if (buffTimer <= 0)
            buffDestroy();
    }

    public override void Init()
    {
        targetCharacter = gameObject.GetComponent<SpriteRenderer>();

        //Temporary. Maybe have each character contain an internal tag that can't be changed
        if ((gameObject.tag == "Player") || (gameObject.tag == "Enemy"))
            originalTag = gameObject.transform.tag;
        else
            originalTag = "";   //Temporary. Consider changing

        buffTimer = maxBuffTimer;

        Activate();
    }

    public override void Activate()
    {
        transform.tag = "Invincible";
        targetCharacter.color = new Color(targetCharacter.color.r, targetCharacter.color.g, targetCharacter.color.b, targetCharacter.color.a - 0.7f);    //Make the character translucent
    }

    public override string buffDescription()
    {
        return buffName + ": Invincible";
    }

    public override void buffDestroy()
    {
        gameObject.transform.tag = originalTag;
        targetCharacter.color = new Color(targetCharacter.color.r, targetCharacter.color.g, targetCharacter.color.b, targetCharacter.color.a + 0.7f);  //Return the character back to normal form

        gameObject.GetComponent<BuffHandler>().RemoveBuff(this);
        Destroy(this);
    }

    public override void Stack(StatusEffect sameEffect)
    {
        buffTimer = maxBuffTimer;
    }

    public override void TransferBuff(GameObject target)
    {
    }
}
