using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public FloatVariable score;
    public FloatVariable highScore;
    public BoolVariable playerAlive;
    bool visible;

    public Image medalImage;
    public Sprite bronzeStar;
    public Sprite silverStar;
    public Sprite goldStar;
    
    public int goldMinScore;
    public int silverMinScore;

    public Text newHighScoreLabel;

    void Awake()
    {
        transform.localScale=Vector3.zero;
        score.SetValue(0);

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore.value = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
    }

    void FixedUpdate() 
    {
        if(playerAlive.value==true)
        {
            if(Time.timeScale>0)
            {
                score.ApplyChange(Mathf.Ceil(Time.deltaTime * 10));   
                       
            }
        }
        else if(visible!=true)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
       visible = true;
       Time.timeScale = 0f;
       
       if(score.value > goldMinScore)
       {
           medalImage.sprite = goldStar;
       }
       else if(score.value > silverMinScore)
       {
           medalImage.sprite = silverStar;
       }
       else
       {
           medalImage.sprite = bronzeStar;
       }
        
       if(score.value < highScore.value)
        {
           newHighScoreLabel.transform.localScale = Vector3.zero;
        }
       else
        {
            highScore.SetValue(score.value);
            PlayerPrefs.SetFloat("HighScore", score.value);
        }

        transform.localScale = new Vector3(1,1,1);

    }

    public void ReloadScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       Debug.Log("The active scene '" + SceneManager.GetActiveScene().name + "' is activated!");
    }
}
