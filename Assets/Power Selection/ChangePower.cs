using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ChangePower : MonoBehaviour
{
    public Image currentImage;
    public Sprite selectedItem;
    public Sprite unselectedItem;
    public bool isSelected = false;

    public GameObject _prefabToInstantiate;

    public NatureType natureType; 

    public enum NatureType
    {
        Tsunami,
        Tree,
        Tornado,
        Thunder
    }


    public void ToggleItem()
    {
        GameObject Container = GameObject.Find("Background");
        InventoryController Controller = Container.GetComponent<InventoryController>();

        // Selects the item that was clicked on. Additionally, unselects other selected item.
        if (isSelected == false)
        {
            Controller.UnselectOthers();
            currentImage.sprite = selectedItem;
            isSelected = true;
            //TODO: CHANGE PREFAB TO THE APPROPRIATE ONE 
            // ex. this.name + _prefab;

            Controller.itemPrefab = _prefabToInstantiate;
            Controller.SelectedItem = this;
        }
        else if (isSelected)
        {
            Controller.itemPrefab = null;
            Controller.SelectedItem = null;
            currentImage.sprite = unselectedItem;
            isSelected = false;
        }
    }
}