using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public abstract class Robot : MonoBehaviour
{
    protected Vector3 startPosition;
    protected Mover mover;
    [SerializeField] protected Container targetContainer;
    [SerializeField] protected CheckPoint checkPoint;
    [SerializeField] protected float minimalDistanceToContainer;
    [SerializeField] protected CheckPoints checkPoints;

    protected bool canMove = true;
    public Vector3 ContainerUpPosition() => new Vector3(transform.position.x, transform.position.y - minimalDistanceToContainer, transform.position.z);

    protected void Start()
    {
        mover = GetComponent<Mover>();
        startPosition = transform.position;
    }

    protected void CheckerBlocker()
    {
        int[] indexes = new int[2];
        int i, checkIndex = 0;
        i = 0;
        foreach (var check in checkPoints.Points())
        {
            if (targetContainer.CheckPoint() == check || checkPoint == check)
            {
                indexes[i] = checkIndex;
                i++;
            }

            checkIndex++;
        }

        Debug.Log(indexes[0] + "  " + indexes[1]);
        Blockerator(indexes[0], indexes[1]);
    }

    protected virtual void Blockerator(int indexOne, int indexTwo)
    {
        throw new System.NotImplementedException();
    }

    public void ActivateMover()
    {
        if (canMove)
            StartCoroutine(Moving());
    }

    protected IEnumerator Moving()
    {
        canMove = false;
        CheckerBlocker();
        float timeToMove = MoveToContainerX(targetContainer);
        yield return new WaitForSeconds(timeToMove);
        timeToMove = UpContainer();
        yield return new WaitForSeconds(timeToMove);
        timeToMove = MoveToCheckPointPosition();
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

    protected float UpContainer()
    {
        return targetContainer.MoveTo(ContainerUpPosition());
    }

    protected float MoveContainer()
    {
        Vector3 newPosition = new Vector3(checkPoint.transform.position.x, transform.position.y - minimalDistanceToContainer, transform.position.z);
        return targetContainer.MoveTo(newPosition, mover.TimeToMove());
    }

    protected float MoveToCheckPointPosition()
    {
        MoveContainer();
        return mover.MoveTo(ChangedXPosition(checkPoint.transform.position));
    }

    protected float DownContainer()
    {
        return targetContainer.MoveTo(checkPoint.transform.position);
    }
    protected float MoveToStartPosition()
    {
        return mover.MoveTo(ChangedXPosition(startPosition));
    }

    protected Vector3 ChangedXPosition(Vector3 position)
    {
        return new Vector3(position.x, transform.position.y, transform.position.z);
    }
}
