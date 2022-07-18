using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CarsLoadList", menuName = "Configs/CarsLoadList")]
public class CarLoadList:ScriptableObject
{
    [SerializeField]
    private List<CarData> _cars;

    public void Reload()
    {
        _cars = _cars.Select(car => Instantiate(car)).ToList();
    }
    
    public CarData CopyCarData(int carId)
    {
        return Instantiate( _cars.Where(car => car.Id == carId).First());
    }
}
