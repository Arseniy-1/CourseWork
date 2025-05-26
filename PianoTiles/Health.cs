using System;

namespace PianoTiles
{
    public class Health
    {
        private int _maxHealth;
        private int _currentHealth;

        public int CurrentHealth => _currentHealth;

        public event Action<int> HealthAmountChanged;
        public event Action LostHealth;

        public Health(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage()
        {
            if (_currentHealth > 0)
            {
                _currentHealth--;
                HealthAmountChanged?.Invoke(_currentHealth);

                if (_currentHealth == 0)
                {
                    LostHealth?.Invoke();
                }
            }
        }

        public void Reset()
        {
            _currentHealth = _maxHealth;
            HealthAmountChanged?.Invoke(_currentHealth);
        }
    }
}
