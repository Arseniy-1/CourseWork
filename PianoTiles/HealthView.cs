using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PianoTiles
{
    public class HealthView
    {
        private List<PictureBox> _heartViews;
        private Health _health;

        public HealthView(Health health, List<PictureBox> heartViews)
        {
            _health = health;
            _heartViews = heartViews;

            Console.WriteLine(_heartViews.Count);
              
            _health.HealthAmountChanged += ShowHealth;
        }

        private void ShowHealth(int healthAmount)
        {
            for (int i = 0; i < _heartViews.Count; i++)
            {
                if(i < healthAmount)
                {
                    _heartViews[i].Visible = true;
                }
                else
                {
                    _heartViews[i].Visible = false;
                }
            }
        }
    }
}
