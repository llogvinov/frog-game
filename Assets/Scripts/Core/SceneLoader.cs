using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner) 
            => _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null)
            => _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        
        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            AsyncOperation waitLoadScene = SceneManager.LoadSceneAsync(name);

            while (!waitLoadScene.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}