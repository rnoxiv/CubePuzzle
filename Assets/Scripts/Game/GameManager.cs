using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static int currentScore;
    public static int highScore;

    public static int currentLevel;
    public static int unlockedLevel;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void CompletedLevel()
    {
        currentLevel++;
        if (currentLevel == SceneManager.sceneCountInBuildSettings)
            print("You win!");
        else
            SceneManager.LoadScene(currentLevel);
    }
}
