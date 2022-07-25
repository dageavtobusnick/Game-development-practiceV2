using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCollect : MonoBehaviour
{
    [SerializeField]
    AudioClip myClip;

    [SerializeField]
    float capacity = 0 ;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            Debug.Log("add fuel");
            col.GetComponent<carEngine>().RefilTank((int)Mathf.Round( capacity));
            if(myClip)
            {
                GameObject.FindGameObjectWithTag("ExtraAudio").GetComponent<AudioSource>().PlayOneShot(myClip);
            }
            Destroy(gameObject,0.3f);         
        }
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
