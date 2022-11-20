using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FrogGame
{
    public class FrogGirl : MonoBehaviour
    {
        [SerializeField] private Target[] _targets;

        private Target defaultTarget;
        
        public Target Target 
        {
            get
            {
                if (_targets.Length == 0)
                {
                    if (defaultTarget == null)
                    {
                        defaultTarget = new GameObject("default target").AddComponent<Target>();
                    }
                    return defaultTarget;
                }

                return GetRandomTarget();
            }
        }

        private Target GetRandomTarget()
        {
            // peek random target
            var randomTarget = _targets[Random.Range(0, _targets.Length)];
            if (!randomTarget.IsOccupied)
            {
                return randomTarget;
            }

            // if peeked target is occupied, loop through all targets and find non occupied
            foreach (var target in _targets)
            {
                if (!target.IsOccupied) return target;
            }

            // if all targets are occupied return random one
            return randomTarget;
        }

        public void CheckAllTargetsOccupied()
        {
            if (_targets.Any(target => !target.IsOccupied)) return;

            GameManager.Instance.GameOver?.Invoke();
        }
    }
}