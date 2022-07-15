using System.Collections;
using UnityEngine;


public abstract class Bonus : ScriptableObject
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private int _uniqueId;
    private void Awake()
    {

    }
}
