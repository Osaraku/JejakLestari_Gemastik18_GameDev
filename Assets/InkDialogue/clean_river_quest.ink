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
Halo, kamu mahasiswa KKN ya? Perkenalkan nama bapak, Rudi. Bapak sehari-hari berkegiatan disini.
Coba lihat sungai ini, Nak. Dulu airnya jernih sekali, banyak kehidupan di sungai ini, tapi sekarang...
Bapak butuh bantuan mu untuk membersihkan sungai ini dari sampah, Nak. Kalau sendirian, rasanya tidak akan sanggup. Apakah kamu mau menolong Bapak, Nak?
* [Tentu saja saya bisa, Pak. Siap laksanakan!]
    Syukurlah! Bapak senang sekali mendengarnya. Terima kasih nak. Mari naik kapal bapak. Kita akan menyusuri sungai sambil menngumpulkan sampah-sampah itu.
    ~ StartQuest("CleanRiverQuest")
* [Maaf Pak, untuk saat ini sepertinya saya belum bisa melakukannya.]
    Yah..Baiklah kalau begitu, aku paham kamu pasti sibuk dengan hal lainnya ya.
- -> END

= canFinish
Hah...lihatlah hasil kerja keras kita, Nak. Perahu bapak ini memang jadi kotor begini dipenuhi sampah, tetapi sungainya jadi bisa bernapas dan memunjukan keindahannya lagi.
* [Iya, Pak! Betul sekali. Yang penting sungai ini menjadi bersih seperti yang bapak bilang sebelumnya.]
    Kerja bagus sekali, Nak! kamu sudah berhasil membantu bapak membersihkannya.
    Bapak tidak salah mempercayakan hal ini kepadamu, Nak! Bapak tidak mungkin bisa membersihkan ini sendirian.
~ FinishQuest("CleanRiverQuest")
-> END

= finished
Terima Kasih banyak, Nak! Berkat bantuanmu waktu itu, sekarang Bapak bisa berkegiatan di sungai ini dengan perasaan nyaman.
Sekarang Bapak bisa menebar jala lagi tanpa takut tersangkut sampah. Ikan-ikan pun kelihatannya mulai kembali.
-> END