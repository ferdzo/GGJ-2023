using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataValue : MonoBehaviour
{
    [SerializeField] public int points;
    [SerializeField] public Tile_type tiletype;
        public enum Tile_type{
        Player,
        Nature,
        Empty
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
