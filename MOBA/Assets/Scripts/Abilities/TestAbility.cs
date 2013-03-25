using UnityEngine;
using System.Collections;

public class TestAbility : Ability {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected override bool OnCast()
    {
        Debug.Log("Casted!");
        return true;
    }
}
