using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataValue : MonoBehaviour
{
    [SerializeField]protected int points;
    [SerializeField] protected Tile_type tiletype;
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
