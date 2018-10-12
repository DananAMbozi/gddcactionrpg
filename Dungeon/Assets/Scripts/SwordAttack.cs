using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{


    public int Mdamage;
    public float swingT = 0.1f;
    private GameObject player;
    private float swingDeg = 0;
    private float swingSpeed;
    private Vector3 playerDirectionV;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        swingT = PlayerStats.swingTime;
        Mdamage = PlayerStats.Mdamage;
        swingSpeed = 180 / swingT; //in deg/s
        transform.SetParent(player.transform);
    }

    // Update is called once per frame
    void Update()
    {      
        swingDeg += Time.deltaTime * swingSpeed;
        playerDirectionV = playerDirectionV + player.transform.position;
        float directionAngle = Mathf.Rad2Deg * Mathf.Tan(playerDirectionV.y / playerDirectionV.x);
        if (swingDeg > 180)
        {
            Destroy(gameObject);
            directionAngle = 0;
        }

        Vector2 direction = player.GetComponent<PlayerMovement>().movement.normalized;
        //      float directionAngle = player.GetComponent<PlayerMovement>().direction;

        //        transform.Rotate(Vector3.forward, directionAngle-90);
        //transform.Rotate(Vector3.forward, Time.deltaTime * (swingSpeed-directionAngle));
        //transform.eulerAngles = new Vector3(0, 0, swingDeg);
        //transform.Rotate(Vector3.forward, Time.deltaTime * swingSpeed/2); //idk why suddenly I have to divide by 2

        if (direction.y == 0)
        {
            direction.y = 0.01f;
        }
        Vector3 directionPerpendicular;
        if (direction.y < 0)
        {
            directionPerpendicular = (-1 / Mathf.Sqrt(1 + (direction.x / direction.y) * (direction.x / direction.y))) * new Vector3(1, -direction.x / direction.y);

        }
        else
        {
            directionPerpendicular = (1 / Mathf.Sqrt(1 + (direction.x / direction.y) * (direction.x / direction.y))) * new Vector3(1, -direction.x / direction.y);
        }
        Vector3 swing2 = new Vector3(Mathf.Cos(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.x - Mathf.Sin(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.y, Mathf.Sin(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.x + Mathf.Cos(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.y, 0);
        Vector3 swing = new Vector3(Mathf.Cos(swingDeg * Mathf.Deg2Rad), Mathf.Sin(swingDeg * Mathf.Deg2Rad));
        transform.localPosition = swing;

        transform.localRotation = Quaternion.FromToRotation(direction, swing2);

        //can either use transform.Rotate(Vector3.forward, Time.deltaTime * swingSpeed/2);
        //or Vector3 directionPerpendicular = (1 / Mathf.Sqrt(1 + (direction.x / direction.y) * (direction.x / direction.y))) * new Vector3(1, -direction.x / direction.y);
        //and Vector3 swing2 = new Vector3(Mathf.Cos(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.x - Mathf.Sin(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.y, Mathf.Sin(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.x + Mathf.Cos(swingDeg * Mathf.Deg2Rad) * directionPerpendicular.y, 0);
        //and transform.rotation = Quaternion.FromToRotation(direction, swing2);
        //want to use localRotation, but need to upate move script for that
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Attack"))
        {
            other.SendMessage("TakeDamage", Mdamage, SendMessageOptions.DontRequireReceiver);
        }
    }

}
