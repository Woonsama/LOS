using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBase : MonoBehaviour
{
    protected virtual IEnumerator OnShowCoroutine()
    {
        yield break;
    }

    protected virtual IEnumerator OnEnableCoroutine()
    {
        yield break;
    }

    protected virtual IEnumerator OnDisableCoroutine()
    {
        yield break;
    }

    private void Awake()
    {
        StartCoroutine(OnShowCoroutine());
    }

    private void OnEnable()
    {
        StartCoroutine(OnEnableCoroutine());
    }

    private void OnDisable()
    {
        StartCoroutine(OnDisableCoroutine());
    }
}
