using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(Coroutine());
    }

    IEnumerator Coroutine()
    {

        yield return new WaitForSeconds(1f);
        Debug.Log("Main menu called.");
        SceneManager.LoadScene("Main Menu");
    }
}
