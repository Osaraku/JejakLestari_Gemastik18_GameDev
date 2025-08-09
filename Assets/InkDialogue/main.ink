// External Functions
EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)

// Quest names
VAR CollectTrashQuestId = "CollectTrashQuest"
VAR HelpAnimalQuestId = "HelpAnimalQuest"

// Quest states
VAR CollectTrashQuestState = "REQUIREMENTS_NOT_MET"
VAR HelpAnimalQuestState = "REQUIREMENTS_NOT_MET"

// Ink files
INCLUDE collect_trash_npc.ink
INCLUDE menolong_hewan_1.ink
INCLUDE menolong_hewan_2.ink
    
