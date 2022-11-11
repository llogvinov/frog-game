using System;
using UnityEngine;

namespace FrogGame
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private bool _specifyPosition;
        [SerializeField] private Vector3 _specifiedPosition;

        public Vector3 Position { get; private set; }
        public bool IsOccupied { get; private set; }
        
        private void Awake()
        {
            Position = _specifyPosition ? _specifiedPosition : transform.position;
            IsOccupied = false;
        }

        public void OccupyTarget()
        {
            IsOccupied = true;
        }
    }
    
}