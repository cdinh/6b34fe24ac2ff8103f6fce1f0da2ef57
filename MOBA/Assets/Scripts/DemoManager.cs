using UnityEngine;
using System.Collections;

public class DemoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject hero = GameObject.Find("Test Hero");
        Pawn pawn = hero.GetComponent<Pawn>();
        pawn.SetSpeed(20);

        KBMHeroController controller = GetComponent<KBMHeroController>();
        controller.AttachPawn(pawn);
	}
}
