
 










using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.GUI;
using BubbleShooterGameToolkit.Scripts.Settings;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Boosts
{
    public abstract class PowerFillBoostResource : BoostResource
    {
        protected abstract EPower _ePower { get; }

        public override bool Activate(BoostParameters parameters)
        {
            if (!base.Activate(parameters)) return false;

            // Fill the power collector
            foreach (var powerCollector in GameObject.FindObjectsOfType<PowerCollector>())
            {
                // if (powerCollector.powerType == _ePower)
                // {
                //     powerCollector.Fill();
                //     break;
                // }
            }

            return true;
        }
    }
}