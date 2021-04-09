using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : Singleton<PopupController>
{
    [SerializeField] private List<GameObject> Popups;


    public void ShowPopup(PopupName popupName)
    {
        Popups[(int)popupName].gameObject.SetActive(true);
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
