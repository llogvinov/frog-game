using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action GameOver;
    
    [SerializeField] private GameObject _frogGirl;
    
    private Camera _camera;
    
    private static GameManager _instance;

    private float _halfHeight;
    private float _halfWidth;

    #region Properties

    public static GameManager Instance => _instance;

    public float HalfHeight => _halfHeight;

    public float HalfWidth => _halfWidth;

    public GameObject FrogGirl => _frogGirl;

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
        }
        
        _camera = Camera.main;
        _halfHeight = _camera.orthographicSize;
        _halfWidth = _camera.aspect * _halfHeight;
    }
}