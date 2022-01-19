using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float timeToMove;
    private Collider thisCollider;

    private Vector3 thisPosition;
   private Vector3 endPosition;

    public Action OnMoving;

    private void Start()
    {
        thisPosition = transform.position;
        //endPosition = thisPosition + new Vector3(1, 0, 0);
        thisCollider = GetComponent<Collider>();
    }
    public void MoveTo(Vector3 endPosition)
    {
        this.endPosition = endPosition;
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
    }
}