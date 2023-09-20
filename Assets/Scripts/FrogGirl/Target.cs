using System;
using System.Collections.Generic;
using FrogGame.Enemy;
using UnityEngine;

namespace FrogGirl
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private bool _specifyPosition;
        [SerializeField] private Vector3 _specifiedPosition;
        
        public Vector3 Position { get; private set; }
        public bool IsOccupied { get; private set; }
        public List<EatableEnemyMover> Enemies { get; private set; }

        public static Action Occupied;

        private void Awake()
        {
            Position = _specifyPosition ? _specifiedPosition : transform.position;
            Enemies = new List<EatableEnemyMover>();
            IsOccupied = false;
        }

        public void OccupyTarget(EatableEnemyMover enemyMover)
        {
            IsOccupied = true;
            Enemies.Add(enemyMover);
            
            Occupied?.Invoke();
        }

        public void ReleaseEnemyFromTarget()
        {
            if (!IsOccupied || Enemies == null) return;

            foreach (var enemy in Enemies) 
                enemy.ReleaseEnemyFromTarget();
            
            IsOccupied = false;
            Enemies.Clear();
        }
    }
    
}