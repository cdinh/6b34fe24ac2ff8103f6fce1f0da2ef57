using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Pawn))]
public class Hero : MonoBehaviour
{
    private const int NUM_ABILITIES = 5;

    #region PLAYER STATS

    public string Name
    {
        get { return m_Name; }
    }
    private string m_Name;

    public HeroStatus Status
    {
        get { return m_Status; }
    }
    private HeroStatus m_Status;

    public uint MaxHealth
    {
        get { return m_MaxHealth; }
    }
    private uint m_MaxHealth;

    public uint CurrentHealth
    {
        get { return m_CurrentHealth; }
    }
    private uint m_CurrentHealth;

    public uint MaxEnergy
    {
        get { return m_MaxEnergy; }
    }
    private uint m_MaxEnergy;

    public uint CurrentEnergy
    {
        get { return m_CurrentEnergy; }
    }
    private uint m_CurrentEnergy;

    public uint Attack
    {
        get { return m_Attack; }
    }
    private uint m_Attack;

    public uint Defense
    {
        get { return m_Defense; }
    }
    private uint m_Defense;

    public uint MovementSpeed
    {
        get { return m_MovementSpeed; }
    }
    private uint m_MovementSpeed;

    #endregion

    private Ability[] m_Abilities;

    // Use this for initialization
	void Start () {
        m_Status = HeroStatus.ALIVE;
        m_Abilities = new Ability[NUM_ABILITIES];
	}

    public void Initialize(string name, uint maxHealth, uint maxEnergy, uint attack, uint defense, uint movementSpeed)
    {
        m_Name = name;

        m_MaxHealth = maxHealth;
        m_CurrentHealth = maxHealth;

        m_MaxEnergy = maxEnergy;
        m_CurrentEnergy = maxEnergy;

        m_Attack = attack;
        m_Defense = defense;
        m_MovementSpeed = movementSpeed;

        SendMessage("SetSpeed", movementSpeed);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void SetAbility(Ability ability, uint index)
    {
        if (index < m_Abilities.Length)
        {
            ability.Owner = this;
            m_Abilities[index] = ability;
        }
    }

    public bool CastAbility(uint index)
    {
        bool isValidAbility = index < m_Abilities.Length && m_Abilities[index] != null;
        if (isValidAbility && m_CurrentEnergy >= m_Abilities[index].EnergyCost && m_Abilities[index].CurrentCooldown == 0)
        {
            bool successfulCast = m_Abilities[index].Cast();
            if (successfulCast)
            {
                m_CurrentEnergy -= m_Abilities[index].EnergyCost;
            }

            return successfulCast;
        }
        else
            return false;
    }
}
