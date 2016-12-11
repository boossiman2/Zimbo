using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SceneReLoad()
    {
        string sceneName = SceneManager.GetActiveScene().name;
		MapTileManager.FlowerCountReset ();
        SceneManager.LoadScene(sceneName);
    }

}
