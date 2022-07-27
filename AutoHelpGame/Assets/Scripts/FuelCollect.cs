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
}
