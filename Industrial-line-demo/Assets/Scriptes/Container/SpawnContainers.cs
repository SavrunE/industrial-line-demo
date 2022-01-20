using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnContainers : MonoBehaviour
{
    [SerializeField] private int containersCount;
    [SerializeField] private int containersCountRed;

    [SerializeField] private Container containerInstance;
    [SerializeField] private CheckPoints checkPoints;

    private void Start()
    {
        if (containersCountRed > containersCount)
        {
            throw new System.NotImplementedException();
        }
    }
}
