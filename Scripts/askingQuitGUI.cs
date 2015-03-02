using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class askingQuitGUI : MonoBehaviour {

    public Canvas askingQuit;
    public Button Yes;
    public Button No;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown ("escape")) 
		{
			askingQuit.enabled = true;
			(GameObject.Find("ghostAIController").GetComponent("ghostAI") as MonoBehaviour).enabled = false;
            (GameObject.Find("player").GetComponent("MouseLook") as MonoBehaviour).enabled = false;
            (GameObject.Find("player").GetComponent("CharacterMotor") as MonoBehaviour).enabled = false;
            (GameObject.Find("Main Camera").GetComponent("MouseLook") as MonoBehaviour).enabled = false;
            //(GameObject.Find("room1").GetComponent("sceneChange") as MonoBehaviour).enabled = false;
            (GameObject.Find("room1").GetComponent("sceneChange") as MonoBehaviour).enabled = false;
            (GameObject.Find("collectGUIObject").GetComponent("collection") as MonoBehaviour).enabled = false;

            Time.timeScale = 0;
		}

        /*if (Application.loadedLevel == 0)
        {
            Destroy(gameObject);
        }*/

        //askingQuit.enabled = false;
	
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        askingQuit = askingQuit.GetComponent<Canvas>();
        Yes = Yes.GetComponent<Button>();
        No = No.GetComponent<Button>();

        askingQuit.enabled = false;
		
    }

	public void yesQuit()
	{
		Application.LoadLevel(0);
		askingQuit.enabled = false;
		Time.timeScale = 1;
	}

	public void noQuit()
	{
		askingQuit.enabled = false;
		Time.timeScale = 1;
	}
}
