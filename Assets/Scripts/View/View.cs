using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(800,600,FullScreenMode.Windowed);
    }
}
