using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeContainers : MonoBehaviour
{
    [HideInInspector]
    public List<Container> ContainersList;

    public Container TakeRandomContainer()
    {
        Container container= ContainersList[Random.Range(0, ContainersList.Count - 1)];
        ContainersList.Remove(container);
        return container;
    }
}
