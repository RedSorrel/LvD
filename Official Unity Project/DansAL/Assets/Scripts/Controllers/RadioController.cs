﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;



public class RadioController : EventReceiver {

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
	 * 	-Radar
	 * 
	 * 
	 */

	public RadioChannel staticChannel;
	public RadioChannel ghostMusicChannel;
	public RadioChannel ambienceChannel;
	public RadioChannel ghostMovementChannel;
	public RadioChannel blackoutChannel;
	public RadioChannel edChannel;
	public RadioChannel radarChannel;

	public DialogueLoader dialogue;

	public AudioClip lightStatic;
	public AudioClip darkStatic;

	public int rambleInterval;	//Number of frames that must pass before Ed can ramble again
	public int rambleChance;	//Probability that Ed will start rambling when he is able to do so (1 in rambleChance odds)

	private int introIndex;

	private bool isGivingIntroduction;
	private int rambleCountdown;
	private int radarRate;

	private int rand;	//Used to hold random numbers
	
	// Use this for initialization
	void Start () {
		//Start playing Ed's introduction
		introIndex = 0;
		edChannel.src.clip = dialogue.IntroClips [introIndex];
		edChannel.src.Play ();
		isGivingIntroduction = true;
		rambleCountdown = -1;

		radarRate = 40;

	}
	
	// Update is called once per frame
	void Update () {

		//updateRadar ();
		updateGHOST ();
		updateDialogue ();

		staticChannel.update ();

	}











	void updateGHOST(){

		//Update channels
		ghostMovementChannel.update ();
		ghostMusicChannel.update ();
		
	}

	void updateRadar(){
		//Check for item proximity
		if (radarRate >= 0)
			radarRate--;
		else {
			radarChannel.src.time = 0;
			radarChannel.Play ();
			radarRate = 40;
		}

		radarChannel.update ();
	}
	
	void updateDialogue(){


		//Check if Ed's giving his introduction
		if (!edChannel.src.isPlaying && isGivingIntroduction) {
			//ED IS GIVING HIS INTRODUCTION

			if (++introIndex < dialogue.IntroClips.Length) {
				//Advance introduction clip
				edChannel.src.clip = dialogue.IntroClips [introIndex];
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

			if (!edChannel.src.isPlaying){
				//ED IS NOT TALKING

				//RAMBLE DIALOGUE
				if (rambleCountdown >= 0)
					rambleCountdown--;
				else{
					//Enough time has passed that we can play a ramble clip
					rand = Random.Range(0, rambleChance);

					if (rand == 0){
						//Start rambling
						rand = Random.Range (0, dialogue.RambleClips.Length);
						edChannel.src.clip = dialogue.RambleClips[rand];
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
		

		edChannel.update ();
	}

	private void playDialogue(AudioClip clip){
		//Play the specified dialogue clip
		//TODO: Know information corresponding to subtitle data

		ExecuteEvents.Execute<IMessageTarget>(this.gameObject, null, (x, y)=>x.onPlayDialogue(0));

		edChannel.src.clip = clip;
		edChannel.Play ();
	}

	//Event handlers

	public override void onRoomWentDark(int r){

		blackoutChannel.src.time = 0;
		blackoutChannel.Play ();

		//Ed has a 20% chance of identifying the room
		rand = Random.Range (0, 4);
		if (rand == 0 && !edChannel.src.isPlaying) {
			//Play the clip associated with the room
			edChannel.src.clip = dialogue.BlackoutClips[r];
			edChannel.Play ();
		}

	}

	public override void onQuotaMet(){

		//This sound clip overrides whatever Ed is saying
		edChannel.src.clip = dialogue.QuotaMetClip;
		edChannel.Play ();

	}

	public override void onEnterDarkRoom(){

		//Play transition clip
		ambienceChannel.src.time = 0;
		ambienceChannel.Play ();

		//Turn off other channels
		edChannel.setTargetVolume (0, 0.01f);
		edChannel.setTargetPitch (0.2f, 0.008f);

		staticChannel.src.clip = darkStatic;
		staticChannel.setTargetVolume (1, 0.05f);
		staticChannel.src.loop = true;
		staticChannel.Play ();

		ghostMusicChannel.setTargetVolume (0.5f, 0.005f);
		ghostMusicChannel.src.loop = true;
		ghostMusicChannel.Play ();
	}

	public override void onEnterLightRoom(){

		//ambienceChannel.src.time = 0;
		//ambienceChannel.Play ();

		edChannel.setTargetVolume (1, 0.005f);
		edChannel.setTargetPitch (1, 0.008f);

		staticChannel.src.clip = lightStatic;
		staticChannel.setTargetVolume (0.2f, 0.05f);
		staticChannel.src.loop = true;
		staticChannel.Play ();

		ghostMusicChannel.setTargetVolume (0.0f, 0.05f);
	}

}
