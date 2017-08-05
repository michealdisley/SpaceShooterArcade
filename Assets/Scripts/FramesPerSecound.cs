using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramesPerSecound : MonoBehaviour
{
    // Floats
    private float fps;

    Rect fpsRect;
    GUIStyle font;

	// Use this for initialization
	void Start ()
    {

        fpsRect = new Rect(50, 50, 50, 50);
        font = new GUIStyle();
        font.fontSize = 20;

        StartCoroutine(CalculateFPS());
	}
	
    private IEnumerator CalculateFPS()
    {
        while (true)
        {
            fps = 1 / Time.deltaTime;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnGUI()
    {
        font.normal.textColor = Color.white;

        GUI.Label(fpsRect, "FPS: " + string.Format("{0:0.0}", fps), font);
    }
}
