using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitOnLoad(2, sceneLoadDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitOnLoad(int sceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneNumber);
    }
}
