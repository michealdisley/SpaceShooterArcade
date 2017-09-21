using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class DataManager
{
    private static Dictionary<string, string> localization;
    private static Dictionary<string, object> weapons;
    private static Dictionary<string, object> player;


    private static string systemLanguage;
    private static bool initialized;

    public static void Init()
    {
        if (!initialized)
        {
            systemLanguage = Application.systemLanguage.ToString();
            Debug.LogFormat("System Language: {0}", systemLanguage);

            initialized = true;
        }
    }

    public static IEnumerator DownloadData(string tab, Action<string[]> callback)
    {
        WWW sheet = new WWW("https://docs.google.com/spreadsheets/u/1/d/1FQdN4GMBmOcagUc07sm9f41LZ47nGs7Asoo_NzNHXOI/export?format=csv&id=1FQdN4GMBmOcagUc07sm9f41LZ47nGs7Asoo_NzNHXOI&gid=" + tab);

        while (!sheet.isDone)
            yield return null;

        Debug.Log(sheet.text);

        string[] rows = sheet.text.Split('\n');
        callback(rows);
    }

    public static void ProcessLocalization(string[] rows)
    {
        string[] languages = rows[0].Split(',');

        int languageIndex = 0;

        for (int i = 1; i < languages.Length; i++)
        {
            if (languages[i] == systemLanguage)
            {
                languageIndex = i;
                break;
            }
        }

        localization = new Dictionary<string, string>();

        for (int i = 1; i < rows.Length; i++)
        {
            string[] row = rows[i].Split(',');
            string key = row[0];
            string value = row[languageIndex];

            if (!localization.ContainsKey(key))
                localization.Add(key, value);
            else
                Debug.Log(" asdkfhawergarg key already exists" + key);
        }


        Debug.Log(LocalizeString("Confirm Yes"));
    }

    public static string LocalizeString(string key)
    {
        return localization[key];
    }

    public static void ProcessWeapons(string[] rows)
    {
        weapons = new Dictionary<string, object>();

        for (int i = 1; i < rows.Length; i++)
        {
            string[] row = rows[i].Split(',');
            string key = row[0];
            string type = row[1];

            if (type == "INT")
            {
                int value = Int32.Parse(row[2]);
                weapons.Add(key, value);
            }
            else if (type == "FLOAT")
            {
                float value = float.Parse(row[2]);
                weapons.Add(key, value);
            }
            else if(type == "BOOL")
            {
                bool value = bool.Parse(row[2]);
                weapons.Add(key, value);
            }
            else
            {
                weapons.Add(key, row[2]);
            }
        }
    }

    public static T GetWeapons<T>(string key)
    {
        T value = (T)weapons[key];
        return value;
    }

    public static void ProcessPlayer(string[] rows)
    {
        player = new Dictionary<string, object>();

        for (int i = 1; i < rows.Length; i++)
        {
            string[] row = rows[i].Split(',');
            string key = row[0];
            string type = row[1];

            if (type == "INT")
            {
                int value = Int32.Parse(row[2]);
                player.Add(key, value);
            }
            else if (type == "FLOAT")
            {
                float value = float.Parse(row[2]);
                player.Add(key, value);
            }
            else
            {
                player.Add(key, row[2]);
            }
        }
    }

    public static T GetPlayer<T>(string key)
    {
        T value = (T)player[key];
        return value;
    }
}
