using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public enum ESceneType
    {
        TITLE,
        INGAME,
    }

    public static void Change_Scene(ESceneType eSceneType)
    {
        if(eSceneType == ESceneType.TITLE) UnityEngine.SceneManagement.SceneManager.LoadScene("Title");

        if (eSceneType == ESceneType.INGAME) UnityEngine.SceneManagement.SceneManager.LoadScene("Ingame");
    }
}
