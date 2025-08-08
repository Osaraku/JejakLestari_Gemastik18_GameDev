=== collectTrashQuest ===

{ CollectTrashQuestState :
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
Halo, selamat datang di Desa Rimbayu
Semoga betah hehe
Desa ini skrg cukup kotor, bisakah anda membantu membersihkan sampah?
* [Bisa, akan saya lakukan]
    ~ StartQuest("CollectTrashQuest")
    Terimakasih Nak!
* [Maaf, saya ada keperluan lain]
    Oh baiklah kalau begitu.
- -> END

= inProgress
Bagaimana proses membersihkan sampahnya? saya lihat masih ada beberapa sampah
Semangat ya!
-> END

= canFinish
Oh? Kamu sudah membersihkan sampahnya? terimakasih ya
~ FinishQuest("CollectTrashQuest")
-> END

= finished
Terimakasih, telah membantu membersihkan sampah. Desanya terlihat lebih bersih
-> END
