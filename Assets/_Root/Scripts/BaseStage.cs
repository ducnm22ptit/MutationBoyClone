using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseStage : MonoBehaviour
{
    [SerializeField] protected GameObject OptionUI;


    protected virtual void OnPass()
    {
        SoundController.Instance.PauseAllSound();
        PopupController.Instance.ShowPopup(PopupName.CompletePopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.WinPopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.WinPopupAdd);

    }

    protected virtual void OnFail()
    {
        SoundController.Instance.PauseAllSound();
        PopupController.Instance.ShowPopup(PopupName.GameoverPopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.GameOver);
    }

    protected virtual void HideOptionUI()
    {
        OptionUI.SetActive(false);
    }

    protected virtual void ShowOptionUI()
    {
        OptionUI.SetActive(true);

    }



}
