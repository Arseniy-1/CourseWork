using System;

namespace PianoTiles
{
    public class Health
    {
        private int _health = 3;

        public event Action<int> HealthAmountChanged;
        public event Action LostHealth;

        public void TakeDamage()
        {
            _health--;

            HealthAmountChanged?.Invoke(_health);

            if (_health == 0)
                LostHealth?.Invoke();
        }
    }
}
