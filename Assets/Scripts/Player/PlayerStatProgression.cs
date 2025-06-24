// Scripts/Data/PlayerStatProgression.cs
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerStatProgression", menuName = "Player Stat Progression")]
public class PlayerStatProgression : ScriptableObject
{
    [Header("Move Speed (per level)")]
    public List<float> moveSpeedByLevel;

    [Header("Attack Damage (per level)")]
    public List<float> attackByLevel;

    [Header("HP (per level)")]
    public List<float> hpByLevel;

    [Header("Skill Pattern Unlock Level")]
    public int skillLevel1Unlock = 1;
    public int skillLevel2Unlock = 2;

    [Header("Cooldown Decrease Level")]
    public int cooltimeLevelMax = 5;

    public float GetMoveSpeed(int level)
    {
        return moveSpeedByLevel[Mathf.Clamp(level, 0, moveSpeedByLevel.Count - 1)];
    }

    public float GetAttack(int level)
    {
        return attackByLevel[Mathf.Clamp(level, 0, attackByLevel.Count - 1)];
    }

    public float GetHP(int level)
    {
        return hpByLevel[Mathf.Clamp(level, 0, hpByLevel.Count - 1)];
    }
}
