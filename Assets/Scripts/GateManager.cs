using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public Vector3 speed;
    public float yMax;
    public GameObject calendar;
    public List<GameObject> marks = new List<GameObject>();
    public List<bool> correctMarks = new List<bool>();

    Vector3 pos;
    Vector3 start;
    bool opened;
    bool correct;

    float round(float num)
    {
        return Mathf.Round(num*16)/16;
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = Vector3.zero;
        start = transform.position;
        correct = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!calendar.GetComponent<SpriteRenderer>().enabled)
        {
            opened = true;
            if (!correct)
            {
                for (int index = 0; index < 31; index++)
                {
                    if (correctMarks[index] != marks[index].GetComponent<XManager>().on)
                    {
                        opened = false;
                    }
                }
            }
            if (opened)
            {
                correct = true;
            }
        }

        if (correct && pos.y < yMax)
        {
            pos += speed*Time.deltaTime;
            transform.position = new Vector3(round(pos.x), round(pos.y), round(pos.z))+start;
        }
    }
}