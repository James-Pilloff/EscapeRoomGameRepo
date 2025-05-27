using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePart2Behavior : MonoBehaviour
{
    public bool open;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = open;
    }
}
