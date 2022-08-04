/**** 
* Created by: Stu Dent
* Date Created: Feb 3, 2022
* 
* Last Edited by: Yaoyuan Zhang
* Last Edited: 6/20/22
* 
* Description: Collectable object behaviors for counting the total amount of collectables and 
checking for collision with the player.
****/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    // Start is called before the first frame update
    static public int collectableCount;
    

    void Awake()
    { 
        collectableCount++; //add to collectable
        Debug.Log("Number of Colletables " + collectableCount);
    }
    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("Collectable Triggered");
        if(other.tag == "Player") 
        { 
            other.GetComponent<Collection>().AddToCollection();
            Destroy(gameObject); //destroy this gameObject (collectable object)
        }
    }

}
