using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //private static int NUMBER_OF_LEVELS = 2;


    public static GameManager Instance = null;
    public int levelindex = 0;
    public int levelStartDelay;
    private bool doingSetup;

    void Start()   //THIS FUNCTION IS CALLED AT THE START OF EVERY SCENE RELOAD
    {
        if (Instance == null) { Instance = this; } //For Singleton Pattern
        else { GameObject.Destroy(gameObject); }

        GameObject.DontDestroyOnLoad(gameObject); //So this is not destroyed when reloading scene -> THIS IS THE MAIN CLASS

        InitGame();
    }

    private void InitGame() {  //THIS FUNCTION IS FOR LEVEL SETUP SO NO UPDATE FUNCTIONS ARE CALLED BEFORE STUFF IS DONE
        doingSetup = true;
        //STUFF TO SET UP LEVEL (GET OBJECTS ETC) GOES HERE
        doingSetup = false;
    }

    // Update is called once per frame
    public void Update()
    {   
        if (!doingSetup) {


        }
        
    }

    //FUNCTION TO SWITCH SCENES by index!!!
    public void SwitchScene(int i)
    {
        Application.LoadLevel(i);
    }
    //FUNCTION TO SWITCH SCENES by string!!! (just in case)
    public void SwitchScene(string s)
    {
        Application.LoadLevel(s);
    }

}
