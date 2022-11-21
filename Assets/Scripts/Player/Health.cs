using System;
using UnityEngine;

public class Health
{
    private readonly int _minHealth;
    private readonly int _maxHealth;
    
    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public Health(int minHealth, int maxHealth)
    {
        _minHealth = minHealth;
        _maxHealth = maxHealth;

        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;
        Mathf.Clamp(_currentHealth - value, _minHealth, _maxHealth);
        
        if (_currentHealth == _minHealth)
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

    public void Heal(int value)
    {
        _currentHealth += value;
        Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }
}