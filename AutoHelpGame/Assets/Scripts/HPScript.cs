using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public event Action<int> HPUpdated;
    public event Action Died;
    [SerializeField]
    private int _maxHP;
    private int _hP;
    private CarData _carData;
    public int HP { get => _hP; private set=>_hP=value; }
    public int MaxHP { get =>(_carData!=null)?(int)Mathf.Round(_carData.CarMaxHP):_maxHP; }

    void Start()
    {
        var car = GetComponent<Car>();
        if (car != null)
        {
            _carData = car.CarData;
            HPUpdated += _carData.UpdateHP;
        }
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
        if (_carData!= null)
        {
            HPUpdated -= _carData.UpdateHP;
        }
        Died?.Invoke();
        Destroy(gameObject);
    }
}
