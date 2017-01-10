using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static int sceneIndex;
    private static bool finished;
    private void Start()
    {
        finished = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
    }

    public static void CompletedLevel(float finishedTime)
    {
        finished = true;
        if (Time.time >= finishedTime + 2)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneIndex++;
            print(sceneIndex);
            if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                print("You win!");
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                PlayerPrefs.SetInt("LevelCompleted", sceneIndex);
                SceneManager.LoadScene(sceneIndex);
            }
        }
            
    }

    public static bool getFinishedLevel()
    {
        return finished;
    }

    public static void newLevel()
    {
        finished = false;
    }

    //loads inputted level
    public static void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public static void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void SaveAndExit()
    {
        Application.Quit();
    }
}
