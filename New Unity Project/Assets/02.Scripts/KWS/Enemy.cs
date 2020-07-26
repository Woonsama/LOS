using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : ObjectBase
{

    /// <summary>
    /// 플레이어와 몬스터가 가까워 졌는지 체크
    /// </summary>
    public bool isNear;
    /// <summary>
    /// 몬스터가 죽었는지 체크
    /// </summary>
    private bool isDead;


    [Header("몬스터 체력")]
    public float hp;

    [Header("몬스터 공격력")]
    public float attack;

    protected override IEnumerator OnStartCoroutine()
    {
        isNear = false;

        StartCoroutine(Dead_Check_Coroutine());
        yield break;        
    }

    protected virtual IEnumerator State_Coroutine()
    {
        yield break;
    }


    private IEnumerator  Dead_Check_Coroutine()
    {
        while(!isDead)
        {
            if (hp <= 0)
            {
                isDead = true;
                Destroy(this.gameObject,2);
                yield break;
            }
            yield return null;
        }
    }
}
