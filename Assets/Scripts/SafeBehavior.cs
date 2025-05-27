using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBehavior : MonoBehaviour
{
    public string correctCode;
    public int maxLen;
    public string code;
    public bool locked;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = open && locked;
    }

    public void Reset()
    {
        code = "";
    }

    public void AddDigit(string digit)
    {
        if (code.Length < maxLen)
        {
            code += digit;
        } else
        {
            Submit();
        }
    }

    public void Submit()
    {
        if (code == correctCode)
        {
            locked = false;
        }
        Reset();
    }
}
