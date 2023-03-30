using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenuMenager : MonoBehaviour
{
    [SerializeField] string creditsSceneName;
    [SerializeField] string MenuSceneName;

    public void StartGame()
    {
        SceneChanger.instance.LoadNextScene(0);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GoCredits()
    {
        SceneManager.LoadScene(creditsSceneName);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(MenuSceneName);
    }
}
