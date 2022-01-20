using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Container : MonoBehaviour
{
    private Mover mover;
    [SerializeField] private CheckPoint checkPoint;

    public CheckPoint CheckPoint() => checkPoint;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    public float MoveTo(Vector3 endPosition)
    {
        checkPoint.UnoccupiedPosition();
        return mover.MoveTo(endPosition);
    }
    public float MoveTo(Vector3 endPosition, float timeToMove)
    {
        checkPoint.UnoccupiedPosition();
        return mover.MoveTo(endPosition, timeToMove);
    }

    public void SetCheckPoint(CheckPoint checkPoint)
    {
        this.checkPoint = checkPoint;
        checkPoint.OccupiedPosition(this);
    }
}
