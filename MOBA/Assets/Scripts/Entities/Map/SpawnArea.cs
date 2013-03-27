using UnityEngine;
using System.Collections;

public class SpawnArea : MonoBehaviour {
    public string Team;
    public float HealthRegen;
    public float EnergyRegen;

    private GameManager m_Manager;

	// Use this for initialization
	void Start () {
        m_Manager = GameObject.Find("Managers").GetComponent<GameManager>();
        renderer.material.color = Color.yellow;
	}

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Hero")
        {
            Hero hero = collisionInfo.gameObject.GetComponent<Hero>();
            if (m_Manager.GetTeamList(Team).Contains(hero))
            {
                hero.AddHealth(HealthRegen);
                hero.AddEnergy(EnergyRegen);
            }
        }
    }
}
