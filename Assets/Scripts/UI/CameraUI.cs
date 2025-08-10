using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    [SerializeField] private GameObject phoneImage;
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;

    private Texture2D screenCapture;
    private bool viewingPhoto;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Hide();
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera += Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera += Hide;

        GameEventsManager.Instance.inputEvents.onClickPressed += PhotoPressed;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.cameraEvents.onCameraChangeToFirstPersonCamera -= Show;
        GameEventsManager.Instance.cameraEvents.onCameraChangeToThirdPersonCamera -= Hide;
        GameEventsManager.Instance.inputEvents.onClickPressed -= PhotoPressed;
    }

    private void Show()
    {
        visual.SetActive(true);
    }

    private void Hide()
    {
        visual.SetActive(false);
    }

    private void PhotoPressed(InputEventContext inputEventContext)
    {
        if (!inputEventContext.Equals(InputEventContext.CAMERA))
        {
            return;
        }
        if (!viewingPhoto)
        {
            StartCoroutine(CapturePhoto());
        }
        else
        {
            RemovePhoto();
        }
    }

    IEnumerator CapturePhoto()
    {
        phoneImage.SetActive(false);
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

    private void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
    }

    private void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
        phoneImage.SetActive(true);
    }
}
