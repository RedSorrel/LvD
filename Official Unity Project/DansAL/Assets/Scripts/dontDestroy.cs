using UnityEngine;
using System.Collections;

public class dontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
