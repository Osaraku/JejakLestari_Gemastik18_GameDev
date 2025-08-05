using System;

public class NPCEvents
{
    public event Action<string> onNPCInteracted;
    public void NPCInteracted(string npcName)
    {
        if (onNPCInteracted != null)
        {
            onNPCInteracted(npcName);
        }
    }
}
