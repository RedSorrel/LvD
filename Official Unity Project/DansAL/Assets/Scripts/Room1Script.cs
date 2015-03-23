using UnityEngine;
using System.Collections;

public class Room1Script : MonoBehaviour {
	public Light roomLight; 
	private bool isLightOn; 
	// Use this for initialization
	void Start () {
		//checks if light is on for room 1
		isLightOn = RoomManager.isLightOn(1); 
	
	}


	// Update is called once per frame
	void Update () {
		//if light is on then the light will be enabled.. else it wont be.
		if(isLightOn == true)
			roomLight.enabled = true; 
		else
			roomLight.enabled = false; 

	}
}
