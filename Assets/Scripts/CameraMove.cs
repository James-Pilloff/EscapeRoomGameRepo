using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject cameraManager;
    public float moveTime;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = cameraManager.GetComponent<CameraManager>().cameraTarget;
        transform.position = transform.position+(target-transform.position)*Time.deltaTime/moveTime;
    }
}
