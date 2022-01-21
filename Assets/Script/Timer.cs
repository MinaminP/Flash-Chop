using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float gameTime = 120;
    public static bool timeRunning = false;
    public Text timerText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }

    void RunTimer()
    {
        if (timeRunning)
        {
            if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                ShowTimer(gameTime);
            }
            else
            {
                gameTime = 0;
                timeRunning = false;
                gameOverPanel.transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    void ShowTimer(float displayTime)
    {
        displayTime += 1;

        float minute = Mathf.FloorToInt(displayTime / 60);
        float second = Mathf.FloorToInt(displayTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
