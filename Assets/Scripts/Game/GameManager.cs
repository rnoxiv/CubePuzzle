using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    GameObject[] pauseObjects;
    GameObject[] optionsObjects;
    public static int currentScore;
    public static int highScore;

    public static int currentLevel = 1;
    public static int unlockedLevel;

    private void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPaused");
        optionsObjects = GameObject.FindGameObjectsWithTag("showOnOptions");
        hidePaused();
        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    public static void CompletedLevel()
    {
        currentLevel++;
        if (currentLevel == SceneManager.sceneCountInBuildSettings)
            print("You win!");
        else
            SceneManager.LoadScene(currentLevel);
    }

    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reload()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void SaveAndExit()
    {
        Application.Quit();
    }
}
