using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class OptionUIController : Singleton<OptionUIController>
{
    [SerializeField] private List<GameObject> progressBarList;

    [SerializeField] private Button leftBtn, rightBtn;

    [SerializeField] private TextMeshProUGUI textTo, textFrom;




    private void OnEnable()
    {
        var a = Random.Range(1, 50);

        if (a < 25)
        {
            SwapOption(leftBtn.gameObject.GetComponent<RectTransform>(), rightBtn.gameObject.GetComponent<RectTransform>());
        }

        SetIndexText();
    }

    private void Start()
    {

        leftBtn.onClick.AddListener(() =>
        {
            ShowResultButton(leftBtn.gameObject.GetComponent<RectTransform>());
        });

        rightBtn.onClick.AddListener(() =>
        {
            ShowResultButton(rightBtn.gameObject.GetComponent<RectTransform>());
        });


    }

    private void SwapOption(RectTransform left, RectTransform right)
    {
        Vector3 tmp = left.localPosition;

        left.localPosition = right.localPosition;

        right.localPosition = tmp;
    }

    public void ShowProgressBar(ProgressBarName progressBarName)
    {
        progressBarList[(int)progressBarName].SetActive(true);
    }

    public void ChangeColorBar(ProgressBarName progressBarName, Color color, string nameBar)
    {
        if (progressBarList[(int)progressBarName].transform.GetChild(0).transform.name == nameBar)
        {
            progressBarList[(int)progressBarName].transform.GetChild(0).transform.GetComponent<Image>().color = color;
        }
        else if (progressBarList[(int)progressBarName].transform.GetChild(1).transform.name == nameBar)
        {
            progressBarList[(int)progressBarName].transform.GetChild(1).transform.GetComponent<Image>().color = color;
        }
        else if (progressBarList[(int)progressBarName].transform.GetChild(2).transform.name == nameBar)
        {
            progressBarList[(int)progressBarName].transform.GetChild(2).transform.GetComponent<Image>().color = color;
        }
    }

    private void SetIndexText()
    {
        textFrom.text = (DataController.Instance.currentStage + 1).ToString();
        textTo.text = (DataController.Instance.currentStage + 2).ToString();
    }

    private void ShowResultButton(RectTransform transform)
    {
        if (transform.GetChild(1).transform.name == "Overlay")
        {
            transform.GetChild(1).transform.gameObject.SetActive(true);
        }

        DOTween.Sequence().AppendInterval(2.5f).AppendCallback(() =>
        {
            if (transform.GetChild(2).transform.name == "Result" && transform.name == "Option2")
            {
                SoundController.Instance.PlaySoundFx(AudioClipName.FailChoose1);
            }
            else if (transform.GetChild(2).transform.name == "Result" && transform.name == "Option1")
            {
                SoundController.Instance.PlaySoundFx(AudioClipName.Pass);
            }
            transform.GetChild(2).transform.gameObject.SetActive(true);

        });

        leftBtn.onClick.RemoveAllListeners();
        rightBtn.onClick.RemoveAllListeners();
    }

    public void ResetOptionUI()
    {
        leftBtn.onClick.AddListener(() =>
        {
            ShowResultButton(leftBtn.gameObject.GetComponent<RectTransform>());
        });

        rightBtn.onClick.AddListener(() =>
        {
            ShowResultButton(rightBtn.gameObject.GetComponent<RectTransform>());
        });
        for (int i = 1; i < 3; i++)
        {
            leftBtn.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            rightBtn.gameObject.transform.GetChild(i).gameObject.SetActive(false);           
        }
    }
}


public enum ProgressBarName
{
    ProgressBarOneLevel,
    ProgressBarTwoLevel,
    ProgreessBarThreeLevel
}