using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawner : MonoBehaviour {

    public GameObject Net;

    GameMaster gameMaster;

    float countdown;

    void Start()
    {
        countdown = Random.Range(8f, 10f);
        gameMaster = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<GameMaster>();
    }
	// Update is called once per frame
	void Update ()
    {
        countdown -= Time.deltaTime;
        //als het spel nog bezig is, en de countdown op 0 is spawn een nieuw obstakel en reset de timer
        if(countdown < 0)
        {
            if(gameMaster.GetGameState())
            {
                countdown = Random.Range(6f, 8f);

                Instantiate(Net, new Vector3(transform.position.x, transform.position.y + Random.Range(0, 3), 0), Quaternion.identity);
            }
        }	
	}
}
