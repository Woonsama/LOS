using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    const float maxTime = 500;

    public static float currentTime = maxTime;

    Camera cam;

    private static GameObject _player;

    void Awake()
    {
        InitCamPos();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
    }

    private void InitCamPos()
    {
        cam = Camera.main;
        cam.transform.position = new Vector3(-18, 0, cam.transform.position.z);
    }

    private static float GetCurrentTime()
    {
        return currentTime;
    }
}
