using UnityEngine;
using System.Collections;

public class ControlPoint : MonoBehaviour {
    public string Team;

    public float PointsToCapture;
    public float CaptureSpeed;
    public float CaptureRadius;

    public float DecaySpeed;
    public float TimeToDecay;

    // -100: Blue Control
    // 0: Neutral
    // 100: Red Control
    private float m_CapturePoints;

    private float m_LastCaptureTime;

    private GameManager m_Manager;

	// Use this for initialization
	void Start () {
        m_Manager = GameObject.Find("Managers").GetComponent<GameManager>();

        m_CapturePoints = 0f;
        m_LastCaptureTime = 0f;
	}

    void OnDestroy()
    {
        DestroyImmediate(renderer.material);
    }
	
	// Update is called once per frame
    void Update()
    {
        CalculateCaptureRate();
        ChangeColor();
	}

    private void CalculateCaptureRate()
    {
        int nearbyBlue = HeroesInRange("Blue");
        int nearbyRed = HeroesInRange("Red");

        if (nearbyBlue == 0 && nearbyRed == 0)
        {
            m_LastCaptureTime += Time.deltaTime;

            if (m_LastCaptureTime >= TimeToDecay)
            {
                if (m_CapturePoints > 0)
                {
                    m_CapturePoints = Mathf.Max(0, m_CapturePoints - DecaySpeed);
                }
                else if (m_CapturePoints < 0)
                {
                    m_CapturePoints = Mathf.Min(0, m_CapturePoints + DecaySpeed);
                }

                if (m_CapturePoints == 0)
                {
                    Team = "Neutral";
                }
            }
        }
        else
        {
            m_LastCaptureTime = 0f;

            if (nearbyBlue > nearbyRed)
            {
                m_CapturePoints -= (nearbyBlue - nearbyRed) * CaptureSpeed;

                if (m_CapturePoints < -PointsToCapture)
                    m_CapturePoints = -PointsToCapture;

                if (m_CapturePoints == -PointsToCapture)
                    Team = "Blue";
            }
            else if (nearbyRed > nearbyBlue)
            {
                m_CapturePoints += (nearbyRed - nearbyBlue) * CaptureSpeed;

                if (m_CapturePoints > PointsToCapture)
                    m_CapturePoints = PointsToCapture;

                if (m_CapturePoints == PointsToCapture)
                    Team = "Red";
            }
        }
    }

    private void ChangeColor()
    {
        Color newColor = Color.white;
        if (m_CapturePoints < 0)
        {
            newColor = Color.Lerp(newColor, Color.blue, -m_CapturePoints / PointsToCapture);
        }
        else if (m_CapturePoints > 0)
        {
            newColor = Color.Lerp(newColor, Color.red, m_CapturePoints / PointsToCapture);
        }

        renderer.material.color = newColor;
    }

    private int HeroesInRange(string team)
    {
        int count = 0;

        foreach (Hero h in m_Manager.GetTeamList(team))
        {
            if (GameUtility.DistanceSquared(h.transform, transform) <= CaptureRadius * CaptureRadius)
            {
                count++;
            }
        }

        return count;
    }
}
