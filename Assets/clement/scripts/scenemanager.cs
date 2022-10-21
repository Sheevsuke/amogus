using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
   public void loadFirstScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void loadCredit()
    {
        SceneManager.LoadScene(2);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }

}
