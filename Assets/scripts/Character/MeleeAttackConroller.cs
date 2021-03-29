using UnityEngine;

public class MeleeAttackConroller : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask DamageableLayerMask;
    public float Damage;
    public float AttackRange;
    public float TimeBtwAttack;

    private float _timer;
    private Animator animator;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    private void Attack()
    {
        if(_timer <= 0)
        {
            animator.SetBool("isAttack", false);
            if (Input.GetButtonDown("Fire1"))
            {
                
                Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, DamageableLayerMask);
                if(enemies.Length != 0)
                {
                    for(int i = 0; i <enemies.Length;i++)
                    {
                        enemies[i].GetComponent<DamagebleObject>().TakeDamage(Damage);
                    }
                }
                _timer = TimeBtwAttack;
            }
        }
        else
        {
            animator.SetBool("isAttack", true);
            _timer -= Time.deltaTime;
        }
    }

    private void GetReferences()
    {
        animator = GetComponent<Animator>();
    }
}
