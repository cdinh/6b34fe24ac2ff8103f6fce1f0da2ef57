using UnityEngine;
using System.Collections;

abstract public class GameMode : MonoBehaviour
{
    protected GameManager m_GameManager;

    public void Initialize(GameManager manager)
    {
        m_GameManager = manager;
    }
    abstract public VictoryStatus CheckVictoryConditions();
}
