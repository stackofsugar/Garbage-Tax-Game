using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class DraggableGizmos : MonoBehaviour
{
    private bool isDragged;
    private Vector3 mouseTransformOffset;
    private Vector3 objectPosMove;

    public RectTransform rectTransform;
    private Vector2 delocalizedRectTransform;

    float xMin = -6.655f,
        xMax = 6.655f,
        yMin = -5f,
        yMax = 5f,
        worldPointHeight;
    
    Camera mainCamera;

    public void OnMouseDown()
    {
        isDragged = true;
        mouseTransformOffset = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) - transform.position;
    }

    public void OnMouseUp()
    {
        isDragged = false;
        Debug.Log(delocalizedRectTransform);
    }

    void Start()
    {
        // Caching mainCamera
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isDragged)
        {
            objectPosMove = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.position = new Vector3(objectPosMove.x - mouseTransformOffset.x, objectPosMove.y - mouseTransformOffset.y, 0);
            delocalizedRectTransform = transform.TransformPoint(rectTransform.rect.width, rectTransform.rect.height, 0);
            Vector3 tmpVector = transform.position;

            if(tmpVector.x < (xMin))
            {
                tmpVector.x = (xMin);
            }
            else if (tmpVector.x > xMax)
            {
                tmpVector.x = xMax;
            }
            else if (tmpVector.y < yMin)
            {
                tmpVector.y = yMin;
            }
            else if (tmpVector.y > yMax)
            {
                tmpVector.y = yMax;
            }

            transform.position = tmpVector;
        }
    }
}
