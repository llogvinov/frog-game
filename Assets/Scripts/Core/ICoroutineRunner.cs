using System.Collections;
using UnityEngine;

namespace Core
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}