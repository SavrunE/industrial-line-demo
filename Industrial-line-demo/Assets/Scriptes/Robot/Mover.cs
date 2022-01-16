using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float timeToMove;
    [SerializeField] private Collider thisCollider;

    private Vector3 thisPosition;
    private Vector3 endPosition;

    public Action OnMoving;

    public void MoveTo()
    {
        StartCoroutine(Move(timeToMove));
    }
    public IEnumerator Move(float timeToMove)
    {
        float currTime = 0;
        while (currTime <= timeToMove)
        {
            this.transform.position = Vector3.Lerp(thisPosition, endPosition, currTime / timeToMove);
            currTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
