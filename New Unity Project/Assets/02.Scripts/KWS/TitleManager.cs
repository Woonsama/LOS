using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [Header("버튼 - 시작")]
    public Button button_Start;

    [Header("버튼 - 종료")]
    public Button button_Exit;

    private void Awake()
    {
        button_Start.onClick?.AddListener(OnClick_Start);
        button_Start.onClick?.AddListener(OnClick_Exit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) OnClick_Start();
        if (Input.GetKeyDown(KeyCode.Escape)) OnClick_Exit();

    }

    private void OnClick_Start()
    {
        SceneManager.Change_Scene(SceneManager.ESceneType.INGAME);
    }

    private void OnClick_Exit()
    {
        Application.Quit();
    }
}
