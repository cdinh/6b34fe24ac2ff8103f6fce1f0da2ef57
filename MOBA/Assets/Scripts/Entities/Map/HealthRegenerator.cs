using UnityEngine;
using System.Collections;

public class HealthRegenerator : ControlPointEffect {

    public float HealthRegen;

    protected override void ApplyEffect(Hero hero)
    {
        hero.AddHealth(HealthRegen);
    }
}
