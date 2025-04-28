using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLetter : MonoBehaviour
{
    public GameObject safe;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (safe.GetComponent<SpriteRenderer>().enabled && safe.GetComponent<SafeBehavior>().code.Length > index)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
