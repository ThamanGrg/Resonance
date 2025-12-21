using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyStats : MonoBehaviour
{
    public EntityData enemyStat;
    int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currentHealth = enemyStat.maxHealth;
    }

    public void takeDamage(int amount)
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
