using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneLevel : BaseStage
{

    protected override void ShowOptionUI()
    {
        OptionUIController.Instance.ShowProgressBar(ProgressBarName.ProgressBarOneLevel);

        base.ShowOptionUI();
    
    }

    protected override void HideOptionUI()
    {
        base.HideOptionUI();
    }

    protected virtual void BeforeOnPass()
    {
        OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarOneLevel, Color.green, "Bar11");
    }

    protected virtual void BeforeOnFail()
    {
        OptionUIController.Instance.ChangeColorBar(ProgressBarName.ProgressBarOneLevel, Color.red, "Bar11");
    }
}
