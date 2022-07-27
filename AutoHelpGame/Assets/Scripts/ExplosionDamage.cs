using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _explosionForce;

    private readonly HashSet<HPScript> _scripts=new HashSet<HPScript>();


    private void OnTriggerEnter2D(Collider2D collision) { 
        var obj=collision.gameObject;
        if(obj.TryGetComponent<HPScript>(out var hP) && !_scripts.Contains(hP))
        {
            hP.Damege(_damage);
            _scripts.Add(hP);
            if(obj.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.AddForce((collision.transform.position- transform.position).normalized*_explosionForce);
            }
        }
    }
}
