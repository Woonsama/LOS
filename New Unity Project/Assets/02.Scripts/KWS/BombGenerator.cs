using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : ObjectBase
{
    [Header("폭탄 - Bomb")]
    public GameObject bomb;

    [Header("플레이어 - 포지션 참고용")]
    public Player player;

    [Header("처음 가지고 있는 폭탄의 수")]
    public int bomb_Count;

    protected sealed override IEnumerator OnStartCoroutine()
    {
        StartCoroutine(GenerateBomb_Coroutine());
        yield break;
    }

    private IEnumerator GenerateBomb_Coroutine()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.X) && bomb_Count > 0)
            {
                Instantiate(bomb, player.transform.position, Quaternion.identity);
                bomb_Count--;
            }

            yield return null;
        }
    }
}
