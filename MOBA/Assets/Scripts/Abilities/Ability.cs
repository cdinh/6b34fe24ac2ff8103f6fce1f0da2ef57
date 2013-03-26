using UnityEngine;

abstract public class Ability : MonoBehaviour
{
    public string Name;
    public string Description;

    // In seconds
    public float MaxCooldown;
    public float CurrentCooldown;
    public uint EnergyCost;

    public Hero Owner;

	// Use this for initialization
    void Start()
    {
        Owner = GetComponent<Hero>();
    }

    public void UpdateCooldowns()
    {
        if (CurrentCooldown > 0)
        {
            CurrentCooldown -= Time.deltaTime;

            if (CurrentCooldown < 0)
                CurrentCooldown = 0f;
        }
    }

    public bool Cast()
    {
        bool successful = OnCast();

        if (successful)
        {
            CurrentCooldown = MaxCooldown;
        }

        return successful;
    }

    // Perform actual ability
    abstract protected bool OnCast();
}
