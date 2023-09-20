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

        public Target[] Targets => _targets;

        private void Start()
        {
            Target.Occupied += CheckAllTargetsOccupied;
        }

        private void OnDestroy()
        {
            Target.Occupied -= CheckAllTargetsOccupied;
        }

        public Target GetTarget()
        {
            if (Targets.Length != 0)
                return GetRandomTarget();

            if (_defaultTarget == null)
                _defaultTarget = new GameObject("default target").AddComponent<Target>();
            return _defaultTarget;
        }

        private Target GetRandomTarget()
        {
            var randomTarget = Targets[Random.Range(0, Targets.Length)];
            if (!randomTarget.IsOccupied)
                return randomTarget;

            foreach (var target in Targets)
                if (!target.IsOccupied)
                    return target;

            return randomTarget;
        }

        private void CheckAllTargetsOccupied()
        {
            if (Targets.Any(target => !target.IsOccupied)) return;

            Game.GameOver?.Invoke();
        }
    }
}