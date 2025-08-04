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
}
