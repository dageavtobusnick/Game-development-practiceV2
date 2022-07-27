using UnityEngine;
[RequireComponent(typeof(HPScript))]
public class StartExplosionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionEffect;
    private HPScript _hP;

    void Start()
    {
        _hP = GetComponent<HPScript>();
        _hP.Died += Explode;
    }

   private void Explode()
    {
        Instantiate(explosionEffect,transform.position,Quaternion.identity);
        _hP.Died -= Explode;
    }
}
