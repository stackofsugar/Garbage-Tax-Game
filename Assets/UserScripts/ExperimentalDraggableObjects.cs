using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalDraggableObjects : MonoBehaviour
{
    Camera mainCam;

    private Vector2 screenBounds;
    private Vector3 objectPos;
    private Vector3 mouseTransformOffset;
    private float objectHeight;
    private float objectWidth;
    private bool isDragged;

    void OnMouseDown()
    {
        isDragged = true;
        mouseTransformOffset = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
    }

    void OnMouseUp()
    {
        isDragged = false;
    }

    void Start()
    {
        mainCam = Camera.main;
        isDragged = false;

        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void LateUpdate()
    {
        if (isDragged)
        {
            objectPos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            objectPos.x = Mathf.Clamp(objectPos.x - mouseTransformOffset.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            objectPos.y = Mathf.Clamp(objectPos.y - mouseTransformOffset.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            objectPos.z = 0;
            transform.position = objectPos;
        }
    }
}
