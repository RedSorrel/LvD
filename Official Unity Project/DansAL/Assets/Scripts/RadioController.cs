using UnityEngine;
using System.Collections;

public class RadioController : MonoBehaviour {

	/*
	 * 
	 * 	PERSISTENT SOUND CHANNELS
	 * 	-Static
	 * 	-GHOST Music
	 * 
	 * 	ONE SHOT SOUND CHANNELS
	 * 	-Ambient FX
	 * 	-GHOST Movement
	 * 	-Blackout
	 * 	-Ed
	 * 
	 * 
	 */
	
	public AudioSource staticChannel;
	public AudioSource ghostMusicChannel;
	public AudioSource ambienceChannel;
	public AudioSource ghostMovementChannel;
	public AudioSource blackoutChannel;
	public AudioSource edChannel;
	public AudioSource radarChannel;
	
	public DialogueLoader dialogue;
	
	public int rambleInterval;	//Number of frames that must pass before Ed can ramble again
	public int rambleChance;	//Probability that Ed will start rambling when he is able to do so (1 in rambleChance odds)
	
	private int introIndex;
	
	private bool isGivingIntroduction;
	private int rambleCountdown;
	private int radarRate;
	
	
	// Use this for initialization
	void Start () {
		//Start playing Ed's introduction
		introIndex = 0;
		edChannel.clip = dialogue.IntroClips [introIndex];
		edChannel.Play ();
		isGivingIntroduction = true;
		rambleCountdown = -1;
		
		radarRate = 40;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//updateRadar ();
		updateGHOST ();
		updateDialogue ();
		
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	void updateGHOST(){
		int r = Random.Range(0, 1000);
		
		if (r == 0) {
			ghostMovementChannel.Play ();
			ghostMovementChannel.time = 0;
		}
		
	}
	
	void updateRadar(){
		//Check for item proximity
		if (radarRate >= 0)
			radarRate--;
		else {
			radarChannel.time = 0;
			radarChannel.Play ();
			radarRate = 40;
		}
	}
	
	void updateDialogue(){
		
		
		//Check if Ed's giving his introduction
		if (!edChannel.isPlaying && isGivingIntroduction) {
			//ED IS GIVING HIS INTRODUCTION
			
			if (++introIndex < dialogue.IntroClips.Length) {
				//Advance introduction clip
				edChannel.clip = dialogue.IntroClips [introIndex];
				edChannel.Play ();
			} else
				isGivingIntroduction = false;
			
		} 
		else {
			//NORMAL BEHAVIOR
			
			//Check for victory conditions, they override other dialogue
			//ITEM QUOTA MET
			
			//ALL ITEMS COLLECTED
			
			//ESCAPE
			
			if (!edChannel.isPlaying){
				//ED IS NOT TALKING
				
				//RAMBLE DIALOGUE
				if (rambleCountdown >= 0)
					rambleCountdown--;
				else{
					//Enough time has passed that we can play a ramble clip
					int r = Random.Range(0, rambleChance);
					
					if (r == 0){
						//Start rambling
						r = Random.Range (0, dialogue.RambleClips.Length);
						edChannel.clip = dialogue.RambleClips[r];
						edChannel.Play ();
					}
				}
				
			}
			else {
				//ED IS TALKING
				
				//Keep the ramble countdown maxed out
				rambleCountdown = rambleInterval;
			}
			
			
			
		}
		
		
		
	}
}