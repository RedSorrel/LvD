using UnityEngine;
using System.Collections;

public class sceneChange : MonoBehaviour {

    GameObject player;
    //GameObject Box;

    //using this script to test getting items to fill bar
    //will probably change later
    bool gotItem;


	// Use this for initialization
	void Start () {

        player = GameObject.Find("player");
        gotItem = false;
        //Box = GameObject.Find("Cube");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {

        
       float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

       Debug.Log(distance);

       if (distance < 25f)
       {
            Application.LoadLevel(2);
           	gotItem = true;
       }

		if (Application.loadedLevel == 0) 
		{
			Destroy(gameObject);
		}
        
    }

    public bool gottenItem
    {
        get
        {
            return gotItem;
        }
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
