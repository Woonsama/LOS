using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    protected virtual IEnumerator OnStartCoroutine()
    {
        yield break;
    }

    private void Awake()
    {
        StartCoroutine(OnStartCoroutine());
    }
}
