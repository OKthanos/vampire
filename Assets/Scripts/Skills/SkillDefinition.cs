// Scripts/Data/SkillDefinition.cs
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Skill Definition")]
public class SkillDefinition : ScriptableObject
{
    public string skillName = "Fireball";
    public GameObject projectilePrefab;
    public int poolSize = 20;

    [Header("Combat")]
    public float baseDamage = 3f;
    public float cooldown  = 1f;
    public float projectileSpeed = 10f;
}
