using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Score;
    public string ScorePrefix = string.Empty;
    public Text ScoreText = null;
    public Text GameoverText = null;
    public static GameController ThisInstance = null;

    private void Awake()
    {
        ThisInstance = null;
    }

    private void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
    }

    public static void Gameover()
    {
        if(ThisInstance.GameoverText != null)
        {
            ThisInstance.GameoverText.gameObject.SetActive(true);
        }
    }
}
