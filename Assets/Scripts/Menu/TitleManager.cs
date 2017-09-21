using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    IEnumerator Start()
    {
        DataManager.Init();

        //wait for data manager to load everything
        yield return StartCoroutine(DataManager.DownloadData("0", DataManager.ProcessLocalization));

        yield return StartCoroutine(DataManager.DownloadData("2143523714", DataManager.ProcessWeapons));

        yield return StartCoroutine(DataManager.DownloadData("884449625", DataManager.ProcessPlayer));

        Debug.LogFormat("Our current weapon:", DataManager.GetWeapons<bool>("Bolt"));

        //load our actual game scene
        Debug.Log("Finished loading data, switching scenes");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Menu");
    }

    //IEnumerator Coroutine()
    //{

    //    yield return new WaitForSeconds(1f);
    //    Debug.Log("Main menu called.");
    //    SceneManager.LoadScene("Main Menu");
    //}
}
