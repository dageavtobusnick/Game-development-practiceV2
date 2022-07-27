using UnityEngine;
using TMPro;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            GameObject.FindWithTag("EndLevelMenu").transform.GetChild(0).gameObject.SetActive(true);
            var counter = FindObjectOfType<CoinCounter>();
            GameObject.FindGameObjectWithTag("EndLevelCoins").GetComponent<TextMeshProUGUI>().text = counter.LocalCoins.ToString();
            GameObject.FindGameObjectWithTag("EndLevelCoins").transform.localPosition = new Vector2(320f, 93.2f);
        }
    }
}
