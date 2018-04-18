using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    #region simple singleton

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public GameObject endGamePanel;
    public Text curScoreText;
    public Text bestScoreText;
    public Text endGameTitle;
    public RectTransform canvasRect;

    private Text scoreText;
    private int curScore;
    private int bestScore;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        curScore = 0;
        bestScore = PlayerPrefs.GetInt("BestScore");
        var curCirle = GameObject.FindGameObjectWithTag("Circle").GetComponent<Circle>();
        if (curCirle != null)
        {
            var screenPoint = Camera.main.WorldToScreenPoint(curCirle.transform.position);
            scoreText.rectTransform.position = screenPoint;
           
            Vector2 viewportPosition = Camera.main.WorldToViewportPoint(curCirle.transform.position);
            Vector2 worldObjectToScreenPosition = new Vector2(
                ((viewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
                ((viewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
            
            scoreText.rectTransform.anchoredPosition = worldObjectToScreenPosition;
        }
    }


    public void AddScore()
    {
        curScore++;
        scoreText.text = curScore.ToString();
        
    }


    public void ShowEndGamePanel(bool value)
    {
        if (!value)
        {
            endGamePanel.SetActive(false);
            return;
        }
        endGamePanel.SetActive(true);
        if (bestScore < curScore)
        {
            endGameTitle.text = "New Record!";
            PlayerPrefs.SetInt("BestScore", curScore);
        }
        else
        {
            endGameTitle.text = "Game Over!";
        }
        curScoreText.text = curScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }
}
