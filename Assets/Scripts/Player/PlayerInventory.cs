using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private List<Item> itemList;
    private Action<Item> useItemAction;
    private int maxCapacity = 4;
    private int capacity = 0;

    public PlayerInventory(Action<Item> useItemAction)
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory && capacity < maxCapacity)
            {
                itemList.Add(item);
                capacity++;
            }
        }
        else
        {
            if (capacity < maxCapacity)
            {
                itemList.Add(item);
                capacity++;
            }
        }
        GameEventsManager.Instance.inventoryEvents.ItemListChanged();
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(item);
                capacity--;
            }
        }
        else
        {
            itemList.Remove(item);
            capacity--;
        }
        GameEventsManager.Instance.inventoryEvents.ItemListChanged();
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
