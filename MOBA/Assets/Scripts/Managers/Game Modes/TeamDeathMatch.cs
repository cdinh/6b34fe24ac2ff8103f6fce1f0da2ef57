using UnityEngine;
using System.Collections;

public class TeamDeathMatch : GameMode {
    public int RoundsToWin;

    private int m_BlueRoundsWon;
    private int m_RedRoundsWon;

    private VictoryStatus m_Winner;

    void Start()
    {
        m_BlueRoundsWon = 0;
        m_RedRoundsWon = 0;

        m_Winner = VictoryStatus.NONE;
    }

    void FixedUpdate()
    {
        if (m_GameManager.GetDeadHeroes(Team.BLUE).Count >= m_GameManager.GetTeamList(Team.BLUE).Count)
        {
            m_RedRoundsWon++;

            if (m_RedRoundsWon >= RoundsToWin)
                m_Winner = VictoryStatus.RED;
            else
                m_GameManager.Reset();
        }
        else if (m_GameManager.GetDeadHeroes(Team.RED).Count >= m_GameManager.GetTeamList(Team.RED).Count)
        {
            m_BlueRoundsWon++;

            if (m_BlueRoundsWon >= RoundsToWin)
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
