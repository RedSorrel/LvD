using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameOverScript : MonoBehaviour {

    public Canvas gameOver;
    public Button Yes;
    public Button No;

    GameObject dead;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Application.loadedLevel == 3)
        {

            dead = GameObject.Find("ghostAIController");

            ghostAI ghostAIOther = dead.GetComponent<ghostAI>();

            if (ghostAIOther.gotDead() == true)
            {
                gameOver.enabled = true;
            }
        }*/
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        gameOver = gameOver.GetComponent<Canvas>();
        Yes = Yes.GetComponent<Button>();
        No = No.GetComponent<Button>();

        gameOver.enabled = false;

    }
}
