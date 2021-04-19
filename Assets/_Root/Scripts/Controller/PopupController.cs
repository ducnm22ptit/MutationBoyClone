using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopupController : Singleton<PopupController>
{
    [SerializeField] private List<GameObject> Popups;

    [SerializeField] private Button replayBtn;



    public void ShowPopup(PopupName popupName)
    {
        Popups[(int)popupName].gameObject.SetActive(true);
        replayBtn.gameObject.SetActive(false);
    }


    public void HidePopup(PopupName popupName)
    {
        Popups[(int)popupName].gameObject.SetActive(false);
    }

}
public enum PopupName
{
    ContinuePopup,
    CompletePopup,
    GameoverPopup
}
