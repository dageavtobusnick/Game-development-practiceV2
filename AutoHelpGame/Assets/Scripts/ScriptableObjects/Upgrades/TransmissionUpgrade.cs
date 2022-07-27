using UnityEngine;

[CreateAssetMenu(fileName = "Transmission", menuName = "Configs/Upgrades/Transmission")]
public class TransmissionUpgrade : BaseUpgrade
{
    [SerializeField]
    private float _speedBoost = 0.1f;
    [SerializeField]
    private TransmissionUpgrade _next;
    [SerializeField]
    private TransmissionUpgrade _previous;
    public float SpeedBoost { get => _speedBoost;}
    public TransmissionUpgrade Next { get => _next; }
    public TransmissionUpgrade Previous { get => _previous; }
    public override bool IsUpgradeable => _next != null;
    public override int NextCost => (int)_next?.Cost;

    public float CountSummaryBoost()
    {
        float boost = 0;
        var update = Previous;
        while(update != null)
        {
            boost+=update.SpeedBoost;
            update = update.Previous;
        }
        return boost;
    }
}
