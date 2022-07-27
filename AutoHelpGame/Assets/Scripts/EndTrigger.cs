using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    private Police _police;
    private bool _isEnded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.TryGetComponent<carEngine>(out var engine) && !_isEnded)
        {
            engine.SpeedLimitViolated -= _police.RegisterPenalty;
            _isEnded = true;
        }
    }
}
