using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameObject[] pauseObjects;
    GameObject[] optionsObjects;

    public float startTime;
    public Text timeText;

    private float timeLeft;
    private Animator anim;
    private string currentTime;
    // Use this for initialization
    void Start () {
        timeLeft = startTime;
        GameManager.newLevel();
        Time.timeScale = 1;
        anim = gameObject.transform.Find("Time").gameObject.GetComponent<Animator>();
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPaused");
        optionsObjects = GameObject.FindGameObjectsWithTag("showOnOptions");
        hidePaused();
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.getFinishedLevel())
        {
            startTime -= Time.deltaTime;        
            timeLeft = Mathf.Ceil(startTime);
        }


        anim.SetFloat("time",timeLeft);
        currentTime = string.Format("{0:0}", timeLeft);
        timeText.text = currentTime;

        if (startTime <= 0)
        {
            startTime = 0;
            SceneManager.LoadScene("MainMenu");
        }

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
                Time.timeScale = 1;
                hidePaused();
            }
        }
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
        GameManager.LoadLevel(level);
    }

    public void Reload()
    {
        GameManager.Reload();
    }

    public void SaveAndExit()
    {
        GameManager.SaveAndExit();
    }
}
