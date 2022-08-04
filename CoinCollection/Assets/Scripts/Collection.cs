/**** 
 * Created by: Stu Dent 
 * Date Created: Feb 3, 2022 
 * 
 * Last Edited by: Yaoyuan Zhang
 * Last Edited: 6/20/22
 * 
 * Description: Manages collections and wining conditions. 
****/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
   [Tooltip("Number of collectables to beat level")] 
    public int winCollectAmount; 
    [Tooltip("Use the total number of collectables for the win amount")] 
    public bool useCollectableCount; 
    [HideInInspector] 
    private bool hasCollectedAll = false;
    private int collectablesInCollection = 0; 
   private Timer timer;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        timer = Timer.LevelTimer; //reference the level timer
        if(useCollectableCount)
        {
            winCollectAmount = Collectable.collectableCount;
        }
        Debug.Log("Win collect amount: " + winCollectAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if(collectablesInCollection == winCollectAmount)
        { 
            hasCollectedAll = true; 
            if (timer != null) { timer.timerStopped = true; }
            Debug.Log("You win!");
            gm.BeatLevel();
        } 
        gm.collection = (collectablesInCollection + "/" + winCollectAmount);
    }

    public void AddToCollection()
    {
        collectablesInCollection++;
        Debug.Log("Collectable Added");
    
     
    }
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
        
    
}