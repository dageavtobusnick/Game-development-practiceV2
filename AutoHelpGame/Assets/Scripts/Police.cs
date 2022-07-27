using UnityEngine;
using UnityEngine.UI;

public class Police : MonoBehaviour
{
    [SerializeField]
    private int _penaltyValue;
    [SerializeField]
    private int _speedLimit;
    [SerializeField]
    private GameObject _bannerObj;
    [SerializeField]
    private Button _payButton;

    private bool _isRegistered;
    private Banner _banner;

    public int PenaltyValue { get => _penaltyValue; }
    public int SpeedLimit { get => _speedLimit; }

    public void RegisterPenalty()
    {
        if (!_isRegistered)
        {
            _bannerObj.SetActive(true);
            Time.timeScale = 0;
            _banner.SetPenaltyText(_penaltyValue);
            UnityEngine.Events.UnityAction action = () =>
             {
                 if (PlayerDataHub.instance.PlayerData.CoinsCount >= _penaltyValue)
                 {
                     PlayerDataHub.instance.PlayerData.PayPenalty(_penaltyValue);
                     Time.timeScale = 1;
                     _payButton.onClick.RemoveAllListeners();
                     _bannerObj.SetActive(false);
                     
                 }
             };            
            _payButton.onClick.AddListener(action);
            _isRegistered = true;
        }
    }
    public void StopPause()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        _banner=_bannerObj.GetComponent<Banner>();
    }
}
