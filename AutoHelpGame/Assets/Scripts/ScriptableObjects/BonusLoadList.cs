using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BonusLoadList", menuName = "Configs/BonusLoadList")]
public class BonusLoadList :ScriptableObject
{
    [SerializeField]
    private List<Bonus> _bonuses;

    public Bonus CopyBonusData(int bonusId)
    {
        return Instantiate(_bonuses.Where(bonus => bonus.Id == bonusId).First());
    }
}
