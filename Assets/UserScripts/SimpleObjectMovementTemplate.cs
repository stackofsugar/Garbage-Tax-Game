using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMovementTemplate : MonoBehaviour
{
    public static void SimpleMove(Vector3 initialPos, float acceleration)
    {

    }
    public static void EasedMove(Transform movedObject, Vector3 destinationPosition, float desiredDurationInSeconds)
    {
        Vector3 initialPosition = movedObject.position;
        for(float time = 0.0f; time <= 1.0f; time += Time.deltaTime / desiredDurationInSeconds)
        {
            Debug.Log(Time.deltaTime);
            movedObject.position = Vector3.Lerp(initialPosition, destinationPosition, Mathf.SmoothStep(0.0f, 1.0f, time));
        }
    }
}
