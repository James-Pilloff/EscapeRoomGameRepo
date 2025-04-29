using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelAccuratePlayer : MonoBehaviour
{
    public GameObject player;
    public float accuracy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(round(player.transform.position.x), round(player.transform.position.y), round(player.transform.position.z));
    }

    float round(float num)
    {
        return Mathf.Round(num*1/accuracy)*accuracy;
    }
}
