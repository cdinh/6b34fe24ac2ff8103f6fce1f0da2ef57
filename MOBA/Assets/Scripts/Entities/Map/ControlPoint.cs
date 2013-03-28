using UnityEngine;
using System.Collections;

public class ControlPoint : MonoBehaviour {
    public Team Team;

    public float PointsToCapture;
    public float CaptureSpeed;
    public float CaptureRadius;

    public float DecaySpeed;
    public float TimeToDecay;

    private AudioSource m_DuringCapture;
    private AudioSource m_OnCapture;

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

        AudioSource[] sources = GetComponents<AudioSource>();
        m_DuringCapture = sources[0];
        m_OnCapture = sources[1];
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
        int nearbyBlue = HeroesInRange(Team.BLUE);
        int nearbyRed = HeroesInRange(Team.RED);

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
                    Team = Team.NEUTRAL;
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

                if (Team != Team.BLUE)
                {
                    if (!m_DuringCapture.isPlaying)
                        m_DuringCapture.Play();

                    if (m_CapturePoints == -PointsToCapture)
                    {
                        Team = Team.BLUE;
                        m_OnCapture.Play();
                    }
                }
            }
            else if (nearbyRed > nearbyBlue)
            {
                m_CapturePoints += (nearbyRed - nearbyBlue) * CaptureSpeed;

                if (m_CapturePoints > PointsToCapture)
                    m_CapturePoints = PointsToCapture;

                if (Team != Team.RED)
                {
                    if (!m_DuringCapture.isPlaying)
                        m_DuringCapture.Play();

                    if (m_CapturePoints == -PointsToCapture)
                    {
                        Team = Team.RED;
                        m_OnCapture.Play();
                    }
                }
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

    private int HeroesInRange(Team team)
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
