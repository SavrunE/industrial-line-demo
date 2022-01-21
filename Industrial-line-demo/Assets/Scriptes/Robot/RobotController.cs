using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private RobotLeft robotLeft;
    [SerializeField] private RobotRight robotRight;
    [SerializeField] private float delayActivaror = 1f;
    [SerializeField] private float delaySession = 5f;

    [SerializeField] protected Container targetContainer;
    [SerializeField] protected CheckPoint checkPoint;
    [SerializeField] protected CheckPoints checkPoints;

    [SerializeField] private ActivateView activateView;
    [SerializeField] private ContainerSelecter containerSelecter;
    [SerializeField] private RobotSelecter robotSelecter;

    public void SetData()
    {

    }
    public void ActivateAvtomatMode()
    {
        DeactivateManualMode();
        StartCoroutine(AvtomatMode());
        robotSelecter.DeselectAll();
    }

    public void ActivateManualMode()
    {
        robotLeft.OnStopMoving += OnStopRobotMove;
        robotRight.OnStopMoving += OnStopRobotMove;
        DeactivateAvtomatMode();
        activateView.Activate();
        //TODO manual mode
    }

    public void DeactivateAvtomatMode()
    {
        StopCoroutine(AvtomatMode());
    }

    public void DeactivateManualMode()
    {
        robotLeft.OnStopMoving -= OnStopRobotMove;
        robotRight.OnStopMoving -= OnStopRobotMove;
        activateView.Deactivate();
    }

    private void OnStopRobotMove()
    {
        //Recharge queue
    }


    private IEnumerator AvtomatMode()
    {
        while (true)
        {
            if (TakeData())
            {
                robotLeft.ActivateMover(checkPoint, targetContainer);
            }
            yield return new WaitForSeconds(delayActivaror);
            if (TakeData())
            {
                robotRight.ActivateMover(checkPoint, targetContainer);
            }
            yield return new WaitForSeconds(delaySession);
        }
    }

    public void StartManualMode(Robot robot, Container container, CheckPoint checkPoint)
    {
        robot.ActivateMover(checkPoint, container);
    }


    private bool TakeData()
    {
        checkPoint = checkPoints.TakeFreeCheckPoint();
        if (checkPoints.TakeOccupiedCheckPoint() != null)
        {
            targetContainer = checkPoints.TakeOccupiedCheckPoint().Container;
        }
        else
        {
            targetContainer = null;
        }

        if (checkPoint != null && targetContainer != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
