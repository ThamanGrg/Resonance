using System.Linq.Expressions;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class characterStats : MonoBehaviour
{
    public EntityData entityData;

    public int currentHealth {get; private set;}

    // Update is called once per frame
    void Awake()
    {
        currentHealth = entityData.maxHealth;
    }

    void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
