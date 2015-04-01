using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameOverScript : EventReceiver {

    ghostAI ghostAIOther;

    public Canvas gameOver;
    public Button Yes;
    public Button No;

    public Camera playerCam;
    public Camera mainMenuCam;

    GameObject dead;

	//string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //dead = GameObject.Find("GameController");

        //ghostAIOther = dead.GetComponent<ghostAI>();

        /*if (ghostAIOther.gotDead() == true)
        {
            gameOver.enabled = true;
			Time.timeScale = 0;
        }

		gameOver.enabled = true;*/
		//Time.timeScale = 0;
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

		dead = GameObject.Find("GameController");
		
		ghostAIOther = dead.GetComponent<ghostAI>();

        gameOver = gameOver.GetComponent<Canvas>();
        Yes = Yes.GetComponent<Button>();
        No = No.GetComponent<Button>();

        //playerCam.enabled = true;
        //mainMenuCam.enabled = false;

        gameOver.enabled = false;

    }

    public void Retry()
    {
        Destroy(GameObject.Find("Chief 1")); 
        Application.LoadLevel("loadTools");      
        gameOver.enabled = false;   
    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
        Destroy(GameObject.Find("Chief 1"));

        //mainMenuCam.enabled = true;
        //playerCam.enabled = false; 

		Destroy (this.gameObject);
    }

    public override void Died()
    {
        //Debug.Log("hit gameover");
        gameOver.enabled = true;
        Cursor.visible = true;
    }
}
