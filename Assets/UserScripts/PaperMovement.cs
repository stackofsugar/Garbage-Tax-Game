using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMovement : MonoBehaviour
{
    public AnimationCurve acurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    private Vector3 startingPosition;
    public Vector3 endingPosition = Vector3.zero;
    public float duration = 1.0f;
    private float time, step;

    void Start()
    {
        startingPosition = transform.position;
        time = 0.0f;
        step = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        step = time / duration;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, acurve.Evaluate(step));

        if(transform.position == endingPosition)
        {
            enabled = false;
        }
    }
}
