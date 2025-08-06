using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    public TrashEvents trashEvents;
    public InventoryEvents inventoryEvents;
    public PlayerEvents playerEvents;
    public NPCEvents npcEvents;
    public QuestEvents questEvents;
    public CameraEvents cameraEvents;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        Instance = this;

        // initialize all events
        trashEvents = new TrashEvents();
        inventoryEvents = new InventoryEvents();
        playerEvents = new PlayerEvents();
        npcEvents = new NPCEvents();
        questEvents = new QuestEvents();
        cameraEvents = new CameraEvents();
    }
}
