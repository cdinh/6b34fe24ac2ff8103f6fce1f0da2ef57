// Controller for keyboard/mouse

using UnityEngine;
using System.Collections;

public class KBMHeroController : MonoBehaviour 
{
    private Pawn m_Pawn;
    private Hero m_Hero;

    private Vector3 m_Direction;

    private KeyCode m_ForwardKey;
    private KeyCode m_BackwardKey;
    private KeyCode m_LeftKey;
    private KeyCode m_RightKey;
    private KeyCode m_CastAbility1;
    private KeyCode m_CastAbility2;
    private KeyCode m_CastAbility3;
    private KeyCode m_CastAbility4;
    private KeyCode m_CastAbility5;

	// Use this for initialization
	void Start () 
    {
        m_Direction = Vector3.zero;

        m_ForwardKey = (KeyCode)PlayerPrefs.GetInt("Key_Forward", (int)KeyCode.W);
        m_BackwardKey = (KeyCode)PlayerPrefs.GetInt("Key_Backward", (int)KeyCode.S);
        m_LeftKey = (KeyCode)PlayerPrefs.GetInt("Key_Left", (int)KeyCode.A);
        m_RightKey = (KeyCode)PlayerPrefs.GetInt("Key_Right", (int)KeyCode.D);

        m_CastAbility1 = (KeyCode)PlayerPrefs.GetInt("Key_ABILITY1", (int)KeyCode.Alpha1);
        m_CastAbility2 = (KeyCode)PlayerPrefs.GetInt("Key_ABILITY2", (int)KeyCode.Alpha2);
        m_CastAbility3 = (KeyCode)PlayerPrefs.GetInt("Key_ABILITY3", (int)KeyCode.Alpha3);
        m_CastAbility4 = (KeyCode)PlayerPrefs.GetInt("Key_ABILITY4", (int)KeyCode.Alpha4);
        m_CastAbility5 = (KeyCode)PlayerPrefs.GetInt("Key_ABILITY5", (int)KeyCode.Alpha5);

        m_Pawn = GetComponent<Pawn>();
        m_Hero = GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (m_Hero.Status == HeroStatus.STUNNED || m_Hero.Status == HeroStatus.DEAD)
        {
            return;
        }

        if (Input.GetKeyDown(m_CastAbility1))
            m_Hero.CastAbility(0);
        else if (Input.GetKeyDown(m_CastAbility2))
            m_Hero.CastAbility(1);
        else if (Input.GetKeyDown(m_CastAbility3))
            m_Hero.CastAbility(2);
        else if (Input.GetKeyDown(m_CastAbility4))
            m_Hero.CastAbility(3);
        else if (Input.GetKeyDown(m_CastAbility5))
            m_Hero.CastAbility(4);
	}

    void FixedUpdate ()
    {
        if (m_Hero.Status == HeroStatus.STUNNED || m_Hero.Status == HeroStatus.DEAD)
        {
            return;
        }

        m_Direction = Vector3.zero;

        if (Input.GetKey(m_ForwardKey))
            m_Direction.z++;
        if (Input.GetKey(m_BackwardKey))
            m_Direction.z--;
        if (Input.GetKey(m_LeftKey))
            m_Direction.x--;
        if (Input.GetKey(m_RightKey))
            m_Direction.x++;

        m_Pawn.Move(m_Direction);
    }
}
