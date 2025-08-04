using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    [SerializeField] private int trashAmount = 1;
    [SerializeField] private string interactText;
    [SerializeField] private ItemAssetsSO itemAssetsSO;

    private SphereCollider sphereCollider;
    private Transform visual;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        visual = transform.Find("Visual");
    }

    private void Start()
    {
        playerInventory = PlayerController.Instance.GetPlayerInventory();
    }

    public void Interact()
    {
        sphereCollider.enabled = false;
        visual.gameObject.SetActive(false);
        GameEventsManager.Instance.trashEvents.TrashCollected();
        playerInventory.AddItem(new Item { itemType = Item.ItemType.BottleTrash, amount = trashAmount });
        GameEventsManager.Instance.inventoryEvents.ItemListChanged();
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
