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

                Controller.itemPrefab = GameObject.Find(this.name);
            Debug.Log(Controller.itemPrefab.name);
        }
        else if (isSelected)
        {
            currentImage.sprite = unselectedItem;
            isSelected = false;
        }
    }
}