// Scripts/Core/Player/PlayerStats.cs
using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public PlayerStatProgression statData;

    public int attackLevel = 0;
    public int moveSpeedLevel = 0;
    public int HPLevel = 0;
    public int skillLevel = 0;
    public int cooltimeLevel = 0;

    public float GetMoveSpeed()
    {
        return statData.GetMoveSpeed(moveSpeedLevel);
    }

    public float GetDamage()
    {
        return statData.GetAttack(attackLevel);
    }

    public float GetHP()
    {
        return statData.GetHP(HPLevel);
    }

    public List<Vector2> GetSkill(int level)
    {
        List<Vector2> directions = new();

        directions.Add(Vector2.left);
        directions.Add(Vector2.right);

        if (level >= statData.skillLevel1Unlock)
        {
            directions.Add(Vector2.up);
            directions.Add(Vector2.down);
        }

        if (level >= statData.skillLevel2Unlock)
        {
            directions.Add(new Vector2(1, 1).normalized);
            directions.Add(new Vector2(1, -1).normalized);
            directions.Add(new Vector2(-1, 1).normalized);
            directions.Add(new Vector2(-1, -1).normalized);
        }

        return directions;
    }

    public void Upgrade(string selected)
    {
        switch (selected)
        {
            case "Attack Upgrade":
                attackLevel++;
                break;
            case "Move Speed Upgrade":
                moveSpeedLevel++;
                break;
            case "HP Upgrade":
                HPLevel++;
                break;
            case "Skill Upgrade":
                skillLevel++;
                break;
            case "Cooltime Decrease":
                cooltimeLevel++;
                break;
        }
    }
}
