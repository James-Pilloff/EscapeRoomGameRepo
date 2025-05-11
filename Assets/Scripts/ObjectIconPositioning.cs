using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIconPositioning : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> icons = new List<GameObject>();
    public List<Vector3> positions = new List<Vector3>();
    public List<int> layers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].GetComponent<SpriteRenderer>().sortingOrder = layers[player.GetComponent<AnimationControl>().direction];
        }
        transform.localPosition = positions[player.GetComponent<AnimationControl>().direction];
    }
}
