using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timeText;
    public Text movesText;
    public GameObject timerObject;
    public GameObject movesCountObject;
    public GameObject invalidMove;
    public static GameObject temp;

    float time = 0;
    public static int moves = 0;

    void Start()
    {
        temp = invalidMove;
        timerObject.SetActive(true);
        movesCountObject.SetActive(true);
    }

    void Update()
    {
        time += Time.deltaTime;
        Timer(time);
        MovesCount();
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

    public static IEnumerator InvalidMoves()
    {
        temp.SetActive(true);
        yield return new WaitForSeconds(3);
        temp.SetActive(false);
    }

}
