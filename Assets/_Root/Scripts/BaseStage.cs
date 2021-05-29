using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseStage : MonoBehaviour
{
    [SerializeField] protected GameObject OptionUI;


    protected virtual void OnPass()
    {
        SoundController.Instance.StopAllSound();
        PopupController.Instance.ShowPopup(PopupName.CompletePopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.WinPopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.WinPopupAdd);
        if (DataController.Instance.currentStage == DataController.Instance.indexStage)
        {
            DataController.Instance.indexStage += 1;
        }
    }

    protected virtual void OnFail()
    {
        SoundController.Instance.StopAllSound();
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
