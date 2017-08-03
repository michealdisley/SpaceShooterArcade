using UnityEditor;
using UnityEngine;

public class BuildScript
{

    static string[] devScenes = new string[] {  "Assets/Scenes/DevGame.unity" };
	static string[] relScenes = {  };

    [MenuItem("Tools/Builds/OSX/Development")]
    private static void BuildDevOSX()
    {
        BuildOSX(true);
    }

    [MenuItem("Tools/Builds/OSX/Release")]
    private static void BuildRelOSX()
    {
        BuildOSX(false);
    }

    [MenuItem("Tools/Builds/Andriod/Development")]
    private static void BuildDevAndriod()
    {
        BuildAndroid(true);
    }

    [MenuItem("Tools/Builds/Andriod/Release")]
    private static void BuildRelAndroid()
    {
		BuildAndroid(false);
	}

    private static void BuildOSX(bool isDev) {
		Debug.Log("Building OSX" + (isDev ? " Dev" : "") );
		string buildPath =  GetBuildPath("OSX");

		if(isDev)
			buildPath += 

		BuildPipeline.BuildPlayer( isDev ? devScenes : relScenes, buildPath, BuildTarget.StandaloneOSXUniversal, isDev ? BuildOptions.Development : BuildOptions.None);
	}

    private static void BuildAndroid(bool isDev)
    {
        Debug.Log("Building Android" + (isDev ? " Dev" : ""));
        string buildPath = GetBuildPath("Android");

        if (isDev)
            buildPath +=

        BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
    }

    private static string GetBuildPath(string subDirectory)
    {
        return Application.dataPath;
	}


}
