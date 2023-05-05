using UnityEngine;

namespace Player
{
    public class Health
    {
        private readonly int _minHealth;
        private readonly int _maxHealth;
    
        private int _currentHealth;

        public Health(int minHealth, int maxHealth)
        {
            _minHealth = minHealth;
            _maxHealth = maxHealth;

            ResetHealth();
        }

        public void TakeDamage(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - value, _minHealth, _maxHealth);
            CheckHealth();
        }

        public void Heal(int value)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + value, _minHealth, _maxHealth);
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
        }

        private void CheckHealth()
        {
            if (_currentHealth == _minHealth) 
                GameManager.Instance.GameOver?.Invoke();
        }
    }
}