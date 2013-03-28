using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public int MaxPlayers;

    private GameMode m_GameMode;
    private Dictionary<Team, List<Hero>> m_TeamLists;
    private Dictionary<Team, List<Hero>> m_DeadHeroes;
    private Dictionary<Team, int> m_TeamKills;

	// Use this for initialization
	void Start () {
        m_TeamLists = new Dictionary<Team, List<Hero>>();
        m_DeadHeroes = new Dictionary<Team, List<Hero>>();
        m_TeamKills = new Dictionary<Team, int>();

        RegisterTeam(Team.BLUE);
        RegisterTeam(Team.RED);

        m_GameMode = GetComponent<GameMode>();
        m_GameMode.Initialize(this);

        // Test
        Invoke("SpawnPlayers", 1);
	}

    public void Reset()
    {
        m_DeadHeroes.Clear();

        foreach (Team key in m_TeamKills.Keys)
        {
            m_TeamKills[key] = 0;
        }

        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        foreach (Team key in m_TeamLists.Keys)
        {
            GameObject[] areas = GameObject.FindGameObjectsWithTag("Spawn");
            SpawnArea teamArea = null;

            foreach (GameObject a in areas)
            {
                SpawnArea area = a.GetComponent<SpawnArea>();
                if (area.Team == key)
                {
                    teamArea = area;
                    break;
                }
            }

            if (teamArea != null)
            {
                foreach (Hero player in m_TeamLists[key])
                {
                    teamArea.Spawn(player);
                }
            }
        }
    }

    private void RegisterTeam(Team teamName)
    {
        m_TeamLists[teamName] = new List<Hero>();
        m_DeadHeroes[teamName] = new List<Hero>();
        m_TeamKills[teamName] = 0;
    }

    public bool AssignPlayer(Hero hero, Team team)
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

    public IList<Hero> GetTeamList(Team team)
    {
        return m_TeamLists[team];
    }

    public IList<Hero> GetDeadHeroes(Team team)
    {
        return m_DeadHeroes[team];
    }

    public int GetKills(Team team)
    {
        return m_TeamKills[team];
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        VictoryStatus status = m_GameMode.CheckVictoryConditions();
        if (status != VictoryStatus.NONE)
        {
            OnGameOver(status);
        }
    }

    private void OnGameOver(VictoryStatus winner)
    {
        Debug.Log(winner + " Wins!");
    }

    public void RegisterKill(Hero killer, Hero victim)
    {
        m_TeamKills[killer.Team]++;
        m_DeadHeroes[victim.Team].Add(victim);
    }
}
