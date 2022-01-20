using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private RobotLeft robotLeft;
    [SerializeField] private RobotRight robotRight;
    [SerializeField] private float delayActivaror = 1f;
    [SerializeField] private float delaySession = 5f;

    public void ActivateAvtomatMode()
    {
        StartCoroutine(AvtomatMode());
    }

    public void StopAvtomatMode()
    {
        StopCoroutine(AvtomatMode());
    }

    public void ActivateManualMode()
    {
        //TODO manual mode
        StopAvtomatMode();
    }
    private IEnumerator AvtomatMode()
    {
        while (true)
        {
            robotLeft.ActivateMoverAvtomat();
            yield return new WaitForSeconds(delayActivaror);
            robotRight.ActivateMoverAvtomat();
            yield return new WaitForSeconds(delaySession);
        }
    }
}
