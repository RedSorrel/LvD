using UnityEngine;
using System.Collections;

public class Room1Spawn : MonoBehaviour {

	public GameObject [] spawnItems = new GameObject[4];
	public static int howManyPickUps;
	public static int hasBeenUsed; 
	public aimDot id; 

	// Use this for initialization


	
	/*void OnLevelWasLoaded(int level) {
		if(level==1)
			Debug.Log ("YO2"); 
		
	}*/

	void Start () {
		//lets us refrence the ID from aimDot script.
		aimDot id = GetComponent<aimDot>();
			setUpPickups();
	}
	
	// Update is called once per frame
	void Update () {
		//if ID !=0 it means we are hovering over an object.
		if(Input.GetKeyDown ("f")&& aimDot.ID != 0)
		{
			pickUpItem();
		}
	}

	void setUpPickups(){
		//sets all items in array with a value of "False" to not be active anymore//
		for(int i = 0; i< SpawnManager.room1Pickups.Length; i++)
		{
			if(SpawnManager.room1Pickups[i] == false)
			{
				spawnItems[i].SetActive(false); 
			}

		}

	}



	public void pickUpItem(){

		int test = aimDot.ID; 

		//loops through array of items, if it finds a match to the id it will delete the item in the array at i, then set
		//pickups so it wont render anymore
		for(int i = 0; i< spawnItems.Length; i++)
		{
			if(spawnItems[i].gameObject.GetInstanceID() == test)
			{
				Debug.Log ("ITS AT INDEX: "+i); 
				SpawnManager.deleteItem(i); 
				setUpPickups (); 
			}
			
		}
	}
}
