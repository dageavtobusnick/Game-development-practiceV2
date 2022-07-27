using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    [SerializeField]
    private Police _police;
    private bool _isStarted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj=collision.gameObject;
        if(obj.TryGetComponent<carEngine>(out var engine)&&!_isStarted)
        {
            engine.SpeedLimitViolated += _police.RegisterPenalty;
            engine.SpeedLimit = _police.SpeedLimit;
            _isStarted = true;
        }
    }
}
