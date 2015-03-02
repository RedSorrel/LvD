using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenuGui : MonoBehaviour {

    public Canvas quitMenu;
    public Button Play;
    public Button Quit;
    // GameObject test;

    /*void OnGUI()
    {
        GUILayout.BeginArea(new Rect(400, 200, 400, Screen.width / 2));

        GUILayout.BeginHorizontal();
        GUILayout.Label("Main Menu");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Play"))
        {
            Application.LoadLevel(1);
        }
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }*/

    // Use this for initialization
    void Start()
    {
        //test = GameObject.Find("Text");

        quitMenu = quitMenu.GetComponent<Canvas>();
        Play = Play.GetComponent<Button>();
        Quit = Quit.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void Exit()
    {
        quitMenu.enabled = true;
        Play.enabled = false;
        Quit.enabled = false;
    }

    public void noPress()
    {
        quitMenu.enabled = false;
        Play.enabled = true;
        Quit.enabled = true;
    }

    public void StartLevel()
    {
        Application.LoadLevel(3);
    }

    public void exitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
