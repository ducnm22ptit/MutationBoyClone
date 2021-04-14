using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class StageTwoLevel : BaseStage
{
    [SerializeField] private Sprite optionFirstImg;

    [SerializeField] private Sprite optionSecondImg;

    protected override void ShowOptionUI()
    {
        OptionUIController.Instance.ShowProgressBar(ProgressBarName.ProgressBarTwoLevel);

        base.ShowOptionUI();
    }

    protected override void HideOptionUI()
    {
        base.HideOptionUI();
    }

    protected virtual void OnContinue()
    {
        SoundController.Instance.StopAllSound();
        PopupController.Instance.ShowPopup(PopupName.ContinuePopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.GameOver);
        SoundController.Instance.PlaySoundFx(AudioClipName.GameOver);
    }

    protected void ChangeImgOptionUI()
    {
        OptionUI.transform.GetChild(0).GetComponentInChildren<Image>().sprite = optionFirstImg;
        OptionUI.transform.GetChild(1).GetComponentInChildren<Image>().sprite = optionSecondImg;
    }

    protected virtual void BeforeOnPass(NameLevelPass nameLevelPass)
    {
       
        if ((int)nameLevelPass == 0)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.green, "Bar12");
        }
        else if((int)nameLevelPass == 1)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.green, "Bar22");
        }
    }

    protected virtual void BeforeOnFail(NameLevelPass nameLevelPass)
    {
        if ((int)nameLevelPass == 0)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.red, "Bar12");
        }
        else if ((int)nameLevelPass == 1)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.red, "Bar22");
        }
    }
}

public enum NameLevelPass
{
    passLevelFirst,
    passLevelTwo
}
