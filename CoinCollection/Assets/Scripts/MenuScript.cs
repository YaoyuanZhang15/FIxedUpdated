using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    GameManager gm; //refernce to game manager
    [Header("Text Boxes")]
    public TMP_Text titleTextbox;
    public TMP_Text creditsTextbox;
    public TMP_Text copyrightTextbox;
    public TMP_Text messageTextbox;

    [SerializeField]
    private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM; //refernce to game manager
                             //If text boxes exist set the value
        if (titleTextbox) { titleTextbox.text = gm.gameTitle; }
        if (creditsTextbox) { creditsTextbox.text = gm.gameCredits; }
        if (copyrightTextbox) { copyrightTextbox.text = gm.copyrightDate; }
        if (messageTextbox) { messageTextbox.text = gm.endMsg; }
     
        startButton.onClick.AddListener(OnGameStart);
    }

    public void OnGameStart()
    {
        Debug.Log("Game Started");
        gm.SetTargetState(GameState.gamePlaying);
    }

    public void OnGameExit()
    {
        Debug.Log("Exited Game");
        gm.SetTargetState(GameState.gameExited);
    }
    // Update is called once per frame

}
