using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    public string holding = "";
    public List<string> foods = new List<string>();
    public List<Vector3> positions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foods.Contains(holding))
        {
            foods[foods.IndexOf(holding)] = "";
        }
    }
}
