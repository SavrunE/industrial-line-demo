using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    private Mode activerMode;

    public void ChangeActiveMode(Mode mode)
    {
        activerMode = mode;
    }
}
