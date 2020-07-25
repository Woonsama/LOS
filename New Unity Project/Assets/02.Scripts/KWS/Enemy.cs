using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectBase
{

    Vector3 playerPos;

    /// <summary>
    /// 플레이어와 몬스터가 가까워 졌는지 체크
    /// </summary>
    protected bool isNear;
    /// <summary>
    /// 몬스터가 죽었는지 체크
    /// </summary>
    private bool isDead;

    /// <summary>
    /// 얼마나 가까우면 반응하는지 거리
    /// </summary>
    [Header("몬스터가 반응하는 거리")]
    public float distance_Near;

    [Header("몬스터 체력")]
    public float hp;

    [Header("몬스터 공격력")]
    public float attack;

    protected override IEnumerator OnStartCoroutine()
    {
        isNear = false;
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;

        StartCoroutine(Near_Check_Coroutine());
        yield break;        
    }

    protected virtual IEnumerator State_Coroutine()
    {
        yield break;
    }

    private IEnumerator Near_Check_Coroutine()
    {
        while(!isNear)
        {
            if(Mathf.Abs(transform.position.x - playerPos.x) <= distance_Near ||
                Mathf.Abs(transform.position.y - playerPos.y) <= distance_Near)
            {
                isNear = true;
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator  Dead_Check_Coroutine()
    {
        while(!isDead)
        {
            if (hp <= 0)
            {
                isDead = true;
                Destroy(this.gameObject);
                yield break;
            }
            yield return null;
        }
    }
}
