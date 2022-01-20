using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnContainers : MonoBehaviour
{
    [SerializeField] private int containersCount;
    [SerializeField] private int containersCountRed;

    [SerializeField] private Container containerInstance;
    [SerializeField] private CheckPoints checkPoints;
    [SerializeField] private FreeContainers containers;

    private void Start()
    {
        if (containersCountRed > containersCount || containersCount > checkPoints.Points.Count - 2)
        {
            throw new System.NotImplementedException();
        }

        int i = 0;
        while (i++ < containersCount)
        {
            CheckPoint checkPoint = checkPoints.TakeFreePoint();
            GameObject containerObject = Instantiate(containerInstance.gameObject, checkPoint.transform);
            Container container = containerObject.GetComponent<Container>();
            container.SetCheckPoint(checkPoint);
            containers.ContainersList.Add(container);
        }
    }
}
