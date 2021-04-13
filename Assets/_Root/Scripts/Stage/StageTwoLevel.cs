using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwoLevel : BaseStage
{
    protected override void ShowOptionUI()
    {
        OptionUIController.Instance.ShowProgressBar(ProgressBarName.ProgressBarTwoLevel);

        base.ShowOptionUI();
        Debug.Log("Show");
    }

    protected override void HideOptionUI()
    {
        base.HideOptionUI();
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
            Debug.Log("PassLevelTwo");
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
            Debug.Log("PassLevelTwo");
        }
    }
}

public enum NameLevelPass
{
    passLevelFirst,
    passLevelTwo
}
