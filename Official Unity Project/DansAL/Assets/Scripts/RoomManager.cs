using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {
	//put number of lights here
	public static bool [] arrayOfLight = new bool[3];

	void Awake(){
		DontDestroyOnLoad (transform.gameObject); 
	}

	void Start () {
		setUpStartingLight(); 

	}


	//Starts declares random t/f for each room at start of game. 
	void setUpStartingLight(){
		for(int i = 0; i < arrayOfLight.Length;i++){
			int number = Random.Range (1,3);
			if(number == 1)
				arrayOfLight[i] = true;
			else
				arrayOfLight[i] = false; 
		}
		//after it sets up lights it will load the first room.
		 Application.LoadLevel ("Room1"); 
	}

	//Each room has an index in the light array, once it sends the room number the
	//function will select that index and set it to false. 
	public static void changeLight(int room)
	{
		if(arrayOfLight[room] == true)
			arrayOfLight[room] = false; 
		else
			arrayOfLight[room] = true; 
	}


	//lets room know if light is on or off
	public static bool isLightOn(int room)
	{
		return arrayOfLight[room]; 
	}
}
