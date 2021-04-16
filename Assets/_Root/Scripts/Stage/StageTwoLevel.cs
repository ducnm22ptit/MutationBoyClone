using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class StageTwoLevel : BaseStage
{
    [SerializeField] private Sprite optionFirstImg;

    [SerializeField] private Sprite optionSecondImg;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    protected override void ShowOptionUI()
    {
        OptionUIController.Instance.ShowProgressBar(ProgressBarName.ProgressBarTwoLevel);

        base.ShowOptionUI();
    }

    protected override void HideOptionUI()
    {
        base.HideOptionUI();
        OptionUIController.Instance.ResetOptionUI();
    }

    protected virtual void OnContinue()
    {
        SoundController.Instance.StopAllSound();
        PopupController.Instance.ShowPopup(PopupName.ContinuePopup);
        SoundController.Instance.PlaySoundFx(AudioClipName.GameOver);
    }

    protected void ChangeImgOptionUI()
    {
        OptionUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = optionFirstImg;
        OptionUI.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = optionSecondImg;
    }
    protected virtual void BeforeOnPass(NameLevel nameLevelPass)
    {

        if ((int)nameLevelPass == 0)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.green, "Bar12");
        }
        else if ((int)nameLevelPass == 1)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.green, "Bar22");
        }
    }

    protected virtual void BeforeOnFail(NameLevel nameLevelFail)
    {
        if ((int)nameLevelFail == 0)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.red, "Bar12");
        }
        else if ((int)nameLevelFail == 1)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarTwoLevel, Color.red, "Bar22");
        }
    }
}

public enum NameLevel
{
    LevelFirst,
    LevelTwo
}
