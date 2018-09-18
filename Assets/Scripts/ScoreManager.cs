using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    float score = 0;

    bool counting = true;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(score);

        if (counting)
        {
            score += Time.deltaTime;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void StopTimer()
    {
        counting = false;

        PlayerPrefs.SetInt("Score", Mathf.RoundToInt(score));

        //als de huidige score hoger is dan de highscore, save de score als een nieuwe highscore en zeg dat hij niet meer Submitted
        //is aan de database
        if(PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetString("NewHigh", "true");
            PlayerPrefs.SetString("Submitted", "false");
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
        else
        {
            PlayerPrefs.SetString("NewHigh", "false");
        }
    }
}
