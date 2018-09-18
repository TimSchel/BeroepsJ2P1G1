using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    bool gameActive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //set de waarde of het spel nog loopt
    public void SetGameActive(bool state)
    {
        gameActive = state;
    }

    //geef de waarde terug of het spel nog loopt
    public bool GetGameState()
    {
        return gameActive;
    }
}
