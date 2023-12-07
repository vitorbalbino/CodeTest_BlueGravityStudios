using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasInputReader : MonoBehaviour
{


    public bool IsPause = false;

    private void OnPause(InputValue value)
    {
        if (IsPause) Unpause();
        else Pause();
    }


    public void Pause()
    {
        Time.timeScale = 0;
    }


    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
