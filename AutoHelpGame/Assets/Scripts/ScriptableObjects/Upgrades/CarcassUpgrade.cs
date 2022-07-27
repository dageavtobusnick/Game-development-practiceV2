using UnityEngine;

[CreateAssetMenu(fileName = "Carcass", menuName = "Configs/Upgrades/Carcass")]
public class CarcassUpgrade : BaseUpgrade
{
    [SerializeField]
    private float _hPBoost = 0.2f;
    [SerializeField]
    private CarcassUpgrade _next;
    [SerializeField]
    private CarcassUpgrade _previous;

    public float HPBoost { get => _hPBoost; }
    public CarcassUpgrade Next { get => _next; }
    public CarcassUpgrade Previous { get => _previous; }

    public override bool IsUpgradeable => _next!=null;

    public override int NextCost =>(int) _next?.Cost;

    public float CountSummaryBoost()
    {
        float boost = 0;
        var update = Previous;
        while (update != null)
        {
            boost += update.HPBoost;
            update = update.Previous;
        }
        return boost;
    }
}
