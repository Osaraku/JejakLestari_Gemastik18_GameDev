using System;

public class InventoryEvents
{
    public event Action onItemListChanged;
    public void ItemListChanged()
    {
        if (onItemListChanged != null)
        {
            onItemListChanged();
        }
    }
}
