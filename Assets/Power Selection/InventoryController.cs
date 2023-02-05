using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject[] items;
    public List<GameObject> selected = new List<GameObject>();

    public GameObject itemPrefab;
    public GameObject PointsCostIndicator;

    public void UnselectOthers()
    {
        foreach (GameObject obj in items)
        {
            if (obj.GetComponent<ChangePower>().isSelected == true)
            {
                selected.Add(obj);
            }
        }

        if (selected.Count > 0)
        {
            ChangePower chngPower = selected[0].GetComponent<ChangePower>();
            chngPower.currentImage.sprite = chngPower.unselectedItem;
            chngPower.isSelected = false;
            selected.Clear();
        }
    }

    public void DisplayPointsCost()
    {
        Vector3 mousePosition = Input.mousePosition;
        //GameObject.Find("PointsCostIndicator").GetComponent<RectTransform>().anchoredPosition = mousePosition;
        GameObject indicator = GameObject.Instantiate(PointsCostIndicator, transform.parent);
        indicator.GetComponent<RectTransform>().anchoredPosition = mousePosition;
        StartCoroutine(timerCountdown(indicator));
    }

    public IEnumerator timerCountdown (GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(1);
        Destroy(objectToDestroy);
    }
}
