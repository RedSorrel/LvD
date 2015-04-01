using UnityEngine;
using System.Collections;

public class aimDot : MonoBehaviour {
	//Vars for raycaster
	public GameObject player;
	public float trackerLength = 5f; 
	public Light playerFlashlight; 

	public Texture aimerHover;
	public Texture aimerNonHover;
	public Texture usedTexture; 
	public Texture pickUpTexture; 

	public int currentLevel; 


	//this is so we can find the exact object to delete
	public static int ID; 


	void OnGUI(){
		GUI.Label(new Rect (Screen.width/2f, Screen.height/2f,50,50), usedTexture); 
	}
	// Use this for initialization
	void Start () {
		ID=0; 
		usedTexture=aimerNonHover; 
		currentLevel = Application.loadedLevel; 

	}

	//Id to identify what we need to delete.
	public static int ReturnID()
	{
		return ID; 
	}

	// Update is called once per frame
	void Update () {



		//always updates ray to looking foward. 
		Vector3 fwd = transform.TransformDirection (Vector3.forward); 
		
		//If Raycast Hit something
		RaycastHit hit;
		
		//draws Ray
		Debug.DrawRay (transform.position, fwd * 5, Color.red); 
		
		//Saying ray will always look forward
		Ray landingRay = new Ray(transform.position, fwd);

		//If light is on in the current level then Flashlight is disabled.
		if(RoomManager.isLightOn(currentLevel) == true){
			playerFlashlight.enabled = false; 
		}
		else
			playerFlashlight.enabled = true;

		//trackerLength == the max distance an object will be recognized
		if(Physics.Raycast(landingRay, out hit, trackerLength))
		{
			//to find what we are hitting
			string ObTag = hit.collider.gameObject.tag;

			//to id what we are deleteing
			ID = hit.collider.gameObject.GetInstanceID();


			//--------------------------------------------Section for iding objects-------------------------------//
			//if Object is untaged we set it to hover
			if(ObTag!="Untagged")
				usedTexture = aimerHover; 

			//HEY THIS IS A BREAKER BOX! WE BETTER CHANGE THE LIGHT
			if(ObTag == "BreakerBox")
			{
				//change aimdot texture
				usedTexture = pickUpTexture; 
				if(Input.GetKeyDown ("f"))
					//change light in the room we are currently in.
					RoomManager.changeLight(1); 
			}

			//HEY THIS IS THE DOOR TO THE BREAKER ROOM
			if(ObTag == "Breaker_Door")
			{
				//change aimdot texture
				usedTexture = aimerHover; 

				if(Input.GetKeyDown("f"))
					Application.LoadLevel ("BreakerRoom"); 
			}

			//Says HEY THIS IS ROOM 1 Load room level
			if(ObTag == "Room_1")
			{
				
				usedTexture = aimerHover;
				if(Input.GetKeyDown("f"))
					Application.LoadLevel ("Room1"); 
			}

			//HEY THIS IS A PICK UP OBJECT PICK UP TEXTURE
			if(ObTag == "PickUp")
			{
				usedTexture = pickUpTexture; 
						
			}

		}
		//texture will be for non hover objects
		else
			usedTexture = aimerNonHover; 
	}
}
