=== helpAnimal2 ===

{ HelpAnimalQuestState :
    - "IN_PROGRESS": -> inProgress
    - "FINISHED": -> finished
    - else: -> END
}

= inProgress
Ada apa nak? Kamu buru-buru sekali kesini?
* [Pak, tolong kudanya Pa Restu terluka dan minta diambilkan kotak P3K]
    Astaga, kasihan sekali kudanya. 
    Tentu saja boleh. Oh iya ini, tolong segera berikan pada Pa Restu ya. Semoga lukanya tidak parah.
-> END

= finished
Terima Kasih nak! Berkat kamu yang cepat memberikan kotaknya ke Pa Restu, bapak denngar kudanya sudah sehat kembali.
-> END
