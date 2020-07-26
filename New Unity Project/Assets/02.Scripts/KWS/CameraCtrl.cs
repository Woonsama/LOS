using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraCtrl : MonoBehaviour
{
    Vector2 stage_0_Pos = new Vector2(-18, 0);
    Vector2 stage_12_Pos = new Vector2(0, 20);
    Vector2 stage_1_Pos = new Vector2(0, 0);
    Vector2 stage_2_Pos = new Vector2(0, -10);
    Vector2 stage_14_Pos = new Vector2(0, -30);
    Vector2 stage_5_Pos = new Vector2(18, 10);
    Vector2 stage_3_Pos = new Vector2(18, 0);
    Vector2 stage_4_Pos = new Vector2(18, -10);
    Vector2 stage_7_Pos = new Vector2(18, -20);
    Vector2 stage_11_Pos = new Vector2(18, -30);
    Vector2 stage_6_Pos = new Vector2(36, 10);
    Vector2 stage_9_Pos = new Vector2(36, 0);
    Vector2 stage_8_Pos = new Vector2(36, -10);
    Vector2 stage_10_Pos = new Vector2(54, 0);
    Vector2 stage_13_Pos = new Vector2(54, 10);

    public enum ECamera_Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    const float offset_x = 9.0f;
    const float offset_y = 5.0f;

    const float camera_z = -10;

    [Header("카메라 부드러움 농도")]
    public float smooth;

    [Header("Player 플레이어")]
    public Player player;

    [Header("카메라")]
    public Camera cam;

    private void Awake()
    {
        StartCoroutine(Player_Position_Check());
    }

    private IEnumerator Player_Position_Check()
    {
        while(true)
        {
            if((player.transform.position.x > cam.transform.position.x + offset_x || player.transform.position.x < cam.transform.position.x - offset_x )||
                (player.transform.position.y > cam.transform.position.y + offset_y || player.transform.position.y < cam.transform.position.y - offset_y))
            {
                if (player.transform.position.x > cam.transform.position.x + offset_x)
                    Lerp_Camera(ECamera_Direction.RIGHT);
                if (player.transform.position.x < cam.transform.position.x - offset_x)
                        Lerp_Camera(ECamera_Direction.LEFT);
                if (player.transform.position.y > cam.transform.position.y + offset_y)
                        Lerp_Camera(ECamera_Direction.UP);
                if (player.transform.position.y < cam.transform.position.y - offset_y)
                        Lerp_Camera(ECamera_Direction.DOWN);

                    yield break;
            }

            yield return null;
        }
    }

    private void Lerp_Camera(ECamera_Direction eCamera_Direction)
    {
        Debug.Log(eCamera_Direction);

        switch(eCamera_Direction)
        {
            case ECamera_Direction.UP:
                cam.transform.DOMove(new Vector3(cam.transform.position.x, cam.transform.position.y + 10, camera_z), smooth).OnComplete(OnComplete_Lerp);
                break;

            case ECamera_Direction.DOWN:
                cam.transform.DOMove(new Vector3(cam.transform.position.x, cam.transform.position.y - 10, camera_z), smooth).OnComplete(OnComplete_Lerp);
                break;

            case ECamera_Direction.LEFT:
                cam.transform.DOMove(new Vector3(cam.transform.position.x + -18, cam.transform.position.y, camera_z), smooth).OnComplete(OnComplete_Lerp);
                break;

            case ECamera_Direction.RIGHT:
            cam.transform.DOMove(new Vector3(cam.transform.position.x + 18, cam.transform.position.y, camera_z), smooth).OnComplete(OnComplete_Lerp);
                break;
        }        
    }

    private void OnComplete_Lerp()
    {
        Debug.Log("다시 체크");
        StartCoroutine(Player_Position_Check());
    }
}

