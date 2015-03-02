using UnityEngine;
using System.Collections;

public class ghostAI : MonoBehaviour {

    GameObject cube1;
    GameObject cube2;
    GameObject cube3;
    GameObject cube4;
	GameObject player;

    float timer;
	float killTimer;

    bool cube1In;
    bool cube2In;
    bool cube3In;
    bool cube4In;

    bool gameOver;

	bool room1Light;
	bool room2Light;

    int randomValue;


	// Use this for initialization
	void Start () {

        cube1 = GameObject.Find("Cube1");
        cube2 = GameObject.Find("Cube2");
        cube3 = GameObject.Find("Cube3");
        cube4 = GameObject.Find("Cube4");
		player = GameObject.Find("player");

        timer = 0.0f;
		killTimer = 0.0f;

        randomValue = Random.Range(0, 4);

        cube1In = false;
        cube2In = false;
        cube3In = false;
        cube4In = false;

        gameOver = false;

		room1Light = true;
		room2Light = true;

        if (randomValue == 0)
        {
            cube1In = true;
            cube1.renderer.material.color = Color.green;
        }
        else if (randomValue == 1)
        {
            cube2In = true;
            cube2.renderer.material.color = Color.green;
        }
        else if (randomValue == 2)
        {
            cube3In = true;
            cube3.renderer.material.color = Color.green;
        }
        else
        {
            cube4In = true;
            cube4.renderer.material.color = Color.green;
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        //Debug.Log(timer);

        /*if (Application.loadedLevel == 3)
        {
            killTimer += Time.deltaTime;

            if (killTimer > 5.0)
            {
                gameOver = true;
            }
        }*/

        if (timer > 5.0)
        {
            randomValue = Random.Range(0, 2);

            //Debug.Log(randomValue);

            if (cube1In == true)
            {
                if (randomValue == 0)
                {
                    cube2In = true;
                    cube2.renderer.material.color = Color.green;
                    cube1.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube1In = false;
                }
                else
                {
                    cube4In = true;
                    cube4.renderer.material.color = Color.green;
                    cube1.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube1In = false;
                }
            }
            else if (cube2In == true)
            {
                if (randomValue == 0)
                {
                    cube1In = true;
                    cube1.renderer.material.color = Color.green;
                    cube2.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube2In = false;

                }
                else
                {
                    cube3In = true;
                    cube3.renderer.material.color = Color.green;
                    cube2.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube2In = false;
                }
            }
            else if (cube3In == true)
            {
                if (randomValue == 0)
                {
                    cube2In = true;
                    cube2.renderer.material.color = Color.green;
                    cube3.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube3In = false;
                }
                else
                {
                    cube4In = true;
                    cube4.renderer.material.color = Color.green;
                    cube3.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube3In = false;
                }
            }
            else
            {
                if (randomValue == 0)
                {
                    cube1In = true;
                    cube1.renderer.material.color = Color.green;
                    cube4.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube4In = false;
                }
                else
                {
                    cube3In = true;
                    cube3.renderer.material.color = Color.green;
                    cube4.renderer.material.color = Color.black;
                    timer = 0.0f;
                    cube4In = false;
                }
            }

            //cube1.renderer.material.color = Color.green;
            //timer = 0;
        }

	}

    /*public bool gotDead()
    {
        return gameOver;
    }*/
}
