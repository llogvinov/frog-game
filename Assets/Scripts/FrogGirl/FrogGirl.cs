using System;
using System.Linq;
using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FrogGirl
{
    public class FrogGirl : MonoBehaviour
    {
        [SerializeField] private Target[] _targets;

        private Target _defaultTarget;
        
        public Target Target 
        {
            get
            {
                if (_targets.Length != 0) 
                    return GetRandomTarget();
                
                if (_defaultTarget == null) 
                    _defaultTarget = new GameObject("default target").AddComponent<Target>();
                return _defaultTarget;
            }
        }

        private Target GetRandomTarget()
        {
            var randomTarget = _targets[Random.Range(0, _targets.Length)];
            if (!randomTarget.IsOccupied)
                return randomTarget;
            
            foreach (var target in _targets)
                if (!target.IsOccupied) return target;

            return randomTarget;
        }

        public void CheckAllTargetsOccupied()
        {
            if (_targets.Any(target => !target.IsOccupied)) return;

            Game.GameOver?.Invoke();
        }
    }
}