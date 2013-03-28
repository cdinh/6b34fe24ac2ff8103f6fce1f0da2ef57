using UnityEngine;
using System.Collections;

public class DemoManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject hero = GameObject.Find("pikachu");
        GetComponent<GameManager>().AssignPlayer(hero.GetComponent<Hero>(), Team.BLUE);

        hero = GameObject.Find("enemy");
        GetComponent<GameManager>().AssignPlayer(hero.GetComponent<Hero>(), Team.RED);
        //hero.GetComponent<Hero>().Initialize("Test", 5, 5, 5, 5, 20);
	}
}
