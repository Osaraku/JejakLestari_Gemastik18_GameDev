=== helpAnimal1 ===

{ HelpAnimalQuestState :
    - "REQUIREMENTS_NOT_MET": -> requirementsNotMet
    - "CAN_START": -> canStart
    - "IN_PROGRESS": -> inProgress
    - "CAN_FINISH": -> canFinish
    - "FINISHED": -> finished
    - else: -> END
}

= requirementsNotMet
-> END

= canStart
Gawat nak! Kuda milik bapak kakinya terkilir
Apakah kamu bisa bantu bapak ambilkan kotak p3k dari Pa Wahyu
* [Tentu saja saya bisa, Pak. Siap laksanakan!]
    ~ StartQuest("HelpAnimalQuest")
    Terima kasih nak. Aku tahu bisa mengandalkanmu. Rumahnya sebelah sana ya, hati-hati nak.
* [Maaf Pak, untuk saat ini sepertinya saya belum bisa melakukannya.]
    Baiklah kalau begitu, aku paham kamu pasti sibuk dengan hal lainnya ya.
- -> END

= inProgress
Bagaimana nak? apakah sudah dapat kotak p3knya?
-> END

= canFinish
Ah? Sudah dapat kotak p3k nya?
* [Sudah, ini pak]
    Kerja bagus sudah berhasil membantunya, aku tidak salah mempercayakan hal ini kepadamu nak!
~ FinishQuest("HelpAnimalQuest")
-> END

= finished
Terima Kasih nak! Kuda bapak sehat kembali
-> END
