using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour {

	[ContextMenu("Show Data Path")]
	public void ShowApplicationDataPath() {
		Debug.Log(Application.dataPath.Replace("/Assets","/Builds") + "/OSX");
	}
}
