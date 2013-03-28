using UnityEngine;
using System.Collections;

public abstract class ControlPointEffect : MonoBehaviour 
{
    public float Radius;

    private ControlPoint m_ControlPoint;
    private GameManager m_Manager;
	// Use this for initialization
	void Start () {
        m_ControlPoint = GetComponent<ControlPoint>();
        m_Manager = GameObject.Find("Managers").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (m_ControlPoint.Team)
        {
            case Team.BLUE:
            case Team.RED:
                foreach (Hero hero in m_Manager.GetTeamList(m_ControlPoint.Team))
                {
                    if (GameUtility.DistanceSquared(transform, hero.transform) <= Radius * Radius)
                    {
                        ApplyEffect(hero);
                    }
                }
                break;
            default:
                break;
        }
	}

    protected abstract void ApplyEffect(Hero hero);
}
