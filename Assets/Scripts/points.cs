using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    float naturePoints;
    float treeCost;
    float tsunamiCost;
    float tornadoCost;
    float thunderCost;
    int tornadoCount;
    int treeCount;
    int tsunamiCount;
    int thunderCount;
    float newNaturePoints;
    public float coolDownTime = 10f;
    private float nextUseTime;

    int newMaxTornado;
    int newMaxTree;
    int newMaxTsunami;
    int newMaxThunder;

    void Start()
    {
        naturePoints = 35;
        treeCost = 1;
        tsunamiCost = 2;
        tornadoCost = 2;
        thunderCost = 2;
        tornadoCount = 0;
        treeCount = 0;
        tsunamiCount = 0;
        thunderCount = 0;
    }

    public int GetCost(ChangePower.NatureType i)
    {
        switch(i)
        {
            case ChangePower.NatureType.Tsunami:
                return Mathf.CeilToInt(tsunamiCost);
            case ChangePower.NatureType.Tree:
                return Mathf.CeilToInt(treeCost);
            case ChangePower.NatureType.Thunder:
                return Mathf.CeilToInt(thunderCost);
            case ChangePower.NatureType.Tornado:
                return Mathf.CeilToInt(tornadoCost);
        }

        return 0;
    }

    public void PrintMax() {
      float maxTornado;
      float maxTree;
      float maxTsunami;
      float maxThunder;
      maxTornado = Random.Range(1, (int)((naturePoints / tornadoCost) / 2) + 1);
      newNaturePoints = naturePoints - (maxTornado * tornadoCost);
      maxTree = Random.Range(1, (int)((((newNaturePoints / 4) * 3) / treeCost) + 1));
      newNaturePoints = newNaturePoints - (maxTree * treeCost);
      maxTsunami = Random.Range(1, (int)((newNaturePoints) / tsunamiCost) + 1);
      newNaturePoints = newNaturePoints - (maxTsunami * tsunamiCost);
      maxThunder = newNaturePoints / thunderCost;
      if (maxThunder < 0) {
        PrintMax();
        return;
      }
      newMaxTornado = (int)Mathf.Ceil(maxTornado);
      newMaxTree = (int)Mathf.Ceil(maxTree);
      newMaxTsunami = (int)Mathf.Ceil(maxTsunami);
      newMaxThunder = (int)Mathf.Ceil(maxThunder);
      Debug.Log("tornado: " + newMaxTornado + " tree: " + newMaxTree + " tsunami: " + newMaxTsunami + " thunder: " + newMaxThunder);
      Debug.Log(newMaxTornado * tornadoCost + newMaxTree * treeCost + newMaxTsunami * tsunamiCost + newMaxThunder * thunderCost);
    }

    public bool notOnCooldown() {
      if (Time.time > nextUseTime)
      {
          nextUseTime = Time.time + coolDownTime;
          return true;
      } else {
        return false;
      }
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.M)) {
        PrintMax();
      }
      /*if (Input.GetKeyDown(KeyCode.H))
      {
        if (naturePoints > treeCost) {
          if (treeCount < maxTree) {
            if (notOnCooldown() == true) {
              Debug.Log("tree placed");
              treeCount = treeCount + 1;
              naturePoints = naturePoints + 1;
            } else {
              Debug.Log("on cooldown");
            }
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
            if (notOnCooldown() == true) {
              naturePoints = naturePoints - tsunamiCost;
              Debug.Log("tsunami placed");
              tsunamiCount = tsunamiCount + 1;
            } else {
              Debug.Log("on cooldown");
            }
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
            if (notOnCooldown() == true) {
              naturePoints = naturePoints - tornadoCost;
              Debug.Log("tornado placed");
              tornadoCount = tornadoCount + 1;
            } else {
              Debug.Log("on cooldown");
            }
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
            if (notOnCooldown() == true) {
              naturePoints = naturePoints - thunderCost;
              Debug.Log("thunderstorm placed");
              thunderCount = thunderCount + 1;
            } else {
              Debug.Log("on cooldown");
            }
          } else {
            Debug.Log("max thunderstorms se postaveni");
          }
        } else {
          Debug.Log("nemas dovolno poeni");
        }
      } */
    }
}
