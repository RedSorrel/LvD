using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class rayCaster : EventReceiver {

	public Texture doorTexture;
	public Texture defaultTexture;
	public Texture itemTexture; 
	public Texture currentTexture; 

	public float trackerLength = 5f; 

	private Vector3 fwd;
	private RaycastHit hit;
	private Ray cast;

	private string objTag;

	void OnGUI(){
		GUI.Label(new Rect (Screen.width/2f, Screen.height/2f,32,32), currentTexture); 
	}

	// Use this for initialization
	void Start () {

		fwd = transform.TransformDirection (Vector3.forward); 
		cast = new Ray(transform.position, fwd);
		currentTexture = defaultTexture;
		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		//always updates ray to looking foward. 
		fwd = transform.TransformDirection (Vector3.forward); 

		//Ray will always look forward
		cast.origin = transform.position;
		cast.direction = fwd;

		//draws Ray
		Debug.DrawRay (transform.position, fwd * 5, Color.red); 

		//Check for ray collision
		if (Physics.Raycast (cast, out hit, trackerLength)) {

			//Find out what type of object we've hit
			objTag = hit.collider.gameObject.tag;

			switch (objTag){
			case "Door":

				currentTexture = doorTexture;

				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.F)){
					//We've clicked a door. Change rooms!
					GameObject d = hit.collider.gameObject;
					ExecuteEvents.Execute<IMessageTarget>(transform.parent.gameObject, null, 
					                                      (x, y)=>x.onDoorClick(
															d.GetComponent<Door>().toRoom, 
															d.GetComponent<Door>().toPosition, 
															d.GetComponent<Door>().toRotation)
					                                      );
				}

				break;

			case "Collectible":

				currentTexture = itemTexture;

				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.F)){
					//We've clicked an item. Collect it!
					GameObject d = hit.collider.gameObject;
					GameObject[] roots = GameObject.FindGameObjectsWithTag ("Collectible");

					//Call for all collectible objects
					for (int i = 0; i < roots.Length; ++i){

						ExecuteEvents.Execute<IMessageTarget>(roots[i], null, 
						                                      (x, y)=>x.onItemClick(
							d.GetComponent<Collectible>().gid, 
							d.GetComponent<Collectible>().value)

						                                      );
		
					}

					//Call for game objects
					ExecuteEvents.Execute<IMessageTarget>(transform.parent.gameObject, null, 
					                                      (x, y)=>x.onItemClick(
						d.GetComponent<Collectible>().gid, 
						d.GetComponent<Collectible>().value)
					                                      );
				}

				break;
				
			default:
				
				currentTexture = defaultTexture;
				break;

			}
		}
		else
			currentTexture = defaultTexture;

	}

	//P: -7.58, 0, 11.71
	//R: 0, -135, 0
}
