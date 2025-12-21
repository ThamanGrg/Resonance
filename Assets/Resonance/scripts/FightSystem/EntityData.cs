using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
public class EntityData : ScriptableObject
{
    public string entityName;
    public int maxHealth;
    public int baseAttack;
    public int ultAttack;

    public int skillAttack;
}
