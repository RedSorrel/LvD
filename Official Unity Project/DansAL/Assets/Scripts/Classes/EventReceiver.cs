using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IMessageTarget : IEventSystemHandler
{
	// functions that can be called via the messaging system
	void onRoomWentDark(int r);
	void onGHOSTMove(int r);

	void onEnterDarkRoom();
	void onEnterLightRoom();

	void onItemCollect(int value);
	void onQuotaMet();
	void onAllItems();


}

public class EventReceiver : MonoBehaviour, IMessageTarget {

	//Declare empty virtual functions

	//Changes in environment
	public virtual void onRoomWentDark(int r){}
	public virtual void onGHOSTMove(int r){}

	//Player movement
	public virtual void onEnterDarkRoom(){}
	public virtual void onEnterLightRoom(){}

	//Item events
	public virtual void onItemCollect(int value){}
	public virtual void onQuotaMet(){}
	public virtual void onAllItems(){}

}