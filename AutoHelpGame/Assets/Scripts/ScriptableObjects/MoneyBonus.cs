using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyBonus", menuName = "Configs/Bonuses/MoneyBonus")]
public class MoneyBonus : Bonus
{
    [SerializeField]
    private int _bonusValue;
    public override string Desc => $"Купон предоставляет скидку в {_bonusValue}р";

    public override string ShortDesc => $"Купон {_bonusValue}р";

    
}
