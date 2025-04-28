using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingView : MonoBehaviour
{
    public GameObject painting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = (painting.GetComponent<InteractiveDetection>().isInteracting);
    }
}
