using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject PengaturanPanel;

    public TMP_Dropdown resolusiDropdown;
    public Toggle layarPenuhToggle;
    public Slider musikSlider;
    public Slider sfxSlider;
    public AudioMixer audioMixer;

    private Resolution[] resolusi;

    void Start()
    {
        MenuPanel.SetActive(true);
        PengaturanPanel.SetActive(false);

        InisialisasiPengaturan();
    }

    private void InisialisasiPengaturan()
    {
        resolusi = Screen.resolutions;
        resolusiDropdown.ClearOptions();

        List<string> opsi = new List<string>();
        int resolusiSaatIniIndex = 0;
        for (int i = 0; i < resolusi.Length; i++)
        {
            string opsiString = resolusi[i].width + "x" + resolusi[i].height;
            opsi.Add(opsiString);

            if (resolusi[i].width == Screen.currentResolution.width &&
                resolusi[i].height == Screen.currentResolution.height)
            {
                resolusiSaatIniIndex = i;
            }
        }

        resolusiDropdown.AddOptions(opsi);
        resolusiDropdown.value = resolusiSaatIniIndex;
        resolusiDropdown.RefreshShownValue();

        layarPenuhToggle.isOn = Screen.fullScreen;

        float musikVolume;
        if (audioMixer.GetFloat("MusikVolume", out musikVolume))
        {
            musikSlider.value = Mathf.Pow(10, musikVolume / 20);
        }

        float sfxVolume;
        if (audioMixer.GetFloat("SFXVolume", out sfxVolume))
        {
            sfxSlider.value = Mathf.Pow(10, sfxVolume / 20);
        }
    }

    public void PengaturanButton()
    {
        MenuPanel.SetActive(false);
        PengaturanPanel.SetActive(true);
    }

    // Kembali
    public void BackButton()
    {
        MenuPanel.SetActive(true);
        PengaturanPanel.SetActive(false);
    }

    // Start
    public void StartButton(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    // Keluar 
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Tombol Keluar Telah Ditekan");
    }

    // Resolusi
    public void AturResolusi(int indexResolusi)
    {
        Resolution res = resolusi[indexResolusi];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    // Layar penuh
    public void AturLayarPenuh(bool isLayarPenuh)
    {
        Screen.fullScreen = isLayarPenuh;
    }

    // Volume musik
    public void AturVolumeMusik(float volume)
    {
        audioMixer.SetFloat("MusikVolume", Mathf.Log10(volume) * 20);
    }

    // Efek suara
    public void AturVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}