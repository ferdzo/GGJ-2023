using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum NaturalDisaster
{
    TORNADO=2,
    GROM=3,
    POZAR=4
}

public class Counter  : MonoBehaviour
{
    [SerializeField] protected int Counter_Computer;
    [SerializeField] protected int Counter_Player;

    void Start()
    {
        Counter_Computer = 0;
        Counter_Player = 0;
    }

    public void AddToPlayer(int points)
    {
        Counter_Player += points;
    }

    
}
