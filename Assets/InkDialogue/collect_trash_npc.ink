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
Halo, nak! selamat datang ya di Desa Rimbayu.
Semoga kamu betah tinggal di desa ini
Bapak sebenarnya sedikit sedih, Nak. Desa ini sekarang cukup kotor, dijalanan banyak sekali sampah yang berserakan.
Sampah-sampah itu merusak pemandangan desa yang seharusnya indah dan bersih menjadi rusak.
Mumpung ada mahasiswa KKN yang rajin disini, bisakah kamu membantu bapak untuk membersihkan sampah-sampah tersebut, Nak?
* [Tentu saja bisa, Pak. Akan saya lakukan dengan senang hati]
    ~ StartQuest("CollectTrashQuest")
    Terimakasih ya, Nak! Hati bapak jadi lebih tenang.
* [Maaf, Pak, saya ada keperluan lain saat ini.]
    Oh baiklah kalau begitu. tidak apa-apa. Mungkin lain kali saja bila kamu sudah ada waktu luang, Nak.
- -> END

= inProgress
Wah, rajin sekali kamu kerjanya, Nak!
Bagaimana proses membersihkan sampahnya? Bapak lihat masih ada beberapa sampah yang ada di jalanan.
Semangat ya! Kamu pasti bisa membereskannya, Nak.
-> END

= canFinish
Oh? Kamu sudah membersihkan semua sampah yang berserakan itu? 
Desa ini kembali memiliki keindahan lagi tanpa sampah-sampah itu.
Terima kasih ya, Nak. Kamu sudah memberi contoh untuk warga desa ini untuk selalu menjaga lingkungannya.
~ FinishQuest("CollectTrashQuest")
-> END

= finished
Terimakasih sekali lagi ya, Nak, telah membantu membersihkan sampah. Desanya terlihat lebih bersih dan asri sekarang.
Semoga setelah ini kita lebih sadar untuk bisa mejaga kebersihan desa ini bersama-sama.
-> END
