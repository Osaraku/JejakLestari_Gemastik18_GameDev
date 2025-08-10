=== cleanRiverQuest ===

{ CleanRiverQuestState :
    - "REQUIREMENTS_NOT_MET": -> requirementsNotMet
    - "CAN_START": -> canStart
    - "CAN_FINISH": -> canFinish
    - "FINISHED": -> finished
    - else: -> END
}

= requirementsNotMet
-> END

= canStart
Halo, kamu mahasiswa KKM ya? Perkenalkan nama bapak Rudi
Bapak butuh bantuan mu untuk membersihkan sungai ini dari sampah

* [Tentu saja saya bisa, Pak. Siap laksanakan!]
    Terima kasih nak. Mari naik kapal bapak.
    ~ StartQuest("CleanRiverQuest")
* [Maaf Pak, untuk saat ini sepertinya saya belum bisa melakukannya.]
    Baiklah kalau begitu, aku paham kamu pasti sibuk dengan hal lainnya ya.
- -> END

= canFinish
Ah? Sudah dapat kotak p3k nya?
* [Sudah, ini pak]
    Kerja bagus sudah berhasil membantunya, aku tidak salah mempercayakan hal ini kepadamu nak!
~ FinishQuest("CleanRiverQuest")
-> END

= finished
Terima Kasih nak!
-> END