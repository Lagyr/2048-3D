using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject TextGameOver;

    private void OnEnable()
    {
        Cube.GameOver += GameEnd;
    }

    private void OnDisable()
    {
        Cube.GameOver -= GameEnd;
    }

    private void GameEnd()
    {
        TextGameOver.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(GameRestart());
    }

    IEnumerator GameRestart()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
