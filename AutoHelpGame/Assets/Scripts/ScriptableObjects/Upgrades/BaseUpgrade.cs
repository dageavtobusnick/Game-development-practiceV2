using System.Collections.Generic;
using UnityEngine;


public abstract class BaseUpgrade : ScriptableObject
{
    [SerializeField]
    private int _level;
    [SerializeField]
    private int _cost;

    public int Level { get => _level;}
    public int Cost { get => _cost;}
}

