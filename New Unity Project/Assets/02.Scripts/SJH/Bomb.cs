using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ObjectBase
{

    Animator anim;

    protected override IEnumerator OnStartCoroutine()
    {
        anim = GetComponent<Animator>();

        Invoke("BombSpawn", 1);

        yield break;
    }


    void BombSpawn()
    {
        anim.SetBool("Bomb", true);
        Invoke("Destroy", 0.3f);
    }

    void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

}
