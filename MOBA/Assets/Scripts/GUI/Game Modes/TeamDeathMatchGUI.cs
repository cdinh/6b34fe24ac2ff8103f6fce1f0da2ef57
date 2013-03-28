using UnityEngine;
using System.Collections;

public class TeamDeathMatchGUI : MonoBehaviour {
    private TeamDeathMatch m_TDM;

	// Use this for initialization
	void Start () {
        m_TDM = GetComponent<TeamDeathMatch>();
	}

    void OnGUI()
    {
        GUI.Label(GuiUtility.PercRect(0.5f, 0.05f), "To Win:");
        GUI.Label(GuiUtility.PercRect(0.5f, 0.075f), "" + m_TDM.RoundsToWin);

        GUI.Label(GuiUtility.PercRect(0.4f, 0.05f), "Blue");
        GUI.Label(GuiUtility.PercRect(0.4f, 0.075f), "" + m_TDM.BlueRoundsWon);

        GUI.Label(GuiUtility.PercRect(0.6f, 0.05f), "Red");
        GUI.Label(GuiUtility.PercRect(0.6f, 0.075f), "" + m_TDM.RedRoundsWon);
    }
}
