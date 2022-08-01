using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log(collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();
        
        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }
    
    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
}
