using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class breakerBoxScript : EventReceiver {

    bool [] powerButtons;
    public Image[] selectedImages;
    public Image[] highlightImages;
    public Button[] buttonObjects;

    public Canvas breakerBoxUI;
    GameObject powerStation;
    Image Base;

    /*public Button entraceBay;
    public Button medLab;
    public Button commCenter;
    public Button restRoom;
    public Button breakRoom;
    public Button crewQuarters;
    public Button northHallway;
    public Button materialsLab;
    public Button bioLab;
    public Button ghostLab;
    public Button eastShaft;
    public Button messHall;
    public Button kitchen;
    public Button sendPower;*/

	//Image entraceBayImage;
    //GameObject entraceBayObject;

    RoomController roomControllerOther;

	// Use this for initialization
	void Start () {

        breakerBoxUI = breakerBoxUI.GetComponent<Canvas>();
        breakerBoxUI.enabled = true;
        
        Cursor.visible = true;

        powerStation = GameObject.Find("Base");
        Base = powerStation.GetComponent<Image>();
        //Base = powerStation.GetComponent<Image>();

        for (int i = 0; i < 13; i++)
        {
            selectedImages[i].enabled = false; 
        }

        for (int i = 0; i < 14; i++)
        {
            highlightImages[i].enabled = false;
        }

        powerButtons = new bool[13];

        for(int i = 0; i < 13; i++)
        {
            powerButtons[i] = false;
        }

        /*entraceBay = entraceBay.GetComponent<Button>();
        medLab = medLab.GetComponent<Button>();
        commCenter = commCenter.GetComponent<Button>();
        restRoom = restRoom.GetComponent<Button>();
        breakRoom = breakRoom.GetComponent<Button>();
        crewQuarters = crewQuarters.GetComponent<Button>();
        northHallway = northHallway.GetComponent<Button>();
        materialsLab = materialsLab.GetComponent<Button>();
        bioLab = bioLab.GetComponent<Button>();
        ghostLab = ghostLab.GetComponent<Button>();
        eastShaft = eastShaft.GetComponent<Button>();
        messHall = messHall.GetComponent<Button>();
        kitchen = kitchen.GetComponent<Button>();
        sendPower = sendPower.GetComponent<Button>();*/
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            breakerBoxUI.enabled = false;
            Cursor.visible = false;
        }
	
	}

    public void entraceBayMethod()
    {
        powerButtons[0] = !powerButtons[0];

        selectedImages[0].enabled = !selectedImages[0].enabled;

        Debug.Log("breakerBox hit");
    }

    public void medLabMethod()
    {
        powerButtons[1] = !powerButtons[1];

		selectedImages[1].enabled = !selectedImages[1].enabled;
    }

    public void restRoomMethod()
    {
        powerButtons[2] = !powerButtons[3];

		selectedImages[2].enabled = !selectedImages[2].enabled;
    }

    public void commCenterMethod()
    {
        powerButtons[3] = !powerButtons[2];

		selectedImages[3].enabled = !selectedImages[3].enabled;
    }

    public void breakRoomMethod()
    {
        powerButtons[4] = !powerButtons[4];

		selectedImages[4].enabled = !selectedImages[4].enabled;
    }

    public void crewQuartersMethod()
    {
        powerButtons[5] = !powerButtons[5];

		selectedImages[5].enabled = !selectedImages[5].enabled;
    }

    public void northHallwayMethod()
    {
        powerButtons[6] = !powerButtons[6];

		selectedImages[6].enabled = !selectedImages[6].enabled;
    }

    public void materialsLabMethod()
    {
        powerButtons[7] = !powerButtons[7];

		selectedImages[7].enabled = !selectedImages[7].enabled;
    }

    public void ghostLabMethod()
    {
        powerButtons[8] = !powerButtons[8];

        selectedImages[8].enabled = !selectedImages[8].enabled;
    }

    public void bioLabMethod()
    {
        powerButtons[9] = !powerButtons[9];

		selectedImages[9].enabled = !selectedImages[9].enabled;
    }

    public void eastShaftMethod()
    {
        powerButtons[10] = !powerButtons[10];

		selectedImages[10].enabled = !selectedImages[10].enabled;
    }

    public void messHallMethod()
    {
        powerButtons[11] = !powerButtons[11];

		selectedImages[11].enabled = !selectedImages[11].enabled;
    }

    public void kitchenMethod()
    {
        powerButtons[12] = !powerButtons[12];

		selectedImages[12].enabled = !selectedImages[12].enabled;
    }

    public void entraceBayHighlight()
    {
        highlightImages[0].enabled = true;
    }

    public void medLabHighlight()
    {
        highlightImages[1].enabled = true;
    }

    public void restRooomHighlight()
    {
        highlightImages[2].enabled = true;
    }

    public void commCenterHighlight()
    {
        highlightImages[3].enabled = true;
    }

    public void breakRoomHighlight()
    {
        highlightImages[4].enabled = true;
    }

    public void crewQuarterssHighlight()
    {
        highlightImages[5].enabled = true;
    }

    public void northHallwayHighlight()
    {
        highlightImages[6].enabled = true;
    }

    public void materialsLabHighlight()
    {
        highlightImages[7].enabled = true;
    }

    public void ghostLabHighlight()
    {
        highlightImages[8].enabled = true;
    }

    public void bioLabHighlight()
    {
        highlightImages[9].enabled = true;
    }

    public void eastShaftHighlight()
    {
        highlightImages[10].enabled = true;
    }

    public void messHallHighlight()
    {
        highlightImages[11].enabled = true;
    }

    public void kitchenHighlight()
    {
        highlightImages[12].enabled = true;
    }

    public void sendPowerHighlight()
    {
        highlightImages[13].enabled = true;
    }

    public void entraceBayExit()
    {
        highlightImages[0].enabled = false;
    }

    public void medLabExit()
    {
        highlightImages[1].enabled = false;
    }

    public void restRoomExit()
    {
        highlightImages[2].enabled = false;
    }

    public void commCenterExit()
    {
        highlightImages[3].enabled = false;
    }

    public void breakRoomExit()
    {
        highlightImages[4].enabled = false;
    }

    public void crewQuartersExit()
    {
        highlightImages[5].enabled = false;
    }

    public void northHallwayExit()
    {
        highlightImages[6].enabled = false;
    }

    public void materialsLabExit()
    {
        highlightImages[7].enabled = false;
    }

    public void ghostLabExit()
    {
        highlightImages[8].enabled = false;
    }

    public void bioLabExit()
    {
        highlightImages[9].enabled = false;
    }

    public void eastShaftExit()
    {
        highlightImages[10].enabled = false;
    }

    public void messHallExit()
    {
        highlightImages[11].enabled = false;
    }

    public void kitchenExit()
    {
        highlightImages[12].enabled = false;
    }

    public void sendPowerExit()
    {
        highlightImages[13].enabled = false;
    }

    public void sendPowerMethod()
    {
        roomControllerOther = GetComponent<RoomController>();

        for (int i = 0; i < 13; i++)
        {
            if (powerButtons[i] == true)
            {
                roomControllerOther.rooms[i].toggleLight();
            }
        }
    }

    public void breakerBoxExit()
	{
		for (int i = 0; i < 13; i++) 
		{
			powerButtons[i] = false;

			selectedImages[i].enabled = false;
		}

        breakerBoxUI.enabled = false;
        Cursor.visible = false;
    }

	public override void breakerBoxClick()
	{
		breakerBoxUI.enabled = true;
        Cursor.visible = true;
	}
}
