using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
   public void Init(int maxValue)
    {
        _slider.maxValue=maxValue;
    }
    public void UpdateInfo(int hp)
    {
        _slider.value=hp;
    }
}
