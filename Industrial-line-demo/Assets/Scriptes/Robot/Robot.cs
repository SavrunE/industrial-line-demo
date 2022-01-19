using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Robot : MonoBehaviour
{
    private Vector3 startPosition;
    private Mover mover;
    [SerializeField] private Container targetContainer;
    [SerializeField] private CheckPoint checkPoint;
    [SerializeField] private float minimalDistanceToContainer;

    private bool canMove = true;
    public Vector3 ContainerUpPosition() => new Vector3(transform.position.x, transform.position.y - minimalDistanceToContainer, transform.position.z);

    private void Start()
    {
        mover = GetComponent<Mover>();
        startPosition = transform.position;
    }

    public void ActivateMover()
    {
        if (canMove)
            StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        canMove = false;
        float timeToMove = MoveToContainerX(targetContainer);
        yield return new WaitForSeconds(timeToMove);
        timeToMove = UpContainer();
        yield return new WaitForSeconds(timeToMove);
        timeToMove = MoveToCheckPointPosition();
        MoveContainer();
        yield return new WaitForSeconds(timeToMove);
        timeToMove = DownContainer();
        yield return new WaitForSeconds(timeToMove);
        timeToMove = MoveToStartPosition();
        yield return new WaitForSeconds(timeToMove);

        canMove = true;
    }

    public float MoveToContainerX(Container container)
    {
        targetContainer = container;
        return mover.MoveTo(ChangedXPosition(container.transform.position));
    }

    private float UpContainer()
    {
        return targetContainer.MoveTo(ContainerUpPosition());
    }

    private float MoveContainer()
    {
        Vector3 newPosition = new Vector3(checkPoint.transform.position.x, transform.position.y -  minimalDistanceToContainer, transform.position.z);

        Debug.Log(newPosition);
        return targetContainer.MoveTo(newPosition, mover.TimeToMove());
    }

    private float MoveToCheckPointPosition()
    {
        return mover.MoveTo(ChangedXPosition(checkPoint.transform.position));
    }

    private float DownContainer()
    {
        return targetContainer.MoveTo(checkPoint.transform.position);
    }
    private float MoveToStartPosition()
    {
        return mover.MoveTo(ChangedXPosition(startPosition));
    }

    private Vector3 ChangedXPosition(Vector3 position)
    {
        return new Vector3(position.x, transform.position.y, transform.position.z);
    }
}
