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
Gawat nak! Kuda milik bapak kakinya terkilir saat tadi berjalan.
Bapak tidak berani meninggalkannya sendirian disini, bapak juga tidak menemukan orang lain yang membantu saat ini.
Apakah kamu bisa bantu bapak ambilkan kotak p3k dari Pa Wahyu?
* [Tentu saja saya bisa, Pak. Siap laksanakan!]
    ~ StartQuest("HelpAnimalQuest")
    Terima kasih nak. Aku tahu bisa mengandalkanmu. Rumahnya sebelah sana ya, hati-hati nak.
* [Maaf Pak, untuk saat ini sepertinya saya belum bisa melakukannya.]
    Oh, begituu... Baiklah kalau begitu, aku paham kamu pasti sibuk dengan hal lainnya ya.
- -> END

= inProgress
Bagaimana nak? apakah sudah dapat kotak p3knya? Kasihan kuda bapak kesakitan dari tadi.
-> END

= canFinish
Ah? Syukurlah kamau kembali saat ini! Sudah dapat kotak p3k nya?
* [Sudah, ini pak]
    Wah, kerja bagus sudah berhasil membantu bapak mengambilkan obat yang diperlukan, aku tidak salah mempercayakan hal ini kepadamu nak!
    Baiklah kalau begitu, aku akan mengobatinya lukanya sekarang!
~ FinishQuest("HelpAnimalQuest")
-> END

= finished
Terima Kasih nak!
Kuda bapak sehat kembali berkat bantuan cepat darimu waktu itu. Sekarang dia sudah bisa berlari-lari lagi di padang.
-> END
