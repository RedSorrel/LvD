using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class RoomController : EventReceiver  {

	public Room[] rooms;

	public int blackoutDelay; //seconds
	public float blackoutChance;

	private int blackoutCounter;
	private int rand;

	// Use this for initialization
	void Start () {
		blackoutCounter = blackoutDelay * 60;
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Alpha0))
			darkenRoom (0);

		if (Input.GetKeyDown (KeyCode.Alpha1))
			darkenRoom (1);

		if (Input.GetKeyDown (KeyCode.Alpha2))
			darkenRoom (2);

		if (Input.GetKeyDown (KeyCode.Q))
			ExecuteEvents.Execute<IMessageTarget>(this.gameObject, null, (x, y)=>x.onQuotaMet());

		if (Input.GetKeyDown (KeyCode.K))
			ExecuteEvents.Execute<IMessageTarget>(this.gameObject, null, (x, y)=>x.onEnterDarkRoom());

		if (Input.GetKeyDown (KeyCode.L))
			ExecuteEvents.Execute<IMessageTarget>(this.gameObject, null, (x, y)=>x.onEnterLightRoom());

		//Update chance to blackout a room
		if (blackoutCounter > 0)
			blackoutCounter--;
		else {
			rand = Random.Range (1, 10000);
			if ((float)rand/10000 <= blackoutChance){
				//Black out a random room
				blackoutCounter = blackoutDelay * 60;

				rand = Random.Range (0, rooms.Length - 4);
				while (!allRoomsDark()){

					//Try to darken room, as long as room isn't dark
					if (rooms[rand].dark){
						//Room is already dark, choose another one
						rand = Random.Range(0, rooms.Length - 4);
					}
					else{
						darkenRoom (rand);
						break;
					}

				}

			}


		}
	}

	void toggleRoomState(int r){

		rooms [r].toggleLight ();

	}

	void darkenRoom(int r){

		rooms [r].turnOffLight ();
		ExecuteEvents.Execute<IMessageTarget>(this.gameObject, null, (x, y)=>x.onRoomWentDark(r));

	}

	bool isRoomDark(int r){

		return rooms[r].dark;

	}

	public bool allRoomsDark(){
		bool result = true;

		for (int i = 0; i < rooms.Length - 4; ++i)
			if (!rooms[i].dark)
				result = false;

		return result;
		
	}

	public int numDarkRooms(){
		int result = 0;

		for (int i = 0; i < rooms.Length - 4; ++i)
			if (rooms [i].dark)
				result++;

		return result;
	}


	//Event handlers

	public override void onRoomWentDark(int r){

		Debug.Log ("Room " + r + " went dark!");

	}


}
