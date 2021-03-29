using UnityEngine;

public class DamagebleObject : MonoBehaviour
{
    [SerializeField] 
    private float HP;

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Die();
        }
        print("hit");
    }

    private void Die()
    {
        Destroy(gameObject);
        
    }

}
