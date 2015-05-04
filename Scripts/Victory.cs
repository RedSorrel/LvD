using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

    float vicTimer;
    GameObject player;
    public Camera mainMenuCam;
    public Camera playerCam;

	// Use this for initialization
	void Start () {

        this.enabled = false;
        vicTimer = 0.0f;
        player = GameObject.Find("Chief 1");
        mainMenuCam = null;
        playerCam = null;

	}
	
	// Update is called once per frame
	void Update () {


        if (this.enabled == true)
        {
            if (vicTimer < 3.0f)
            {
                vicTimer += Time.deltaTime;
            }
            else
            {
                Destroy(player);
                Application.LoadLevel(0);
                mainMenuCam.enabled = true;
                playerCam.enabled = false;  
            }
        }
	
	}

    void victoryCondition()
    {
        this.enabled = true;
    }
}
