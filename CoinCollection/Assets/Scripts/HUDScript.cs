using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDScript : MonoBehaviour
{
    GameManager gm; //reference to game manager
    private int level;
    private int totalLevels;
    private int lives;
    private int score;
    private int highscore;
    private string timer;
    private string collection;
    public TMP_Text levelCountTextbox; //textbox for level count
    public TMP_Text livesTextbox; //textbox for the lives
    public TMP_Text healthTextbox; //textbox for highscore
    public TMP_Text scoreTextbox; //textbox for the score
    public TMP_Text highScoreTextbox; //textbox for highscore
    public TMP_Text collectableCountTextbox; //textbox for amount of collectables
    public TMP_Text TimerTextbox; //textbox for Timer display 
    public TMP_Text fastestTimeTextbox; //textbox for the Fastest Time

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //find the game manager
                             //reference to levle info
        level = gm.gameLevelsCount;
        totalLevels = gm.gameLevels.Length;
    }

    void GetGameStats()
    {
        lives = gm.Lives;
        score = gm.Score;
        highscore = gm.HighScore;
        timer = gm.timer;
        collection = gm.collection;
    }//end GetGameStats()

    // Update is called once per frame
    void Update()
    {
        GetGameStats();
        SetHUD();
    }
    void SetHUD()
    {
        //if texbox exsists update value
        if (levelCountTextbox)
        {
            levelCountTextbox.text = "Level " + level + "/" +
       totalLevels;
        }
        if (livesTextbox) { livesTextbox.text = "Lives " + lives; }
        if (scoreTextbox) { scoreTextbox.text = "Score " + score; }
       
        if (highScoreTextbox) { highScoreTextbox.text = "High Score " + highscore; }
        if (scoreTextbox) { scoreTextbox.text = "Score " + score; }
        if (TimerTextbox) { TimerTextbox.text = "Timer " + timer; }
        if (collectableCountTextbox) { collectableCountTextbox.text = "Collection " + collection; }
    }//end SetHUD()
}
