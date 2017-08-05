using UnityEditor;
using UnityEngine;

public class BuildScript
{

    static string[] devScenes = new string[] {  "Assets/_Scenes/DevBuild.unity" };
	static string[] relScenes = { "Assets / _Scenes / Main.unity" };

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

    [MenuItem("Tools/Builds/Windows/Development")]
    private static void BuildDevWindows()
    {
        BuildAndroid(true);
    }

    [MenuItem("Tools/Builds/Windows/Release")]
    private static void BuildRelWindows()
    {
        BuildAndroid(false);
    }

    private static void BuildOSX(bool isDev)
    {
        Debug.Log("Building OSX" + (isDev ? " DevPack" : ""));
        string buildPath = GetBuildPath("iOS");

        if (isDev)
            buildPath +=

        BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.StandaloneOSXUniversal, isDev ? BuildOptions.Development : BuildOptions.None);
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
            buildPath += BuildPipeline.BuildPlayer(relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
    }

    private static void BuildWindows(bool isDev)
    {
        Debug.Log("Building Windows" + (isDev ? " DevPack" : ""));
        string buildPath = GetBuildPath("Windows");

        if (isDev)
            buildPath +=

        BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.StandaloneWindows64, isDev ? BuildOptions.Development : BuildOptions.None);
    }

    private static string GetBuildPath(string subDirectory)
    {
        return Application.dataPath;
	}


}
