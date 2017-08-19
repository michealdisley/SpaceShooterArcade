using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

    public SceneFader sceneFader;

    private string mainMenuScene = "Main Menu";
    private string pauseMenuScene = "Pause Menu";
    private string levelCompleteScene = "Level Complete";
    private string gameOverScene = "Game Over";
    private string hudScene = "Hud";

    private string levelOne = "DevBuild";
    
    // Used to incement levels
    // public string nextLevel = "Level 2";
    // public int levelToUnlock = 2;

    public static bool gameIsOver;

    void Start()
    {
        // SceneManager.LoadSceneAsync(hudScene, LoadSceneMode.Additive);
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        //if (PlayerStats.Lives <= 0)
        //{
        //    EndGame();
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }

    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            SceneManager.LoadScene(pauseMenuScene, LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
        else if (Time.timeScale == 0f)
        {
            SceneManager.UnloadSceneAsync(pauseMenuScene);
            Time.timeScale = 1f;
        }
    }

    public void MainMenu()
    {
        Pause();
        sceneFader.FadeTo(mainMenuScene);
    }

    public void Restart()
    {
        if (gameIsOver)
        {
            SceneManager.UnloadSceneAsync(gameOverScene);
            sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        }
        else
            Pause();

        sceneFader.FadeTo(SceneManager.GetActiveScene().name);

    }

    //public void Continue()
    //{
    //    PlayerPrefs.SetInt("levelReached", levelToUnlock);
    //    sceneFader.FadeTo(nextLevel);
    //}

    public void EXIT()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    void EndGame()
    {
        SceneManager.LoadScene(gameOverScene, LoadSceneMode.Additive);
        gameIsOver = true;
    }

    public void WinLevel()
    {
        SceneManager.LoadScene(levelCompleteScene, LoadSceneMode.Additive);
        //Continue();
        gameIsOver = true;
        
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(levelOne, LoadSceneMode.Single);
    }
}
