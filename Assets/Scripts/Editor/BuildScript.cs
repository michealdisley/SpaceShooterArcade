using System;
using UnityEditor;
using UnityEngine;

public class BuildScript
{

    static string[] devScenes = new string[] 
    {
        "Assets/_Scenes/Menu/Title.unity",
        "Assets/_Scenes/Menu/Main Menu.unity",
        "Assets/_Scenes/Menu/Hud.unity",
        "Assets/_Scenes/Menu/Level Complete.unity",
        "Assets/_Scenes/Menu/Game Over.unity",

        "Assets/_Scenes/DevBuild.unity",
    };
    static string[] relScenes = 
    {
        "Assets/_Scenes/Menu/Title.unity",
        "Assets/_Scenes/Menu/Main Menu.unity",
        "Assets/_Scenes/Menu/Hud.unity",
        "Assets/_Scenes/Menu/Level Complete.unity",
        "Assets/_Scenes/Menu/Game Over.unity",

        "Assets/_Scenes/Level 1.unity"
    };

    [MenuItem("Tools/Builds/All")]
    private static void BuildAll()
    {
        BuildOSX(true);
        BuildOSX(false);

        BuildAndroid(true);
        BuildAndroid(false);

        BuildWindows(true);
        BuildWindows(false);
    }

    [MenuItem("Tools/Builds/OSX/Both")]
    private static void BuildAllOSX()
    {
        BuildOSX(true);
        BuildOSX(false);
    }

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

    [MenuItem("Tools/Builds/Andriod/Both")]
    private static void BuildAllAndriod()
    {
        BuildAndroid(true);
        BuildAndroid(false);
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

    [MenuItem("Tools/Builds/Windows/Both")]
    private static void BuilAllWindows()
    {
        BuildWindows(true);
        BuildWindows(false);
    }

    [MenuItem("Tools/Builds/Windows/Development")]
    private static void BuildDevWindows()
    {
        BuildWindows(true);
    }

    [MenuItem("Tools/Builds/Windows/Release")]
    private static void BuildRelWindows()
    {
        BuildWindows(false);
    }

    private static void BuildOSX(bool isDev)
    {
        Debug.Log("Building OSX" + (isDev ? " DevPack" : ""));
        // string buildPath = GetBuildPath("iOS");

        if (isDev)
        {
            string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/DevBuild/iOS/SpaceShooter.exe" + string.Format("{0 :yyyy-MM-dd_hh}", DateTime.Now);
            BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
        else
        {
            string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/Build/iOS/SpaceShooter.exe" + string.Format("{0 :yyyy-MM-dd_hh}", DateTime.Now);
            BuildPipeline.BuildPlayer(relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
    }

    private static void BuildAndroid(bool isDev)
    {
        Debug.Log("Building Android" + (isDev ? " DevPack" : ""));
        // string buildPath = GetBuildPath("Android");

        if (isDev)
        {
            string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/DevBuild/Android/SpaceShooter.apk" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);
            BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
        else
        {
            string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/Build/Android/SpaceShooter.apk" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);
            BuildPipeline.BuildPlayer(relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
    }

    private static void BuildWindows(bool isDev)
    {
        Debug.Log("Building Windows" + (isDev ? " DevPack" : ""));
        // string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/Build/Windows/SpaceShooter.exe" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);

        if (isDev)
        {
            string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/DevBuild/Windows/SpaceShooter.exe" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);
            BuildPipeline.BuildPlayer(isDev ? devScenes : relScenes, buildPath, BuildTarget.StandaloneWindows64, isDev ? BuildOptions.Development : BuildOptions.None);
        }
        else
        {
            string buildPath = "C:/Users/easyhome/Documents/SpaceShooterArcade/Build/Windows/SpaceShooter.exe" + string.Format("{0:yyyy-MM-dd_hh-mm}", DateTime.Now);
            BuildPipeline.BuildPlayer(relScenes, buildPath, BuildTarget.Android, isDev ? BuildOptions.Development : BuildOptions.None);
        }
    }

    private static string GetBuildPath(string subDirectory)
    {
        return Application.dataPath;
	}

}
