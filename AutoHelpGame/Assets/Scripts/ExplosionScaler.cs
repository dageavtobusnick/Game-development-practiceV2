using UnityEngine;

public class ExplosionScaler : MonoBehaviour
{
    [SerializeField]
    private float _startRadius;
    [SerializeField]
    private float _endRadius;
    [SerializeField]
    private float _scaleSpeed;
    private CircleCollider2D _circleCollider;

    void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _circleCollider.radius = _startRadius;
    }

    void Update()
    {
        if(_circleCollider.radius > _endRadius)
        {
            Destroy(gameObject);
        }
        else
        {
            _circleCollider.radius += _scaleSpeed*Time.deltaTime;
        }
    }
}
