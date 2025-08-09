=== helpAnimal2 ===

{ HelpAnimalQuestState :
    - "IN_PROGRESS": -> inProgress
    - "FINISHED": -> finished
    - else: -> END
}

= inProgress
Ada apa nak?
* [Pak, tolong kudanya Pa Restu terluka dan minta diambilkan kotak p3k]
    Oh iya ini
-> END

= finished
Terima Kasih nak! Kuda bapak sehat kembali
-> END
