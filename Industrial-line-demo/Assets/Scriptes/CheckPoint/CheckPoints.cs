using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private List<CheckPoint> points;

    [HideInInspector]
    public List<CheckPoint> Points;

    [HideInInspector]
    public List<CheckPoint> FreePoints;

    private void Awake()
    {
        Points = TakeCheckPoints();
        FreePoints = TakeCheckPoints();
    }

    private List<CheckPoint> TakeCheckPoints()
    {
        List<CheckPoint> pointsInstance = new List<CheckPoint>();
        foreach (var point in points)
        {
            pointsInstance.Add(point);
        }
        return pointsInstance;
    }

    public CheckPoint TakeFreePoint()
    {
        CheckPoint checkPoint = FreePoints[Random.Range(0, FreePoints.Count - 1)];
        FreePoints.Remove(checkPoint);
        return checkPoint;
    }

    public void GiveFreePoint(CheckPoint checkPoint)
    {
        FreePoints.Add(checkPoint);
    }
}
