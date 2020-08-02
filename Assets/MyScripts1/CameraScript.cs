using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public bool useDefaultCameraSpeed;
    public float cameraSpeed; //simple numbers.
    private float speed; //actual speed per frame. (cameraSpeed / 100)
    Vector3 currPos;
    Vector3 xPan;
    Vector3 yPan;
    void Start() {
        currPos = Camera.main.transform.position;
        if (cameraSpeed == 0.0f || useDefaultCameraSpeed) { cameraSpeed = 3.0f; }
        
        speed = cameraSpeed / 100.0f;
        xPan = new Vector3(speed, 0, 0);
        yPan = new Vector3(0, speed, 0);
    }

    void Update()
    {
        Camera.main.transform.position = currPos;
        if (Input.GetKey(KeyCode.W)) {
            Vector3.MoveTowards(currPos, currPos += yPan, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3.MoveTowards(currPos, currPos -= xPan, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3.MoveTowards(currPos, currPos -= yPan, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3.MoveTowards(currPos, currPos += xPan, speed * Time.deltaTime);
        }
    }
}
