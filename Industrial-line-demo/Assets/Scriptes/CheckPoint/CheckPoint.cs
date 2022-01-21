using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivateView))]
public class CheckPoint : MonoBehaviour
{
    private bool isBlocked = false;
    private bool isOccupied = false;
    private Container container;

    public bool IsBlocked() => isBlocked;
    public bool IsOccupied() => isOccupied;
    public Container Container => container;

    private ActivateView activateView;

    private void Start()
    {
        activateView = GetComponent<ActivateView>();    
    }

    public void Activate()
    {
        activateView.Activate();
    }

    public void Deactivate()
    {
        activateView.Deactivate();
    }

    public bool CanInteraction()
    {
        if (isOccupied && isBlocked)
        {
            return true;
        }
        return false;
    }

    public void BlockPosition()
    {
        isBlocked = true;
    }

    public void UnblockPosition()
    {
        isBlocked = false;
    }

    public void OccupiedPosition(Container container)
    {
        this.container = container;
        isOccupied = true;
    }

    public void UnoccupiedPosition()
    {
        container = null;
        isOccupied = false;
    }
}

