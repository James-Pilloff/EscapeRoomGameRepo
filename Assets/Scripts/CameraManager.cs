using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<GameObject> doors = new List<GameObject>();
    public List<Vector3> cameraPositions = new List<Vector3>();

    // Do not set: to be used by other scripts
    public Vector3 cameraTarget;

    float smallest;
    float dTime;
    int roomInd;

    // Start is called before the first frame update
    void Start()
    {
        smallest = 0;
        dTime = 0;
        roomInd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        smallest = doors[0].GetComponent<DoorCameraPosition>().changeTime;
        roomInd = doors[0].GetComponent<DoorCameraPosition>().currentRoom;
        for (int index = 1; index < doors.Count; index++)
        {
            dTime = doors[index].GetComponent<DoorCameraPosition>().changeTime;
            if (dTime < smallest)
            {
                smallest = dTime;
                roomInd = doors[index].GetComponent<DoorCameraPosition>().currentRoom;
            }
        }
    cameraTarget = cameraPositions[roomInd];
    }
}
