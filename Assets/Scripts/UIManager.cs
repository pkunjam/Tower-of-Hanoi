using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public Text timeText;
    public Text movesText;
    public Text gameOverText;
    public GameObject timerObject;
    public GameObject movesCountObject;
    public GameObject invalidMove;
    public GameObject pauseMenu;
    public GameObject instructionsMenu;
    public GameObject gameOverMenu;

    float time = 0;
    public static int moves = 0;

    void Start()
    {
        InstructionsMenu();
        timerObject.SetActive(true);
        movesCountObject.SetActive(true);
    }

    void Update()
    {
        time += Time.deltaTime;
        Timer(time);
        MovesCount();

        if (Input.anyKeyDown)
        {
            instructionsMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                return;
            }

            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    void Timer(float time)
    {
        float min = Mathf.FloorToInt(time/60);
        float sec = Mathf.FloorToInt(time%60);

        timeText.text = string.Format("Time Elapsed: " + "{0:00}:{1:00}", min, sec);
    }

    void MovesCount()
    {
        movesText.text = string.Format("Moves: " + moves);
    }

    public IEnumerator InvalidMoves()
    {
        invalidMove.SetActive(true);
        yield return new WaitForSeconds(3);
        invalidMove.SetActive(false);
    }

    void InstructionsMenu()
    {
        instructionsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        gameOverText.text = string.Format("Total " + movesText.text + Environment.NewLine + timeText.text);
        Time.timeScale = 0;

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
