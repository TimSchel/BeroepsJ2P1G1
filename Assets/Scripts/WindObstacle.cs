using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindObstacle : MonoBehaviour {

    float lifetime = 10f;

    void Start()
    {
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

	void FixedUpdate()
	{
		transform.Translate(Time.deltaTime, 0, 0);
	}

	//als je collide met de speler moet hij de speler omhoog lanceren
	void OnTriggerStay2D(Collider2D other)
    {
		if(other.gameObject.tag == "Player")
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector3(0, 70000 * Time.deltaTime, 0));
        }
    }
}
