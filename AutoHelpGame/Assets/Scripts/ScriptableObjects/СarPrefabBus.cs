
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "СarPrefabBus", menuName = "Configs/СarPrefabBus")]
public class СarPrefabBus: ScriptableObject
{
    [System.Serializable]
    private class CarPrefabPair
    {
        public CarData CarData;
        public GameObject CarPrefab;
    }
    [SerializeField]
    private List<CarPrefabPair> _carPrefabPairs = new List<CarPrefabPair>();

    public GameObject FingPrefab(CarData data)
    {
        return _carPrefabPairs.Where(x => x.CarData == data || x.CarData.Id == data.Id).First().CarPrefab;
    }
}