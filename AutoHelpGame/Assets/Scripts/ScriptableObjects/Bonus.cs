using System;
using UnityEngine;


public abstract class Bonus : ScriptableObject
{
    [Serializable]
    public readonly struct BonusSaveData
    {
        public readonly int Id;
        public readonly int UniqueId;

        public BonusSaveData(int id, int uniqueId)
        {
            Id = id;
            UniqueId = uniqueId;
        }
    }
    [SerializeField]
    private int _id;
    [SerializeField]
    private int _uniqueId;

    public int Id { get => _id;}
    public int UniqueId { get => _uniqueId;}

    public abstract string Desc { get; }
    public abstract string ShortDesc { get; }

    public void RegenUniqueID()
    {
        _uniqueId = UnityEngine.Random.Range(0, int.MaxValue);
    }
    public override int GetHashCode()
    {
        return UniqueId;
    }
    public BonusSaveData SaveData() => new BonusSaveData(Id, UniqueId);
    public Bonus LoadData(BonusSaveData saveData)
    {
        _uniqueId=saveData.UniqueId;
        return this;
    }
}
