using UnityEditor;
using UnityEngine;

public class BuildScript
{

    static string[] devScenes = new string[] {  "Assets/_Scenes/DevBuild.unity" };
	static string[] relScenes = { "Assets / _Scenes / Main.unity" };

    [MenuItem("Tools/Builds/IOS/Development")]
    private static void BuildDevOSX()
    {
        BuildOSX(true);
    }

    [MenuItem("Tools/Builds/IOS/Release")]
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

    private static void BuildOSX(bool isDev)
    {
		Debug.Log("Building iOS" + (isDev ? " DevPack" : "") );
		string buildPath =  GetBuildPath("iOS");

		if(isDev)
			buildPath += 

		BuildPipeline.BuildPlayer( isDev ? devScenes : relScenes, buildPath, BuildTarget.iOS, isDev ? BuildOptions.Development : BuildOptions.None);
	}

    private static void BuildAndroid(bool isDev)
    {
        Debug.Log("Building Android" + (isDev ? " DevPack" : ""));
        string buildPath = GetBuildPath("Android");

        if (isDev)
        {
            buildPath += BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
        else
        {
            BuildPipeline.BuildPlayer(relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
    }

    private static string GetBuildPath(string subDirectory)
    {
        return Application.dataPath;
	}


}
