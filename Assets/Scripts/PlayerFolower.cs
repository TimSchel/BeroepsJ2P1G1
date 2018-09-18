using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFolower : MonoBehaviour {

	GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//krijg de coords van de speler en zet de camera naar ze
		float PlayerPosX = Player.transform.position.x;
		float PlayerPosZ = Player.transform.position.z;

		this.transform.position = new Vector3(PlayerPosX, 0, PlayerPosZ-5);
	}
}
