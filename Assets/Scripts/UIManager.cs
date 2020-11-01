using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

// This script is attached to the UI gameobject
// Responsible for all UI related operations

public class UIManager : MonoBehaviour
{
    // UI objects
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
    public static int moves = 0; // number of moves

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

        // To close the instructions menu
        if (Input.anyKeyDown)
        {
            instructionsMenu.SetActive(false);
            Time.timeScale = 1;
        }

        // To open or close the pause menu
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

    // Elapsed time
    void Timer(float time)
    {
        float min = Mathf.FloorToInt(time/60);
        float sec = Mathf.FloorToInt(time%60);

        timeText.text = string.Format("Time Elapsed: " + "{0:00}:{1:00}", min, sec);
    }

    // Keeps track of moves
    void MovesCount()
    {
        movesText.text = string.Format("Moves: " + moves);
    }

    // if any rules are violated
    public IEnumerator InvalidMoves()
    {
        invalidMove.SetActive(true);
        yield return new WaitForSeconds(3);
        invalidMove.SetActive(false);
    }

    // Shows basic instructions in the beginning of the game 
    void InstructionsMenu()
    {
        instructionsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    // GameOver Menu
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
