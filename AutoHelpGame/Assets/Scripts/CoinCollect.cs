using System;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField]
    AudioClip myClip;
    public event Action<int> CoinCollected;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Debug.Log("add coin");
            CoinCollected.Invoke(1);
            if (myClip)
            {
                GameObject.FindGameObjectWithTag("ExtraAudio").GetComponent<AudioSource>().PlayOneShot(myClip);
            }
            CoinCollected -= PlayerDataHub.instance.PlayerData.AddCoins;
            Destroy(gameObject,0.25f);         
        }
     
    }

    void Start()
    {
        CoinCollected+=PlayerDataHub.instance.PlayerData.AddCoins;
        var counter = FindObjectOfType<CoinCounter>();
        CoinCollected += counter.CollectLocalCoins;
    }
}
