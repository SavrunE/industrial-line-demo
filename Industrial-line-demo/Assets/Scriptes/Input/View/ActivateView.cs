using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateView : MonoBehaviour
{
    [SerializeField] private Viewer viewer;

    private void Start()
    {
        Deactivate();
    }
    public void Activate()
    {
        viewer.gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        viewer.gameObject.SetActive(false);
    }
}
