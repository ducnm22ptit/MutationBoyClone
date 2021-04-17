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


    private void OnEnable()
    {
        claimBtn.gameObject.SetActive(true);
        CoinController.Instance.ReceivingCoin();
    }

    void Start()
    {


        claimBtn.onClick.AddListener(ClaimCoin);

        backButton.onClick.AddListener(BackPopup);

        tapContinueBtn.onClick.AddListener(TapToContinue);

        coinText.text = DataController.Instance.coinReward.ToString();


        DOTween.Sequence().AppendInterval(1.7f).AppendCallback(() =>
        {

            tapContinueBtn.gameObject.SetActive(true);
            tapContinueBtn.gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.7f).SetLoops(-1, LoopType.Yoyo);
        });
    }

    private void BackPopup()
    {

        completePopup.SetActive(false);
        DataController.Instance.indexLevel = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    private void TapToContinue()
    {
        DataController.Instance.indexLevel = 0;
        GameController.Instance.NextStage();
        completePopup.SetActive(false);
    }

    private void ClaimCoin()
    {
        claimBtn.gameObject.SetActive(false);

        float _myFloat = DataController.Instance.coinReward;

        DataController.Instance.coinReward += 250;

        DOTween.To(() =>
        {
            return _myFloat;
        }
        ,
        x =>
        {
            _myFloat = x;

            coinText.text = ((int)x).ToString();

        }, DataController.Instance.coinReward
        ,
        1f);


    }
}
