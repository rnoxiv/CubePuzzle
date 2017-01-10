using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private float nextSpawn = 0;
    private float startTime;

    public AnimationCurve spawnCurve;
    public float curveLenghtInSecs = 30f;
    public float jitter = 0.25f;
    public Transform blueCube;
    public Transform redCube;

    private void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            float curvePos = (Time.time - startTime) / curveLenghtInSecs;
            if (curvePos > 1f)
            {
                curvePos = 1f;
                startTime = Time.time;
            }

            int numCubes = Mathf.RoundToInt(Random.Range(spawnCurve.Evaluate(curvePos) - 10 , spawnCurve.Evaluate(curvePos) + 10));
            for(int i = 0; i < numCubes; i++)
            {
                int cubeToSpawn = Random.Range(0, 3);
                if(cubeToSpawn < 2)
                    Instantiate(blueCube, new Vector3(Random.Range(-75, 75), Random.Range(transform.position.y, transform.position.y+100), Random.Range(transform.position.z-50, transform.position.z + 50)), new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                else
                    Instantiate(redCube, new Vector3(Random.Range(-75, 75), Random.Range(transform.position.y, transform.position.y + 100), Random.Range(transform.position.z - 50, transform.position.z + 50)), new Quaternion(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1)));
                nextSpawn = Time.time + Random.Range(0, jitter);
            }
        }
    }

    public void startNewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void loadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelCompleted"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
