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
        SceneManager.UnloadSceneAsync(MenuSceneName);
        SceneManager.LoadScene(creditsSceneName, LoadSceneMode.Additive);
    }

    public void GoMenu()
    {
        SceneManager.UnloadSceneAsync(creditsSceneName);
        SceneManager.LoadScene(MenuSceneName, LoadSceneMode.Additive);
    }
}
