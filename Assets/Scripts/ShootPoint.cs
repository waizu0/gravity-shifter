using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        

    }
}
