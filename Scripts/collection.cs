using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class collection : MonoBehaviour
{
    public Texture2D texture = null;
    public Texture2D texture2 = null;

    int x;
    float y;
    int y2;
	float totalItems;
	float subItem;

    GameObject player;

    bool checkedItem;

    //player = GameObject.Find("room1");


    // Use this for initialization
    void Start()
    {

        x = 10;
        y = 200;
        y2 = 200;
		totalItems = 3;
		subItem = y / totalItems;

        checkedItem = false;

        //grabbing player object
        player = GameObject.Find("room1");
        //grabbing script refernce
        //sceneChange sceneChangeOther = player.GetComponent<sceneChange>();

        //testingItem = sceneChangeOther.gottenItem();

        //Debug.Log(testingItem);

        //Debug.Log(Screen.GetResolution);

    }

    // Update is called once per frame
    void Update()
    {

        sceneChange sceneChangeOther = player.GetComponent<sceneChange>();
        //testingItem = sceneChangeOther.gottenItem ();

		//Debug.Log (sceneChangeOther.gottenItem());

        if (sceneChangeOther.gottenItem == true && checkedItem == false)
        {
			y -= subItem;
			checkedItem = true;
        }

        if (Input.GetKeyDown("f"))
        {
            y -= 25;

        }

        if (Application.loadedLevel == 0)
        {
            Destroy(gameObject);
        }

		if (y < 0) 
		{
			y = 0;
		}

    }

    // Draws a box of the size of the screen.
    void OnGUI()
    {
        //GUI.Box(new Rect(750, 400, 20, 200), texture);

        //need secondary color to give filling effect
        //red

        GUI.DrawTexture(new Rect(Screen.width-100, Screen.height-300, x, y2), texture, ScaleMode.StretchToFill);
        //grey
		GUI.DrawTexture(new Rect(Screen.width-100, Screen.height-300, x, y), texture2, ScaleMode.StretchToFill);

        //Debug.Log("Test");
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
