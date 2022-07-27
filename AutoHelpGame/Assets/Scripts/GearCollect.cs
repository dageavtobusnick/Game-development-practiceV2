using UnityEngine;

public class GearCollect : MonoBehaviour
{
    [SerializeField]
    private int _repairValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj=collision.gameObject;
        if (obj.TryGetComponent<HPScript>(out var hP))
        {
            hP.Heal(_repairValue);
            Destroy(gameObject);
        }
    }
}
