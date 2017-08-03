using UnityEditor;
using UnityEngine;

public class BuildScript {
	static string[] devScenes = {  "Assets/Scenes/DevGame.unity" };
	static string[] relScenes = {  };

	[MenuItem("Builds/OSX/Development")]
	private static void BuildDevOSX() {
		BuildOSX(true);
	}


	private static void BuildRelOSX() {
		BuildOSX(false);
	}


	private static void BuildOSX(bool isDev) {
		Debug.Log("Building OSX" + (isDev ? " Dev" : "") );
		string buildPath =  GetBuildPath("OSX");

		if(isDev)
			buildPath += 

		BuildPipeline.BuildPlayer( isDev ? devScenes : relScenes, buildPath, BuildTarget.StandaloneOSXUniversal, isDev ? BuildOptions.Development : BuildOptions.None);
	}

	private static string GetBuildPath(string subDirectory) {
        return Application.dataPath;
	}

}
