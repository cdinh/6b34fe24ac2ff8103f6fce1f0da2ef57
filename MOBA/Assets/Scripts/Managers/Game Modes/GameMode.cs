using UnityEngine;
using System.Collections;

abstract public class GameMode : MonoBehaviour
{
    protected GameManager m_GameManager;

    public void Create(GameManager manager)
    {
        m_GameManager = manager;
        Initialize();
    }

    abstract public void Initialize();
    abstract public VictoryStatus CheckVictoryConditions();
}
