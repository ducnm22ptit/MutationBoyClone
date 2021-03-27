using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePopup : MonoBehaviour
{
    [SerializeField] private Button backBtn;
    [SerializeField] private GameObject stagePopup;



    void Start()
    {
        backBtn.onClick.AddListener(BackHomeUI);
    }
    private void BackHomeUI()
    {
        stagePopup.gameObject.SetActive(false);
    }
}
