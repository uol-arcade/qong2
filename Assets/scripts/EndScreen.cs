using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreQuote
{
    public int score;
    public string quote;
}

public class EndScreen : MonoBehaviour
{
    public List<ScoreQuote> scoreQuotes;

    public static int endScore = 8393;

    public enum PlayMode 
    {
        Singleplayer, Multiplayer
    }

    public static PlayMode playMode = PlayMode.Singleplayer;

    public string GetStringFromScore()
    {
        var returnList = new List<string>();
        var minDist = Mathf.Infinity;

        foreach(var scoreQuote in scoreQuotes)    
        {
            var dist = Mathf.Abs(scoreQuote.score - endScore);

            if(dist < minDist)
            {
                minDist = dist;
                returnList.Clear();

                returnList.Add(scoreQuote.quote);
            }

            if(dist == minDist)
                returnList.Add(scoreQuote.quote);
        }

        return returnList[Random.Range(0, returnList.Count)];
    }


    public void ExitGame()
    {
        ResearchArcade.Navigation.ExitGame();
    }

    public void Restart()
    {
        if (playMode == PlayMode.Singleplayer)
            UnityEngine.SceneManagement.SceneManager.LoadScene("singlePlayer");

        else if (playMode == PlayMode.Singleplayer)
            UnityEngine.SceneManagement.SceneManager.LoadScene("multiPlayer");
    }

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text quoteText;

    public void Start()
    {
        scoreText.text = $"{endScore:N0}";
        quoteText.text = GetStringFromScore().ToUpper();

        StartIntro.complete = false;
    }
}
