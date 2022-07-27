using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageScript : MonoBehaviour
{
    [SerializeField]
    private int _baseDamagePerV;
    [SerializeField]
    private int _damageKD;
    private float _timer;
    private Rigidbody2D _rB;
    private bool _canDamage;

    private void Start()
    {
        _rB = GetComponent<Rigidbody2D>();  
        _timer = _damageKD;
        _canDamage = true;
    }
    private void Update()
    {
        if (_timer <= 0)
        {
            _canDamage = true;
            _timer = _damageKD;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var obj=collision.gameObject;
        if(_canDamage && obj.TryGetComponent<HPScript>(out var hP))
        {
            var velocity = (_rB.velocity - (obj.TryGetComponent<Rigidbody2D>(out var objectRB) ? objectRB.velocity : Vector2.zero)).magnitude;
            hP.Damege((int)MathF.Round(_baseDamagePerV * velocity));
            _canDamage = false;
        }
    }
}
