using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	public int numberOfPickups; 
	public int numberOfRooms; 
	public int currentItem; 

	public static bool [] room1Pickups = new bool[4]; 

	public static int room1; 
	
	void Awake(){
		DontDestroyOnLoad (transform.gameObject); 
	}
	
	void Start () {
		setPickUps();
	}

	
	// Update is called once per frame
	void Update () {

	}

	//Starts declares random t/f for each room at start of game. 
	void setPickUps(){
		for(int i = 0; i < room1Pickups.Length;i++){
			int number = Random.Range (1,3);
			//int number = 1; 
			if(number == 1)
			{
				Debug.Log ("True"); 
				room1Pickups[i] = true;
			}
				else
			{
				Debug.Log ("FALSE"); 
				room1Pickups[i] = false; 
			}
		}
	}

	public static void deleteItem(int index){
		room1Pickups[index] = false; 
	}
}

