using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private CheckPoint[] points;

    public CheckPoint[] Points()=> points;
}
