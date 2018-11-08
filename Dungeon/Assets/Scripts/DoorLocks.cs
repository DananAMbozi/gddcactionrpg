using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocks : MonoBehaviour
{

    public int numEnemiesInRoom = 1;
    public List<GameObject> doors = new List<GameObject>();

    void Update()
    {
        if (numEnemiesInRoom <= 0)
        {
            FindObjectWithTag("Door"); //adds doors to doors list;
            foreach (GameObject d in doors)
            {
                Destroy(d);
            }
        }
    }

    public void FindObjectWithTag(string _tag)
    {
        Transform parent = transform;
        GetChildObject(parent, _tag);
    }
    public void GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                doors.Add(child.gameObject);
            }
        }
    }

    public void SetNumEnemies(int num)
    {
        numEnemiesInRoom = num;
    }
    public void EnemyDied()
    {
        numEnemiesInRoom--;
    }
}
