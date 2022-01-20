using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isOccupied = false;
    private bool isBlocked = false;
    private Vector3 position;

    public bool IsOccupied() => isOccupied;

    private void Start()
    {
        position = transform.position;
    }

    public void TakePosition()
    {
        isOccupied = true;
    }

    public void LeavePosition()
    {
        isOccupied = false;
    }

    public void BlockPosition()
    {
        isBlocked = true;
    }

    public void UnblockPosition()
    {
        isBlocked = false;
    }
}

