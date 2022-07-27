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
    public override bool IsUpgradeable => _next != null;
    public override int NextCost => (int)_next?.Cost;

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
