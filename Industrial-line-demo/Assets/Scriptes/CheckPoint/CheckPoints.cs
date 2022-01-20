using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private List<CheckPoint> checkPoints;

    public List<CheckPoint> NoOccupiedNoBlocked() => CheckNoOccupiedNoBlocked();
    public List<CheckPoint> OccupiedNoBlocked() => CheckOccupiedNoBlocked();

    private List<CheckPoint> CheckNoOccupiedNoBlocked()
    {
        List<CheckPoint> checkPointsList = new List<CheckPoint>();
        foreach (var point in checkPoints)
        {
            if (point.IsBlocked() == false && point.IsOccupied() == false)
            {
                checkPointsList.Add(point);
            }
        }
        return checkPointsList;
    }

    private List<CheckPoint> CheckOccupiedNoBlocked()
    {
        List<CheckPoint> checkPointsList = new List<CheckPoint>();
        foreach (var point in checkPoints)
        {
            if (point.IsOccupied() == true && point.IsBlocked() == false)
            {
                checkPointsList.Add(point);
            }
        }
        return checkPointsList;
    }

    private List<CheckPoint> TakeCheckPoints()
    {
        List<CheckPoint> list = new List<CheckPoint>();
        foreach (var point in checkPoints)
        {
            list.Add(point);
        }
        return list;
    }

    public List<CheckPoint> CheckPointsList() => TakeCheckPoints();

    public CheckPoint TakeFreeCheckPoint()
    {
        return TakeRandom(NoOccupiedNoBlocked());
    }

    public CheckPoint TakeOccupiedCheckPoint()
    {
        return TakeRandom(OccupiedNoBlocked());
    }

    private T TakeRandom<T>(List<T> list)
    {
        if (list.Count > 1)
        {
            T checkPoint = list[Random.Range(0, list.Count - 1)];
            list.Remove(checkPoint);
            return checkPoint;
        }
        return default;
    }
}
