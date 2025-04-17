using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDetection : MonoBehaviour
{
    public bool isEntered = false;
    public string playerTag;
    public float cooldown;

    float lastCollision;

    void Start()
    {
        lastCollision = cooldown;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            lastCollision = 0;
        }
    }

    void Update()
    {
        lastCollision += Time.deltaTime;
        isEntered = lastCollision < cooldown;
    }
}
