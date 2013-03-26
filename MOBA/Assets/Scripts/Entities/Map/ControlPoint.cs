using UnityEngine;
using System.Collections;

public class ControlPoint : MonoBehaviour {
    public string Team;

    public float PointsToCapture;
    public float CaptureSpeed;
    public float CaptureRadius;

    public float DecaySpeed;
    public float TimeToDecay;

    private bool m_IsBeingCaptured;
    private float m_LastCaptureTime;

    private GameManager m_Manager;

	// Use this for initialization
	void Start () {
        m_Manager = GameObject.Find("Managers").GetComponent<GameManager>();

        m_IsBeingCaptured = false;
        m_LastCaptureTime = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        int nearbyBlue = HeroesInRange("Blue");
        int nearbyRed = HeroesInRange("Red");

        if (nearbyBlue == 0 && nearbyRed == 0)
        {
            m_IsBeingCaptured = false;
            m_LastCaptureTime += Time.deltaTime;
        }
        else
        {
            
        }
	}

    private int HeroesInRange(string team)
    {
        int count = 0;

        foreach (Hero h in m_Manager.GetTeamList("team"))
        {
            if (GameUtility.DistanceSquared(h.transform, transform) <= CaptureRadius)
            {
                count++;
            }
        }

        return count;
    }
}
