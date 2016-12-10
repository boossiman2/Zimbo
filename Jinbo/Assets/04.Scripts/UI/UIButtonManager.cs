using UnityEngine;
using System.Collections;

public class UIButtonManager : MonoBehaviour
{

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Return()
    {
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
