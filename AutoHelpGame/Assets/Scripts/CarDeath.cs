using TMPro;
using UnityEngine;

public class CarDeath : MonoBehaviour
{
    public int test = 0;
    [SerializeField]
    private HPScript _carHP;
    void OnTriggerEnter2D(Collider2D col)
    {

        if (LayerMask.LayerToName(col.gameObject.layer) == "Ground")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            CarDeathHandler();
        }

    }

    private void CarDeathHandler()
    {
        Debug.Log("death");
        GameObject.FindWithTag("DeathMenu").transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 2f;
        var counter = FindObjectOfType<CoinCounter>();
        GameObject.FindGameObjectWithTag("EndLevelCoins").GetComponent<TextMeshProUGUI>().text = counter.LocalCoins.ToString();
        GameObject.FindGameObjectWithTag("EndLevelCoins").transform.localPosition = new Vector2(320f, 93.2f);
    }

    void Start()
    {
        _carHP.Died += CarDeathHandler;
    }

}
