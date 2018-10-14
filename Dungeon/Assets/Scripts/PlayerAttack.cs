using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float delay = 0;     //Delay give the option for aoe damage timer starts after isDying is triggered
    public bool isDying = false;//Refer to testScene and SkillMine for an example

    private float timeToDeath;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsBreakableEnemy(other))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            DestroyDelay(delay);
        }
    }

    private static bool IsBreakableEnemy(Collider2D other)
    {
        return other.CompareTag("Enemy") || other.CompareTag("Breakable");
    }

    private void Update()
    {
        if (!isDying)
            return;

        timeToDeath -= Time.deltaTime;
        if (timeToDeath <= 0)
            Destroy(gameObject);
    }

    private void DestroyDelay(float timer)
    {
        if (timer <= 0)
            Destroy(gameObject);

        isDying = true;
        timeToDeath = timer;
    }
}
