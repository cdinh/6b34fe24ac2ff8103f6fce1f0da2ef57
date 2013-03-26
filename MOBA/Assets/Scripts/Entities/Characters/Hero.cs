using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Pawn))]
public class Hero : MonoBehaviour
{
    private const int NUM_ABILITIES = 5;

    #region PLAYER STATS

    public string Name;
    public string Team;
    public HeroStatus Status;
    public float MaxHealth;
    public float CurrentHealth;
    public float MaxEnergy;
    public float CurrentEnergy;
    public int Attack;
    public uint Defense;
    public float MovementSpeed;

    #endregion

    private Ability[] m_Abilities;

    // Use this for initialization
	void Start () {
        Status = HeroStatus.ALIVE;
        m_Abilities = new Ability[NUM_ABILITIES];

        for (int i = 0; i < m_Abilities.Length; i++)
        {
            m_Abilities[i] = transform.FindChild("Ability" + (i + 1)).GetComponent<Ability>();
            m_Abilities[i].Owner = this;
        }
        GetComponent<Pawn>().SetSpeed(1f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //foreach (Ability a in m_Abilities)
        //{
        //    
        //    a.UpdateCooldowns();
        //}
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
        if (CurrentEnergy >= m_Abilities[index].EnergyCost && m_Abilities[index].CurrentCooldown == 0)
        {
            bool successfulCast = m_Abilities[index].Cast();
            if (successfulCast)
            {
                CurrentEnergy -= m_Abilities[index].EnergyCost;
            }

            return successfulCast;
        }
        else
            return false;
    }

    public void AddHealth(float amount)
    {
        if (amount < 0)
            return;

        CurrentHealth = System.Math.Min(CurrentHealth + amount, MaxHealth);
    }

    public void AddEnergy(float amount)
    {
        if (amount < 0)
            return;

        CurrentEnergy = System.Math.Min(CurrentEnergy + amount, MaxEnergy);
    }
}
