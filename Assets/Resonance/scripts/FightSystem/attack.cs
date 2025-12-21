using UnityEngine;
using UnityEngine.InputSystem;

public class attack : MonoBehaviour
{
    public EntityData attackData;

    float timeBtnAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;
    public float size;


    int amount;
    int baseAttack;
    int ultAttack;

    void Awake()
    {
        initialize();
    }

    void initialize()
    {
        baseAttack = attackData.baseAttack;
        ultAttack = attackData.ultAttack;
    }

    void Update()
    {
        if(timeBtnAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                Attack(baseAttack);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack(ultAttack);
            }
            
        } else
        {
            timeBtnAttack -= Time.deltaTime;
        }
    }

    void Attack(int amount)
    {
        Collider2D enemyInRange = Physics2D.OverlapCircle(attackPos.position, attackRange, enemy);
        if (enemyInRange != null)
        {
            print ("EnemyInRange");
            enemyInRange.GetComponent<enemyStats>().takeDamage(amount);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
