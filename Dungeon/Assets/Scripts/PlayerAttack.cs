using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float delay = 0;     //Delay give the option for aoe damage timer starts after isDying is triggered
    public bool isDying = false;//Refer to testScene and SkillMine for an example
    private bool isQuitting = false;

    private float timeToDeath;

    private void Start()
    {
        timeToDeath = delay;
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsBreakableEnemy(other))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            if (!isDying)
            {
                DestroyDelay();
            }
        }
    }

    private static bool IsBreakableEnemy(Collider2D other)
    {
        return other.CompareTag("Enemy") || other.CompareTag("GunEnemy") || other.CompareTag("Breakable") || other.CompareTag("Levelbounds");
    }

    private void Update()
    {
        //if (!isDying)
        //    return;
        if (isDying)
        {
            timeToDeath -= Time.deltaTime;
            if (timeToDeath <= 0)
            {
                if (gameObject.GetComponent<OnDeath>() == null)
                {
                    gameObject.AddComponent<OnDeath>();
                }
                gameObject.GetComponent<OnDeath>().isDead = true;
            }
        }
    }

    private void DestroyDelay(/*float timer*/)
    {
        //if (delay <= 0)
        //{
        //    GetComponent<OnDeath>().isDead = true;
        //}

        isDying = true;
    }
}
