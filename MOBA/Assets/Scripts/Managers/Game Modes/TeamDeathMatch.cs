using UnityEngine;
using System.Collections;

public class TeamDeathMatch : GameMode {
    public int RoundsToWin;

    public int BlueRoundsWon;
    public  int RedRoundsWon;

    private VictoryStatus m_Winner;

    void Start()
    {
        BlueRoundsWon = 0;
        RedRoundsWon = 0;

        m_Winner = VictoryStatus.NONE;

        gameObject.AddComponent<TeamDeathMatchGUI>();
    }

    void FixedUpdate()
    {
        if (m_GameManager.GetDeadHeroes(Team.BLUE).Count >= m_GameManager.GetTeamList(Team.BLUE).Count)
        {
            RedRoundsWon++;

            if (RedRoundsWon >= RoundsToWin)
                m_Winner = VictoryStatus.RED;
            else
                m_GameManager.Reset();
        }
        else if (m_GameManager.GetDeadHeroes(Team.RED).Count >= m_GameManager.GetTeamList(Team.RED).Count)
        {
            BlueRoundsWon++;

            if (BlueRoundsWon >= RoundsToWin)
                m_Winner = VictoryStatus.BLUE;
            else
                m_GameManager.Reset();
        }
    }
    
    private void ResetRound()
    {
        m_GameManager.Reset();
    }

    public override VictoryStatus CheckVictoryConditions()
    {
        return m_Winner;
    }
}
