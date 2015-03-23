using UnityEngine;
using System.Collections;

public class CenterGui : MonoBehaviour {
	public GameObject player;
	public float trackerLength = 20f; 

	
	//public Object control; 
	// Use this for initialization
	void Start () {

	}
	
	
	// Update is called once per frame
	void Update () {

		//always updates ray to looking foward. 
		Vector3 fwd = transform.TransformDirection (Vector3.forward); 

		//If Raycast Hit something
		RaycastHit hit;

		//draws Ray
		Debug.DrawRay (transform.position, fwd * 1005, Color.red); 

		//Saying ray will always look forward
		Ray landingRay = new Ray(transform.position, fwd);
		

		if(Physics.Raycast(landingRay, out hit, trackerLength))
		{
			
			string ObTag = hit.collider.gameObject.tag;
			
			if(ObTag == "Door")
			{
				if(Input.GetKeyDown("f"))
					Application.LoadLevel ("breakerRoom"); 
			}
			else
			//hoverIndicator.renderer.enabled=false; 
			if(ObTag == "Door1" && Input.GetKeyDown("f"))
			{
				Application.LoadLevel ("room1"); 
			}
			if(ObTag=="breaker" && Input.GetKeyUp("f"))
			{

			}
			
		}
	}
}
