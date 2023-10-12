using System;
using Core;

namespace Main.Player
{
    public class Health
    {
        private readonly int _minHealth;
        private readonly int _maxHealth;

        public int CurrentHealth { get; private set; }

        public static Action<Health> OnHealthChanged;

        public Health(int minHealth, int maxHealth)
        {
            _minHealth = minHealth;
            _maxHealth = maxHealth;

            ResetHealth();
        }

        public void TakeDamage(int value)
        {
            CurrentHealth = Math.Clamp(CurrentHealth - value, _minHealth, _maxHealth);
            OnHealthChanged?.Invoke(this);
            CheckHealth();
        }

        public void Heal(int value)
        {
            CurrentHealth = Math.Clamp(CurrentHealth + value, _minHealth, _maxHealth);
            OnHealthChanged?.Invoke(this);
        }

        public void ResetHealth()
        {
            CurrentHealth = _maxHealth;
            OnHealthChanged?.Invoke(this);
        }

        private void CheckHealth()
        {
            if (CurrentHealth == _minHealth) 
                Game.GameOver?.Invoke();
        }
    }
}