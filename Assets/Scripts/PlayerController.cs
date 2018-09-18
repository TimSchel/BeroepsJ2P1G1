using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	public float JumpForce;
	public float ForwardForce;
    public Animation gameOver;

    public ScoreManager scm;

    public Text Score;
    public Text HighScore;
	public GameObject newHighScoreText;

	public ParticleSystem particles;

    GameMaster gameMaster;

    SpriteRenderer rend;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        gameMaster = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<GameMaster>();
    }
	
	void Update()
	{
        //reset highscores voor testing
		if(Input.GetKeyDown("r"))
		{
			PlayerPrefs.DeleteAll();
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(ForwardForce * Time.deltaTime, 0, 0);

		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
		{
			rb.velocity = new Vector3(0,JumpForce, 0);
		}
	}

	void OnBecameInvisible() 
	{
        //wanneer de player offscreen gaat, game over
        GameEnd();
	}

    public void GameEnd()
    {
        //zorg dat de speler niet meer zichtbaar is en niet kan bewegen
        rend.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        //zeg in de game master om niet meer extra obstacles te spawnen
        gameMaster.SetGameActive(false);

        //vernietig alle obstacles die er nog zijn.
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obstacle in Obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        scm.StopTimer();

        Score.text = "" + PlayerPrefs.GetInt("Score");
        HighScore.text = "" + PlayerPrefs.GetInt("HighScore");

        if (PlayerPrefs.GetString("NewHigh") == "true")
        {
            newHighScoreText.SetActive(true);
            Invoke("PlayNewHighEffect", 1.5f);
        }

        gameOver.Play();
    }

	void PlayNewHighEffect()
	{
		particles.Play();
	}
}
