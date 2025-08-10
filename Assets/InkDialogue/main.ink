// External Functions
EXTERNAL StartQuest(questId)
EXTERNAL AdvanceQuest(questId)
EXTERNAL FinishQuest(questId)

// Quest names
VAR TalkToPaKadesQuestId = "TalkToPaKadesQuest"
VAR CollectTrashQuestId = "CollectTrashQuest"
VAR HelpAnimalQuestId = "HelpAnimalQuest"
VAR CleanRiverQuestId = "HelpAnimalQuest"

// Quest states
VAR TalkToPaKadesQuestState = "REQUIREMENTS_NOT_MET"
VAR CollectTrashQuestState = "REQUIREMENTS_NOT_MET"
VAR HelpAnimalQuestState = "REQUIREMENTS_NOT_MET"
VAR CleanRiverQuestState = "REQUIREMENTS_NOT_MET"

// Ink files
INCLUDE collect_trash_npc.ink
INCLUDE menolong_hewan_1.ink
INCLUDE menolong_hewan_2.ink
INCLUDE clean_river_quest.ink
    
