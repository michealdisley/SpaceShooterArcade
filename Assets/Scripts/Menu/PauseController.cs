using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseController : MonoBehaviour
{
    private MenuController MC;
	// Use this for initialization
	void Start ()
    {
        MC = GameObject.Find("GameController").GetComponent<MenuController>();
	}

    public void Continue()
    {
        MC.Pause();
    }

    public void Restart()
    {
        MC.Restart();
    }

    public void MainMenu()
    {
        MC.MainMenu();
    }

    public void EXIT()
    {
        MC.EXIT();
    }
}
