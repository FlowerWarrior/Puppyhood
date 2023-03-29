using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject image_activator;
    [SerializeField] float duration = 1f;
    // image i image_activator wstaw ten sam obiekt image

    public static SceneChanger instance;

    int currentLevel = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += AnyLevelSceneLoaded;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void AnyLevelSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(fadingin());
    }

    public void LoadNextScene(float delay)
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        currentLevel++;
        StartCoroutine(LoadSceneFade(delay, currentLevel));
    }

    IEnumerator LoadSceneFade(float delay, int sceneID)
    {
        yield return new WaitForSeconds(delay);
        yield return fadingout(duration);
        SceneManager.LoadScene(sceneID, LoadSceneMode.Additive);
        
    }
    private IEnumerator fadingout(float duration = 2f)
    {
        Color start = new Color(0, 0, 0, 0);
        Color end = new Color(0, 0, 0, 1);
        yield return fading(start, end, duration);
    }
    private IEnumerator fadingin(float duration = 2f)
    {
        Color start = new Color(0, 0, 0, 1);
        Color end = new Color(0, 0, 0, 0);
        yield return fading(start, end, duration);
    }
    private IEnumerator fading(Color start, Color end, float duration = 2f)
    {
        float t = 0f;
        while (t < duration)
        {
            image_activator.SetActive(true);
            image.color = Color.Lerp(start, end, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
