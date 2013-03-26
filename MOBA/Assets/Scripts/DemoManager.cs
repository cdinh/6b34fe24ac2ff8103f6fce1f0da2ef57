using UnityEngine;
using System.Collections;

public class DemoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject hero = GameObject.Find("Test Hero");
        GetComponent<GameManager>().AssignPlayer(hero.GetComponent<Hero>(), "Blue");
        //hero.GetComponent<Hero>().Initialize("Test", 5, 5, 5, 5, 20);
	}
}
