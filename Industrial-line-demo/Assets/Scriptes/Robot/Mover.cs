using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float timeToMove;

    private Vector3 thisPosition;
    private Vector3 endPosition;

    public float TimeToMove() => timeToMove;
    public float MoveTo(Vector3 endPosition)
    {
        thisPosition = transform.position;
        this.endPosition = endPosition;
        StartCoroutine(Move(timeToMove));
        return timeToMove;
    }
    public float MoveTo(Vector3 endPosition, float timeToMove)
    {
        thisPosition = transform.position;
        this.endPosition = endPosition;
        StartCoroutine(Move(timeToMove));
        return timeToMove;
    }

    public IEnumerator Move(float timeToMove)
    {
        float currTime = 0f;
        while (currTime <= timeToMove)
        {
            this.transform.position = Vector3.Lerp(thisPosition, endPosition, currTime / timeToMove);
            currTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = endPosition;
    }
}