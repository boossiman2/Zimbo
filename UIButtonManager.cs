using UnityEngine;
using System.Collections;

public class UIButtonManager : MonoBehaviour
{
    private bool isPaused = false;
    public void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
