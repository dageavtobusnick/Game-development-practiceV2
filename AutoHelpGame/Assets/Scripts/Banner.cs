using TMPro;
using UnityEngine;

public class Banner : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public void SetPenaltyText(int value)
    {
        _text.text=$"Вы должны {value}";
    }
}
