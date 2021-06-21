using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableGizmos : MonoBehaviour
{
    private bool isDragged;
    private Vector3 mouseTransformOffset;
    private Vector3 objectPosMove;


    Camera mainCamera;

    public void OnMouseDown()
    {
        isDragged = true;
        mouseTransformOffset = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
    }

    public void OnMouseUp()
    {
        isDragged = false;
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isDragged)
        {
            objectPosMove = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.position = new Vector3(objectPosMove.x - mouseTransformOffset.x, objectPosMove.y - mouseTransformOffset.y, 0);
        }
    }
}
