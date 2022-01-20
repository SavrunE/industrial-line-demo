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
        foreach (var check in checkPoints.Points)
        {
            if (i <= value)
            {
                check.BlockPosition();
                i++;
                Debug.Log(check);
            }
        }
    }
}
