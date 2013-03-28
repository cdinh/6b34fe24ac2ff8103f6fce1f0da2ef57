using UnityEngine;
using System.Collections;

public class SpawnArea : MonoBehaviour {
    public Team Team;
    public float HealthRegen;
    public float EnergyRegen;

    private GameManager m_Manager;

	// Use this for initialization
	void Start () {
        m_Manager = GameObject.Find("Managers").GetComponent<GameManager>();

        if (Team == Team.BLUE)
            renderer.material.color = Color.blue;
        else if (Team == Team.RED)
            renderer.material.color = Color.red;
	}

    void OnDestroy()
    {
        DestroyImmediate(renderer.material);
    }

    public void Spawn(Hero hero)
    {
        Vector3 size = renderer.bounds.size;
        float smallest = Mathf.Min(size.x / 2, size.z / 2);

        Vector2 randomPoint = Random.insideUnitCircle * smallest;
        Vector3 spawnPosition = new Vector3(collider.bounds.center.x + randomPoint.x, transform.position.y, collider.bounds.center.z + randomPoint.y);
        hero.Spawn(spawnPosition);
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
