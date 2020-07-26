using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Born : Enemy
{
    public enum EState
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UP_LEFT,
        UP_RIGHT,
        DOWN_LEFT,
        DOWN_RIGHT,

        START = UP,
        END = DOWN_RIGHT,
    }

    private EState eState;

    [Header("해골 상태 변경 딜레이")]
    public float delay_State;

    [Header("몬스터가 반응하는 거리")]
    public float distance_Near;

    GameObject player;

    protected sealed override IEnumerator OnStartCoroutine()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Near_Check_Coroutine());
        StartCoroutine(State_Coroutine());

        yield break;
    }

    protected sealed override IEnumerator State_Coroutine()
    {
        while (true)
        {
            if (isNear)
            {
                yield return new WaitForSeconds(delay_State);
                Change_MoveState();
                StartCoroutine(Move_Coroutine());
            }

            yield return null;
        }
    }



    private IEnumerator Move_Coroutine()
    {
        switch (eState)
        {
            case EState.UP:
                transform.DOMoveY(transform.position.y + 1, 1);
                break;

            case EState.DOWN:
                transform.DOMoveY(transform.position.y - 1, 1);
                break;

            case EState.LEFT:
                transform.DOMoveX(transform.position.x - 1, 1);
                break;

            case EState.RIGHT:
                transform.DOMoveX(transform.position.x + 1, 1);
                break;

            case EState.UP_LEFT:
                transform.DOMove(new Vector2(transform.position.x - 1, transform.position.y + 1), 1);
                break;

            case EState.UP_RIGHT:
                transform.DOMove(new Vector2(transform.position.x + 1, transform.position.y + 1), 1);
                break;

            case EState.DOWN_LEFT:
                transform.DOMove(new Vector2(transform.position.x - 1, transform.position.y - 1), 1);
                break;

            case EState.DOWN_RIGHT:
                transform.DOMove(new Vector2(transform.position.x + 1, transform.position.y - 1), 1);
                break;
        }

        yield break;
    }

    private IEnumerator Near_Check_Coroutine()
    {
        while (true)
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= distance_Near &&
                Mathf.Abs(transform.position.y - player.transform.position.y) <= distance_Near)
            {
                isNear = true;
            }
            else
            {
                isNear = false;
            }

            yield return null;
        }
    }

    private void Change_MoveState()
    {
        eState = (EState)Random.Range((int)EState.START, (int)EState.END);
    }
}
