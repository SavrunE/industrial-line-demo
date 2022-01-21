using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSelecter : MonoBehaviour
{
    [SerializeField] private ActivateView activateViewLeft;
    [SerializeField] private ActivateView activateViewRight;
    private SelectedData selectedData;
    private ContainerSelecter containerSelecter;
    private void Start()
    {
        selectedData = GetComponent<SelectedData>();
        containerSelecter = GetComponent<ContainerSelecter>();
    }
    public void SelectLeft()
    {
        containerSelecter.ActiveContainer();
        DeselectRight();
        activateViewLeft.Activate();
        selectedData.robot = activateViewLeft.GetComponent<Robot>();  
    }
    public void SelectRight()
    {
        containerSelecter.ActiveContainer();
        DeselectLeft();
        activateViewRight.Activate();
        selectedData.robot = activateViewRight.GetComponent<Robot>();
    }
    public void DeselectLeft()
    {
        activateViewLeft.Deactivate();
    }
    public void DeselectRight()
    {
        activateViewRight.Deactivate();
    }
    public void DeselectAll()
    {
        activateViewLeft.Deactivate();
        activateViewRight.Deactivate();
    }
}
