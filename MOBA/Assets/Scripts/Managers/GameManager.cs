using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public int MaxPlayers;

    private GameMode m_GameMode;
    private Dictionary<string, List<Hero>> m_TeamLists;

	// Use this for initialization
	void Start () {
        m_TeamLists = new Dictionary<string,List<Hero>>();
        m_TeamLists["Blue"] = new List<Hero>();
        m_TeamLists["Red"] = new List<Hero>();

        //m_GameMode = GetComponent<GameMode>();
        //m_GameMode.Create(this);
	}

    public bool AssignPlayer(Hero hero, string team)
    {
        List<Hero> teamList = m_TeamLists[team];
        if (teamList.Count >= MaxPlayers >> 1)
            return false;
        else
        {
            teamList.Add(hero);
            hero.Team = team;
            return true;
        }
    }

    public IList<Hero> GetTeamList(string team)
    {
        return m_TeamLists[team];
    }
	
	// Update is called once per frame
	void Update () {
        //VictoryStatus status = m_GameMode.CheckVictoryConditions();
        //if (status != VictoryStatus.NONE)
        //{
        //    OnGameOver(status);
        //}
	}

    private void OnGameOver(VictoryStatus winner)
    {

    }
}
