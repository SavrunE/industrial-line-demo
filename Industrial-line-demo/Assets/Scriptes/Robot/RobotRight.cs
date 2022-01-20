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

        int i = 0;
        foreach (var check in checkPoints.Points())
        {
            if (i >= value)
            {
                check.BlockPosition();
                i++;
                Debug.Log(check + "after");
            }
        }
    }
}
