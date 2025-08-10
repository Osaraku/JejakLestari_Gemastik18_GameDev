using System;

public class TrashEvents
{
    public event Action onTrashCollected;
    public void TrashCollected()
    {
        if (onTrashCollected != null)
        {
            onTrashCollected();
        }
    }

    public event Action onRiverTrashCollected;
    public void RiverTrashCollected()
    {
        if (onRiverTrashCollected != null)
        {
            onRiverTrashCollected();
        }
    }
}
