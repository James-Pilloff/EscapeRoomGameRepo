using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public bool isLocked;
    public Collider2D lockCollider;
    public GameObject display;
    public Sprite locked;
    public Sprite unlocked;
    public Vector3 unlockShift;

    // Start is called before the first frame update
    void Start()
    {
        display.GetComponent<SpriteRenderer>().sprite = locked;
    }

    // Update is called once per frame
    void Update()
    {
        lockCollider.enabled = isLocked;
        GetComponent<Collider2D>().enabled = isLocked;
        if (!isLocked)
        {
            display.GetComponent<SpriteRenderer>().sprite = unlocked;
            display.transform.localPosition = unlockShift;
        }
    }
}
