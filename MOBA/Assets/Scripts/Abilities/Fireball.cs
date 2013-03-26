using UnityEngine;
using System.Collections;

public class Fireball : Ability {

    public GameObject fireball;

	// Use this for initialization
	void Start () {
        
        fireball.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
    protected override bool OnCast()
    {
        Debug.Log("Spell Cast!");
        GameObject f = Instantiate(fireball, transform.parent.position + transform.forward * 1.5f, transform.parent.rotation) as GameObject;
        f.GetComponent<FireballProjectile>().owner = Owner;
        return true;
	}
}
