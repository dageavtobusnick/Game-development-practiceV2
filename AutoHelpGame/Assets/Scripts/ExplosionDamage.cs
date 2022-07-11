using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    private readonly HashSet<HPScript> _scripts=new HashSet<HPScript>();

    private void OnCollisionStay2D(Collision2D collision)
    {
        var obj=collision.gameObject;
        if(obj.TryGetComponent<HPScript>(out var hP) && !_scripts.Contains(hP))
        {
            hP.Damege(_damage);
            _scripts.Add(hP);
        }
    }
}
