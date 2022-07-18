using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuelTank", menuName = "Configs/Upgrades/FuelTank")]
public class FuelTankUpgrade : BaseUpgrade
{
    [SerializeField]
    private float _maxFuelBoost = 0.1f;
    [SerializeField]
    private FuelTankUpgrade _next;
    [SerializeField]
    private FuelTankUpgrade _previous;
    public float MaxFuelBoost { get => _maxFuelBoost; }
    public FuelTankUpgrade Next { get => _next; }
    public FuelTankUpgrade Previous { get => _previous; }

    public float CountSummaryBoost()
    {
        float boost = 0;
        var update = Previous;
        while (update != null)
        {
            boost += update.MaxFuelBoost;
            update = update.Previous;
        }
        return boost;
    }
}
