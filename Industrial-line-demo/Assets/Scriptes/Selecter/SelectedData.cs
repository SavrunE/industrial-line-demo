using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedData : MonoBehaviour
{
    public Robot robot;
    public Container container;
    public CheckPoint checkPoint;
    [SerializeField] private RobotController robotController;

    public void StartMove()
    {
        if (robot != null && container != null && checkPoint != null)
        {
            robotController.StartManualMode(robot, container, checkPoint);
        }
        robot = null;
        container = null;
        checkPoint = null;
    }
}
