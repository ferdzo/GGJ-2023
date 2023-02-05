using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    int naturePoints;
    int treeCost;
    int tsunamiCost;
    int tornadoCost;
    int thunderCost;
    int maxTornado;
    int maxTree;
    int maxTsunami;
    int maxThunder;
    int tornadoCount;
    int treeCount;
    int tsunamiCount;
    int thunderCount;

    void Start()
    {
        naturePoints = 35;
        treeCost = 0;
        tsunamiCost = 8;
        tornadoCost = 5;
        thunderCost = 5;
        maxTornado = 2;
        maxTree = 2;
        maxTsunami = 1;
        maxThunder = 2;
        tornadoCount = 0;
        treeCount = 0;
        tsunamiCount = 0;
        thunderCount = 0;
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.H))
      {
        if (naturePoints > treeCost) {
          if (treeCount < maxTree) {
            Debug.Log("tree placed");
            treeCount = treeCount + 1;
            naturePoints = naturePoints + 1;
          } else {
            Debug.Log("max tree se postaveni");
          }
        } else {
          Debug.Log("nemas dovolno poeni");
        }
      }
      if (Input.GetKeyDown(KeyCode.J))
      {
        if (naturePoints > tsunamiCost) {
          if (tsunamiCount < maxTsunami) {
            naturePoints = naturePoints - tsunamiCost;
            Debug.Log("tsunami placed");
            tsunamiCount = tsunamiCount + 1;
          } else {
            Debug.Log("max tsunami se postaveni");
          }
        } else {
          Debug.Log("nemas dovolno poeni");
        }
      }
      if (Input.GetKeyDown(KeyCode.K))
      {
        if (naturePoints > tornadoCost) {
          if (tornadoCount < maxTornado) {
            naturePoints = naturePoints - tornadoCost;
            Debug.Log("tornado placed");
            tornadoCount = tornadoCount + 1;
          } else {
            Debug.Log("max tornado se postaveni");
          }
        } else {
          Debug.Log("nemas dovolno poeni");
        }
      }
      if (Input.GetKeyDown(KeyCode.L))
      {
        if (naturePoints > thunderCost) {
          if (thunderCount < maxThunder) {
            naturePoints = naturePoints - thunderCost;
            Debug.Log("thunderstorm placed");
            thunderCount = thunderCount + 1;
          } else {
            Debug.Log("max thunderstorms se postaveni");
          }
        } else {
          Debug.Log("nemas dovolno poeni");
        }
      }
    }
}
