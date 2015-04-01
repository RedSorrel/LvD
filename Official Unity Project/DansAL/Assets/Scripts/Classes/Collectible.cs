using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[System.Serializable]
public class Collectible : EventReceiver{

	//Store the associated object and the mission that contains it
	public int gid;
	public int value;

	public override void onItemClick(int id, int value){

		if (id == gid)
			this.gameObject.SetActive (false);

	}
}
