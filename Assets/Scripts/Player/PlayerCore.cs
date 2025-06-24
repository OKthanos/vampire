// Scripts/Core/Player/PlayerCore.cs
using UnityEngine;

public class PlayerCore
{
    public float Health { get; private set; }
    public float MaxHealth { get; private set; }
    public Vector2 MoveDirection { get; set; }

    public PlayerStats Stats { get; private set; }

    public bool IsDead => Health <= 0;

    public PlayerCore(PlayerStats stats, float maxHealth)
    {
        Stats = stats;
        MaxHealth = maxHealth;
        Health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        Health = Mathf.Max(0, Health - amount);
    }

    public void Heal(float amount)
    {
        Health = Mathf.Min(MaxHealth, Health + amount);
    }

    public float GetSpeed()
    {
        return Stats.GetMoveSpeed();
    }

    public float GetDamage()
    {
        return Stats.GetDamage();
    }
}
