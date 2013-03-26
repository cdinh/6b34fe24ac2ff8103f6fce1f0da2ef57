using UnityEngine;
using System.Collections;

public class TestAbility : Ability {
    protected override bool OnCast()
    {
        Debug.Log("Casted!");
        return true;
    }
}
