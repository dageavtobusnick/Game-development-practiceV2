using UnityEngine;
using UnityEngine.UI;

public class fuel : Car
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FuelBar = GameObject.FindWithTag("FuelBar").GetComponent<Slider>();
            FuelBar.value += FuelConsume;
            Destroy(gameObject);

        }
    }
}
