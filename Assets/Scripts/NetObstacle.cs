using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetObstacle : MonoBehaviour {

    PlayerController plr;
    float lifetime = 10f;

    void Start()
    {
        plr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //zorg dat het object niet voor eeuwig blijft staan en geheugen opneemt
        lifetime -= Time.deltaTime;

        if(lifetime < 0)
        {
            Destroy(gameObject);
        }
    }

    //als je collide met de speler moet het spel stoppen
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            plr.GameEnd();
        }
    }
}
