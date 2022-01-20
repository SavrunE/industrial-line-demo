using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLeft : Robot
{
    protected override void Blockerator(int indexOne, int indexTwo)
    {
        if (indexOne > indexTwo)
        {
            BlockBefore(indexOne);
        }
        else
        {
            BlockBefore(indexTwo);
        }
    }

    private void BlockBefore(int value)
    {

        int i = 0;
        foreach (var check in checkPoints.CheckPointsList())
        {
            if (i++ <= value)
            {
                check.BlockPosition();
                checkPointsBlocked.Add(check);
            }
        }
    }
}
