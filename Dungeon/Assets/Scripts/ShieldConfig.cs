using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldConfig : MonoBehaviour {

    private SpriteRenderer colour;
    private float radius = 0f;
    private bool fullShield;
    private Vector3 offset;
    private float speed = -4f;
    public GameObject following = null;
    public SkillShield parentSkill = null;
    //private float xOffset = 0f;
    //private int orientation = 1;

    public void CreateFullShield(bool fullShield)
    {
        this.fullShield = fullShield;
        if (!fullShield)
        {
            Sprite shieldSprite = gameObject.GetComponent<Sprite>();
            shieldSprite = Resources.Load<Sprite>("Box");
            radius = 2f;
            if (following != null)
            {
                //gameObject.transform.position = following.transform.position + new Vector3(2f, 0f, 0f);
                offset = following.transform.position;
            }
            //xOffset = radius;
        }
    }
	// Use this for initialization
	void Start () {
        colour = gameObject.GetComponent<SpriteRenderer>();
        colour.color = new Color(1f, 1f, 1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

        if (colour.color.a > 0.5f)
        {
            colour.color -= new Color(0f, 0f, 0f, 0.5f);
            if (colour.color.a < 0.5f)
                colour.color = new Color(1f, 1f, 1f, 0.5f);
        }

        /*
        //Homemade circle maths. Works but doesn't handle float values well
        xOffset += orientation * 0.1f;
        if (Mathf.Abs(xOffset) >= radius)
        {
            xOffset = radius * orientation;
            orientation = -orientation;
        }
        gameObject.transform.position = following.transform.position + new Vector3(xOffset, orientation * Mathf.Sqrt(Mathf.Pow(radius,2) - Mathf.Pow(xOffset,2)), -3f);
        */

        //Unity circle maths
        if (following != null)
        {
            gameObject.transform.position += (following.transform.position - offset);
            offset = following.transform.position;
            gameObject.transform.RotateAround(following.transform.position, Vector3.forward, speed);
        }
        else
            Destroy(gameObject);
	}

    public float GetAngle()
    {
        Vector3 test = Vector3.right;
     //   print(Vector3.Angle(gameObject.transform.position, test));
        if (gameObject.transform.position.y < following.transform.position.y)
            return 360 - Vector3.Angle(gameObject.transform.position, test);
        return Vector3.Angle(gameObject.transform.position, test);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        colour.color = new Color(1f, 1f, 1f, 0.8f);
        if (parentSkill != null)
            //Subtract self
    }*/
}
