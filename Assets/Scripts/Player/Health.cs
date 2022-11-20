using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const int MinHealth = 0;
    private const int MaxHealth = 100;
    
    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;
        Mathf.Clamp(_currentHealth - value, MinHealth, MaxHealth);
        
        if (_currentHealth == MinHealth)
        {
            GameManager.Instance.GameOver?.Invoke();
        }
    }

    public void Heal(int value)
    {
        _currentHealth += value;
        Mathf.Clamp(_currentHealth, MinHealth, MaxHealth);
    }

    public void ResetHealth()
    {
        _currentHealth = MaxHealth;
    }
}