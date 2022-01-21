using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectedData))]
public class ContainerSelecter : MonoBehaviour
{
    [SerializeField] private CheckPoints checkPoints;
    private List<Container> containers = new List<Container>();

    private int currentSelecter;

    private SelectedData selectedData;
    private void Start()
    {
        selectedData = GetComponent<SelectedData>();
    }

    public void FindContainers()
    {
        containers = new List<Container>();
        foreach (var item in checkPoints.OccupiedNoBlocked())
        {
            containers.Add(item.Container);
        }
    }

    public void ActiveContainer()
    {
        currentSelecter = 0;
        FindContainers();
        if (containers.Count > currentSelecter)
        {
            containers[currentSelecter].Activate();
        }
    }

    public void SelectNextContainer()
    {
        containers[currentSelecter].Deactivate();
        currentSelecter++;
        if (currentSelecter > containers.Count - 1)
        {
            currentSelecter -= containers.Count;
            containers[currentSelecter].Activate();
        }
        else
        {
            containers[currentSelecter].Activate();
        }
    }

    public void SelectBeforeContainer()
    {
        containers[currentSelecter].Deactivate();
        currentSelecter--;
        if (currentSelecter < 0)
        {
            currentSelecter += containers.Count;
            containers[currentSelecter].Activate();
        }
        else
        {
            containers[currentSelecter].Activate();
        }
    }

    public void SelectThis()
    {
        containers[currentSelecter].Deactivate();
        selectedData.container = containers[currentSelecter];
        CheckPointsSelecter checkPointsSelecter = GetComponent<CheckPointsSelecter>();
        checkPointsSelecter.ActiveCheckPoint();
    }
}
