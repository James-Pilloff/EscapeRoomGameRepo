using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveManager : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public List<string> food = new List<string>();
    public List<string> cookedFood = new List<string>();
    public GameObject stove;
    public GameObject invent;
    public string contents = "";
    public int num;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = stove.GetComponent<InteractiveDetection>().isInteracting;

        if (contents == "")
        {
            if (food.Contains(invent.GetComponent<InventoryManagement>().holding))
            {
                num = 1;
            } else
            {
                num = 0;
            }
        }
        else
        {
            num = 2;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[num];
    }
}
