using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRight : Robot
{
    protected override void Blockerator(int indexOne, int indexTwo)
    {
        if (indexOne < indexTwo)
        {
            BlockAfter(indexOne);
        }
        else
        {
            BlockAfter(indexTwo);
        }
    }

    private void BlockAfter(int value)
    {
        int i = checkPoints.CheckPointsList().Count;
        foreach (var check in checkPoints.CheckPointsList())
        {
            if (i-- >= value)
            {
                check.BlockPosition();
                checkPointsBlocked.Add(check);
            }
        }
    }
}
