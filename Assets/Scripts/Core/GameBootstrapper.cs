using Core.StateMachine;
using UnityEngine;

namespace Core
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        private Camera _camera;
        private static float _halfHeight;
        private static float _halfWidth;

        private static GameBootstrapper _instance;
        
        #region Properties

        public static float HalfHeight => _halfHeight;
        public static float HalfWidth => _halfWidth;

        #endregion

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            _camera = Camera.main;
            _halfHeight = _camera.orthographicSize;
            _halfWidth = _camera.aspect * _halfHeight;
            
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
            DontDestroyOnLoad(_camera);
        }
    }
}