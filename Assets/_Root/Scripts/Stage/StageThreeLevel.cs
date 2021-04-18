using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class StageThreeLevel : BaseStage
{
    [SerializeField] private Sprite optionFirstImg;

    [SerializeField] private Sprite optionSecondImg;

    [SerializeField] private Sprite optionThirdImg;

    [SerializeField] private Sprite optionFourthImg;


    protected override void ShowOptionUI()
    {
        OptionUIController.Instance.ShowProgressBar(ProgressBarName.ProgreessBarThreeLevel);

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

    protected void ChangeImgTwoTimeOptionUI()
    {
        OptionUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = optionThirdImg;
        OptionUI.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().sprite = optionFourthImg;
    }
    protected virtual void BeforeOnPass(NameThreeLevel nameLevelPass)
    {

        if ((int)nameLevelPass == 0)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgreessBarThreeLevel, Color.green, "Bar13");
        }
        else if ((int)nameLevelPass == 1)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgreessBarThreeLevel, Color.green, "Bar23");
        }
        else if ((int)nameLevelPass == 2)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgreessBarThreeLevel, Color.green, "Bar33");
        }
    }

    protected virtual void BeforeOnFail(NameThreeLevel nameLevelFail)
    {
        if ((int)nameLevelFail == 0)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgreessBarThreeLevel, Color.red, "Bar13");
        }
        else if ((int)nameLevelFail == 1)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgreessBarThreeLevel, Color.red, "Bar23");
        }
        else if ((int)nameLevelFail == 2)
        {
            OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgreessBarThreeLevel, Color.red, "Bar33");
        }
    }
}

public enum NameThreeLevel
{
    LevelFirst,
    LevelSecond,
    LevelThird
}
