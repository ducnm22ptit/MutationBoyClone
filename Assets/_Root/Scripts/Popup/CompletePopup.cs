using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CompletePopup : MonoBehaviour
{

    [SerializeField] private GameObject completePopup;

    [SerializeField] private Button claimBtn;

    [SerializeField] private Button tapContinueBtn;

    [SerializeField] private Button backButton;

    [SerializeField] private TextMeshProUGUI coinText;


    void Start()
    {
        claimBtn.onClick.AddListener(ClaimCoin);

        backButton.onClick.AddListener(BackPopup);

        tapContinueBtn.onClick.AddListener(TapToContinue);

        coinText.text = DataController.Instance.coinReward.ToString();
    }

    private void BackPopup()
    {
        completePopup.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    private void TapToContinue()
    {

    }

    private void ClaimCoin()
    {
        claimBtn.gameObject.SetActive(false);

        float _myFloat = DataController.Instance.coinReward;

        DOTween.To(() =>
        {
            return _myFloat;
        }
        ,
        x =>
        {
            _myFloat = x;

            coinText.text = ((int)x).ToString();
            
            DataController.Instance.coinReward = x;
        },
        DataController.Instance.coinReward + 50,
        2f);

        
    }
}
