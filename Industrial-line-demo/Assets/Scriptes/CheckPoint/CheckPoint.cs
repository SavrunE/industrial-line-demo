using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isBlocked = false;
    private bool isOccupied = false;
    private Container container;

    public bool IsBlocked() => isBlocked;
    public bool IsOccupied() => isOccupied;
    public Container Container => container;

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

