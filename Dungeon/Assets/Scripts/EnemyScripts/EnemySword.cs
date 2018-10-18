using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{

    public int sDmg = 1;
    public float swingT = 0.5f;
    private Transform self; //this is set parent in chase enemy sword script
    private float swingDeg = 0;
    private float swingSpeed;
    private Vector3 directionV;
    private Vector3 oldPosition;
    private bool hit = false;
    // Use this for initialization
    void Start()
    {
        self = transform.parent;
        swingSpeed = 180 / swingT;
        oldPosition = self.position;

    }

    // Update is called once per frame
    void Update()
    {
        swingDeg += Time.deltaTime * swingSpeed;
        directionV = directionV + self.transform.position;
        Vector3 newPosition = self.position;
        Vector3 direction3 = newPosition - oldPosition;
        oldPosition = self.position;
        Vector2 unitDirection = new Vector2(direction3.x, direction3.y).normalized;
        float directionAngle = Mathf.Rad2Deg * Mathf.Tan(directionV.y / directionV.x);
        if (swingDeg > 180)
        {
            Destroy(gameObject);
            directionAngle = 0;
            swingDeg = 0;
        }

        if (unitDirection.y == 0)
        {
            unitDirection.y = 0.001f;
        }
        Vector3 directionPerpendicular;
        if (unitDirection.y < 0)
        {
            directionPerpendicular = (-1 / Mathf.Sqrt(1 + (unitDirection.x / unitDirection.y) * (unitDirection.x / unitDirection.y))) * new Vector3(1, -unitDirection.x / unitDirection.y);

        }
        else
        {
            directionPerpendicular = (1 / Mathf.Sqrt(1 + (unitDirection.x / unitDirection.y) * (unitDirection.x / unitDirection.y))) * new Vector3(1, -unitDirection.x / unitDirection.y);
        }
        Vector3 swing2 = new Vector3(Mathf.Cos(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.x - Mathf.Sin(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.y, Mathf.Sin(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.x + Mathf.Cos(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.y, 0);
        Vector3 swing = new Vector3(Mathf.Cos(swingDeg * Mathf.Deg2Rad), Mathf.Sin(swingDeg * Mathf.Deg2Rad));
        transform.localPosition = swing;
        transform.localRotation = Quaternion.FromToRotation(unitDirection, swing2);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hit)
        {
            other.SendMessage("TakeDamage", sDmg, SendMessageOptions.DontRequireReceiver); //for some reason sends damage from stationary enemy script
            hit = true;
        }
    }
}
