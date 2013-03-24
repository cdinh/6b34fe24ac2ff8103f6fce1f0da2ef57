using UnityEngine;

abstract public class Ability 
{
    public string Name 
    { 
        get { return m_Name; }
    }
    protected string m_Name;

    public string Description
    {
        get { return m_Description; }
    }
    protected string m_Description;

    // In seconds
    public float MaxCooldown
    {
        get { return m_MaxCooldown; }
    }
    protected float m_MaxCooldown;

    public float CurrentCooldown
    {
        get { return m_CurrentCooldown; }
    }
    protected float m_CurrentCooldown;

    public uint EnergyCost
    {
        get { return m_EnergyCost; }
    }
    protected uint m_EnergyCost;

    public Hero Owner
    {
        set { m_Owner = value; }
    }
    protected Hero m_Owner;

	// Use this for initialization
	public Ability(string name, string description, float maxCooldown, float currentCooldown, uint energyCost) 
    {
        m_Name = name;
        m_Description = description;
        m_MaxCooldown = maxCooldown;
        m_CurrentCooldown = currentCooldown;
        m_EnergyCost = energyCost;
	}
	
	// Update is called once per frame
	public void Update() 
    {
        if (m_CurrentCooldown > 0)
        {
            m_CurrentCooldown -= Time.deltaTime;

            if (m_CurrentCooldown < 0)
                m_CurrentCooldown = 0f;
        }
	}

    public bool Cast()
    {
        bool successful = OnCast();

        if (successful)
        {
            m_CurrentCooldown = m_MaxCooldown;
        }

        return successful;
    }

    // Perform actual ability
    abstract protected bool OnCast();
}
