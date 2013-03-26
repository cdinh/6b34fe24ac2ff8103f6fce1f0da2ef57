using UnityEngine;
using System.Collections;

public class EnergyRegenerator : ControlPointEffect {

    public float EnergyRegen;

    protected override void ApplyEffect(Hero hero)
    {
        hero.AddEnergy(EnergyRegen);
    }
}
