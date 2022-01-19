using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Container : MonoBehaviour
{
    private Mover mover;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }
    public float MoveTo(Vector3 endPosition)
    {
        return mover.MoveTo(endPosition);
    }
    public float MoveTo(Vector3 endPosition, float timeToMove)
    {
        return mover.MoveTo(endPosition, timeToMove);
    }
}
