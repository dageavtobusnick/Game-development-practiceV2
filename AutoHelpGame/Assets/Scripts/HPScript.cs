using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public event Action<int> HPUpdated;
    public event Action Died;
    [SerializeField]
    private int MaxHP;
    private int HP;
    
    void Start()
    {
        HP = MaxHP;
    }

    public void Heal(int HPCount)
    {
        var newHP = HP + HPCount;
        HP = (newHP>MaxHP)?MaxHP:newHP;
        HPUpdated?.Invoke(HP);
    }

    public void Damege(int HPCount)
    {
        var newHP = HP - HPCount;
        if (newHP < 0)
            Die();
        else HP = newHP;
        HPUpdated?.Invoke(HP);
    }

    public void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
