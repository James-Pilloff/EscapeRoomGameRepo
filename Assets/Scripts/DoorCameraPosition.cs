using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCameraPosition : MonoBehaviour
{
    public GameObject entranceA;
    public GameObject entranceB;
    public int roomA;
    public int roomB;
    public bool isStartingDoor;

    // Do not set: to be used by other scripts
    public float changeTime;
    public int currentRoom;

    EnterDetection statusA;
    EnterDetection statusB;

    // Start is called before the first frame update
    void Start()
    {
        statusA = entranceA.GetComponent<EnterDetection>();
        statusB = entranceB.GetComponent<EnterDetection>();
        changeTime = 1;
        if (isStartingDoor)
        {
            changeTime = 0;
        }
        currentRoom = roomA;
    }

    // Update is called once per frame
    void Update()
    {
        changeTime += Time.deltaTime;
        if (statusA.isEntered || statusB.isEntered)
        {
            changeTime = 0;
            if (statusA.isEntered && !statusB.isEntered)
            {
                currentRoom = roomA;
            }
            if (statusB.isEntered && !statusA.isEntered)
            {
                currentRoom = roomB;
            }
        }
    }
}
