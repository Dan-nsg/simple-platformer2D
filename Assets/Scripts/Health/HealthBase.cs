using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;

    public float delayToKill = 0f;
    private int _currentLife;
    private bool _isDead = false;

    private void Awake() 
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if(_isDead) return;
        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
