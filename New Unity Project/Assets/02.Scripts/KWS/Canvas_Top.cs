using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Top : CanvasBase
{
    [Header("남은 시간")]
    public Text text_LeftTime;

    private bool isTimeLeft = false;

    protected override IEnumerator OnShowCoroutine()
    {
        StartCoroutine(TimeChecker_Coroutine());
        yield break;
    }

    private IEnumerator TimeChecker_Coroutine()
    {
        while(!isTimeLeft)
        {
            text_LeftTime.text = "LeftTime : " + (int)InGameManager.currentTime;
            yield return null;
        }

        StartCoroutine(GameOver_Coroutine());
        yield break;
    }

    private IEnumerator GameOver_Coroutine()
    {
        SceneManager.Change_Scene(SceneManager.ESceneType.TITLE);
        yield break;
    }
}
