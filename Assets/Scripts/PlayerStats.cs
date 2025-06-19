using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    int attackLevel = 0;
    int moveSpeedLevel = 0;
    int HPLevel = 0;
    public int skillLevel = 0;
    int cooltimeLevel = 0;

    public float GetMoveSpeed()
    {
        return 5f + moveSpeedLevel * 5f;
    }

    public float GetDamage()
    {
        return attackLevel + 1f; 
    }

    public List<Vector2> GetSkill(int level)
    {
        List<Vector2> directions = new();

        // 항상 좌우는 포함
        directions.Add(Vector2.left);
        directions.Add(Vector2.right);

        if (level >= 1)
        {
            directions.Add(Vector2.up);
            directions.Add(Vector2.down);
        }

        if (level >= 2)
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