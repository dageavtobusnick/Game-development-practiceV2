using UnityEngine;

[CreateAssetMenu(fileName = "Wheels", menuName = "Configs/Upgrades/Wheels")]
public class WheelsUpgrade : BaseUpgrade
{
    [SerializeField]
    private float _adhesionBoost=0.2f;
    [SerializeField]
    private WheelsUpgrade _next;
    [SerializeField]
    private WheelsUpgrade _previous;

    public float AdhesionBoost { get => _adhesionBoost; }
    public WheelsUpgrade Next { get => _next; }
    public WheelsUpgrade Previous { get => _previous; }
    public override bool IsUpgradeable => _next != null;
    public override int NextCost => (int)_next?.Cost;
    public float CountSummaryBoost()
    {
        float boost = 0;
        var update = Previous;
        while (update != null)
        {
            boost += update.AdhesionBoost;
            update = update.Previous;
        }
        return boost;
    }
}
