using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsSelecter : MonoBehaviour
{
    [SerializeField] private CheckPoints checkPoints;
    private List<CheckPoint> checkPointsList = new List<CheckPoint>();

    private int currentSelecter;
    private SelectedData selectedData;

    private void Start()
    {
        selectedData = GetComponent<SelectedData>();
    }

    public void FindCheckPoint()
    {
        foreach (var item in checkPoints.NoOccupiedNoBlocked())
        {
            checkPointsList.Add(item);
        }
    }

    public void ActiveCheckPoint()
    {
        currentSelecter = 0;
        FindCheckPoint();
        if (checkPointsList.Count > currentSelecter)
        {
            checkPointsList[currentSelecter].Activate();
        }
    }

    public void SelectNextCheckPoint()
    {
        checkPointsList[currentSelecter].Deactivate();
        currentSelecter++;
        if (currentSelecter > checkPointsList.Count - 1)
        {
            currentSelecter -= checkPointsList.Count;
            checkPointsList[currentSelecter].Activate();
        }
        else
        {
            checkPointsList[currentSelecter].Activate();
        }
    }

    public void SelectBeforeCheckPoint()
    {
        checkPointsList[currentSelecter].Deactivate();
        currentSelecter--;
        if (currentSelecter < 0)
        {
            currentSelecter += checkPointsList.Count;
            checkPointsList[currentSelecter].Activate();
        }
        else
        {
            checkPointsList[currentSelecter].Activate();
        }
    }

    public void SelectThis()
    {
        checkPointsList[currentSelecter].Deactivate();
        selectedData.checkPoint = checkPointsList[currentSelecter];
    }
}
