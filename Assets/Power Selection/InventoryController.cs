using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject[] items;
    public List<GameObject> selected = new List<GameObject>();

    public GameObject itemPrefab;
    public GameObject PointsCostIndicator;

    public ChangePower SelectedItem = null;

    public TMP_Text _hoverText;

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

    private void Update()
    {
        TileManager tiles = FindObjectOfType<TileManager>();
        if (tiles.SelectedTile == null || tiles.SelectedTile.tiletype != DataValue.Tile_type.Player)
        {
            _hoverText.text = "NO TILE SELECTED ";
            _hoverText.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            _hoverText.text = tiles.SelectedTile.points.ToString();

            _hoverText.transform.parent.gameObject.SetActive(true);

            Vector3 pos = Camera.main.WorldToScreenPoint(tiles.SelectedTile.transform.position);
            _hoverText.transform.parent.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    public void DisplayPointsCost()
    {
        if(itemPrefab == null)
        {
            return;
        }

        int cost = FindObjectOfType<points>().GetCost(SelectedItem.GetComponent<ChangePower>().natureType);

        TileManager tiles = FindObjectOfType<TileManager>();
        if(tiles.SelectedTile == null)
        {
            return;
        }

        if (tiles.SelectedTile.tiletype == DataValue.Tile_type.Nature)
        {
            return;
        }

        tiles.SelectedTile.points -= cost;
        if(tiles.SelectedTile.points < 0)
        {
            cost -= tiles.SelectedTile.points * -1;
        }

        FindObjectOfType<TileManager>().NatureAddTile((tiles.SelectedTile.points > 0) ? null : itemPrefab);


        Vector3 mousePosition = Input.mousePosition;
        //GameObject.Find("PointsCostIndicator").GetComponent<RectTransform>().anchoredPosition = mousePosition;
        GameObject indicator = GameObject.Instantiate(PointsCostIndicator, transform.parent);
        indicator.GetComponent<RectTransform>().anchoredPosition = mousePosition;
        indicator.GetComponentInChildren<TMPro.TMP_Text>().text = "_" + cost;

        StartCoroutine(timerCountdown(indicator));
    }

    public IEnumerator timerCountdown (GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(1);
        Destroy(objectToDestroy);
    }
}
