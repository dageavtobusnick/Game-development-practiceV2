using System;
using System.Collections;
using System.Collections.Generic;
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
            PlayerPrefs.SetInt("levelCoins",PlayerPrefs.GetInt("levelCoins")+1);
            //CoinCollected.Invoke(1);
            GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<CoinCounter>().GetValueCoins();
           if(myClip)
            {
                GameObject.FindGameObjectWithTag("ExtraAudio").GetComponent<AudioSource>().PlayOneShot(myClip);
            }
           // CoinCollected -= PlayerDataHub.instance.PlayerData.AddCoins;
            Destroy(gameObject,0.3f);         
        }
     
    }
    // Start is called before the first frame update
    void Start()
    {
       // CoinCollected+=PlayerDataHub.instance.PlayerData.AddCoins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
