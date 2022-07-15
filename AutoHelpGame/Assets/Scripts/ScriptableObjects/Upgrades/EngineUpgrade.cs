using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Engine", menuName = "Configs/Upgrades/Engine")]
public class EngineUpgrade : BaseUpgrade
{
    [SerializeField]
    private float _consumeBoost = 0.1f;
    [SerializeField]
    private float _accelBoost = 0.1f;
    [SerializeField]
    private EngineUpgrade _next;
    [SerializeField]
    private EngineUpgrade _previous;

    public float ConsumeBoost { get => _consumeBoost; }
    public float AccelBoost { get => _accelBoost; }
    public EngineUpgrade Next { get => _next; }
    public EngineUpgrade Previous { get => _previous; }
    public float CountSummaryConsumeBoost()
    {
        float boost = 0;
        var update = Previous;
        while (update != null)
        {
            boost += update.ConsumeBoost;
            update = update.Previous;
        }
        return boost;
    }
    public float CountSummaryAccelBoost()
    {
        float boost = 0;
        var update = Previous;
        while (update != null)
        {
            boost += update.AccelBoost;
            update = update.Previous;
        }
        return boost;
    }
}
