using UnityEngine;

public class Item
{
    public enum ItemType
    {
        BottleTrash,
        CanTrash,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.BottleTrash: return ItemAssets.Instance.bottleTrashSO.sprite;
            case ItemType.CanTrash: return ItemAssets.Instance.canTrashSO.sprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.BottleTrash:
                return true;
        }
    }


}
