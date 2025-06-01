using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAppearance : MonoBehaviour
{
    public GameObject invent;
    public List<string> correct = new List<string>();
    public Vector3 appearLocation;

    bool works;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        works = true;
        for (int i = 0; i <= 4; i++)
        {
            if (invent.GetComponent<InventoryManagement>().foods[i] != correct[i])
            {
                works = false;
            }
        }
        if (works)
        {
            transform.position = appearLocation;
        }
    }
}
