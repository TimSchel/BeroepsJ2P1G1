using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour {

    string CreateScoreURL = "https://81322.ict-lab.nl/school/beroeps/opdracht_D4/postdata.php";

    public GameObject ConfirmationBox;
    public GameObject ErrorBox;
    public Text ScoreShow;


    //Game objecten die ontzichtbaar moeten worden als je highscore al is geupload
    public GameObject Hide1;
    public GameObject Hide2;

    public GameObject LeaderPrefab;

	// Use this for initialization
	IEnumerator Start () {
        ScoreShow.text = "Submit Score: " + PlayerPrefs.GetInt("HighScore");

        //als de score al gesubmit is hoef je niet de submit score dingen te laten zien
        if (PlayerPrefs.GetString("Submitted") == "true")
        {
            ScoreShow.text = "Your submitted Score: " + PlayerPrefs.GetInt("HighScore");
            Hide1.SetActive(false);
            Hide2.SetActive(false);
        }

        //vul 11 keer een lable met een nieuwe naam en score vanuit de database
        for (int i = 0; i < 11; i++)
        {
            //maakt connectie met de database/website
            WWW itemsData = new WWW("https://81322.ict-lab.nl/school/beroeps/opdracht_D4/getdata.php?nummer=" + i);
            
            //Wacht totdat de gegevens zijn opgehaald
            yield return itemsData;

            //split de gegevens en stop ze in een array
            string itemsDataString = itemsData.text;
            string[] items = itemsDataString.Split('|');

            //de try catch is om te testen of verbinding slaagt
            try
            {
                //pakt de username en score en zet het in eigen variable
                string nameUser = items[0];
                string scoreUser = items[1];

                //spawn een nieuw item en bewaar het tijdelijk
                GameObject localPrefab = Instantiate(LeaderPrefab, this.transform);

                //vind de text compenenten van dit nieuwe item en verander de text
                Text NameText = localPrefab.transform.Find("Name").GetComponent<Text>();
                NameText.text = nameUser;

                Text ScoreText = localPrefab.transform.Find("Score").GetComponent<Text>();
                ScoreText.text = scoreUser;
            }
            catch
            {
                //als er geen connectie is laat dan deze error zien
                GameObject localPrefab = Instantiate(LeaderPrefab, this.transform);

                Text NameText = localPrefab.transform.Find("Name").GetComponent<Text>();
                NameText.text = "Coulnd't Connect To Database";

                Text ScoreText = localPrefab.transform.Find("Score").GetComponent<Text>();
                ScoreText.text = "NaN";
            }
        }
    }

    public void WriteToDataBase()
    {
        if(PlayerPrefs.GetString("Submitted") == "false")
        {
            string dbName = GameObject.FindGameObjectWithTag("PlayerNameInput").GetComponent<Text>().text;
            int dbScore = PlayerPrefs.GetInt("HighScore");

            if (dbName != "")
            {
                try
                {
                    //maakt een formulier
                    WWWForm form = new WWWForm();

                    //zet de gegenvens in de formulier
                    form.AddField("name", dbName);
                    form.AddField("score", dbScore);

                    //verstuurd de gegevens naar de website
                    WWW www = new WWW(CreateScoreURL, form);

                    PlayerPrefs.SetString("Submitted", "true");
                    ShowConfirmation();
                }
                catch
                {
                    ShowError();
                }
            }
        }
    }

    public void ShowConfirmation()
    {
        ConfirmationBox.SetActive(true);
    }

    public void ShowError()
    {
        ErrorBox.SetActive(true);
    }
}
