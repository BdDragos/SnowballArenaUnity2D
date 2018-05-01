using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchooser : MonoBehaviour {

    public string mainGameScene;
    public string levelAri;
    public string levelCity;
    public void goCity()
    {
        SceneManager.LoadScene(levelCity);
    }

    public void goAri()
    {
        SceneManager.LoadScene(levelAri);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(mainGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
