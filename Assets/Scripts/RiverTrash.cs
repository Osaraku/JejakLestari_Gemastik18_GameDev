using UnityEngine;
using UnityEngine.Events;

public class RiverTrash : MonoBehaviour
{
    [SerializeField] string tagFilter;
    [SerializeField] int trashValue;
    [SerializeField] UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;

        Player.Instance.IncreaseTrashValue(trashValue);

        onTriggerEnter.Invoke();

        GameEventsManager.Instance.trashEvents.RiverTrashCollected();

        Destroy(gameObject);
    }
}
