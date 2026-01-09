using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    GameObject playerObj;
    Vector3 playerPos;
    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");  //player gameObject
        cameraPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerObj.transform.position;
        transform.position = cameraPos + playerPos; //Make the camera only follow player position
    }
}
