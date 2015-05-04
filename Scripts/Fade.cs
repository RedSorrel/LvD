using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	bool transitions;
    bool transitions2;
    float fadeSpeed;
	Color c;
    public Image fadeImage;

	// Use this for initialization
	void Start () {
        fadeSpeed = 1.0f;

		c = fadeImage.color;
		//c.a = 0;
		transitions = true;
        transitions2 = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        //testing code
        /*c.a += fadeSpeed * Time.deltaTime;
        c.a = Mathf.Clamp01(c.a);
        fadeImage.color = c;*/

        if (transitions == true)
        {
            c.a += fadeSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);

            fadeImage.color = c;

            if (c.a == 1)
            {
                //Debug.Log("Hit transition false");
                transitions = false;
            }
        }

        if (transitions2 == true)
        {
            c.a -= fadeSpeed * Time.deltaTime;
            c.a = Mathf.Clamp01(c.a);

            fadeImage.color = c;

            if (c.a == 0)
                transitions2 = false;
        }
	
	}

    //broadcast method
	void transition(bool trans)
	{
		transitions = trans;
	}

    //beroadcast method
    void transition2(bool trans2)
    {
        transitions2 = trans2;
    }
}
