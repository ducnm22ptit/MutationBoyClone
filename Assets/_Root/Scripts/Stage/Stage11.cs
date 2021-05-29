using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage11 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation dogAnim, wolfAnim;

    [SerializeField] private SkeletonAnimation monkeyAnim, giraffeAnim, eagleAnim, snakeAnim, thunderDinoAnim, aboriginalAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx, windFx;

    [SerializeField] private GameObject firstStopPos, secondStopPos, thirdStopPos, wolfStopPos, egaleStopPos, dogStopPos, monkeyStopPos, stoneObject, footStepObject, secondFootStepObject, thirdFootStepObject;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;
    void Start()
    {
        if (DataController.Instance.indexLevel == 0)
        {
            IntroStageFirst();
            optionLeftBtn.onClick.AddListener(Option1);
            optionRightBtn.onClick.AddListener(Option2);
        }
        else if (DataController.Instance.indexLevel == 1)
        {
            IntroStageSecond();
            ChangeImgOptionUI();
            BeforeOnPass(NameThreeLevel.LevelFirst);
        }
        else if (DataController.Instance.indexLevel == 2)
        {
            IntroStageThird();
            ChangeImgTwoTimeOptionUI();
            BeforeOnPass(NameThreeLevel.LevelFirst);
            BeforeOnPass(NameThreeLevel.LevelSecond);
        }
    }

    private void IntroStageFirst()
    {
        Camera.main.gameObject.transform.DOMoveX(0f, 0f);
        thunderDinoAnim.AnimationState.SetAnimation(0, "idle", true);
        thunderDinoAnim.gameObject.transform.DOMove(boyAnim.transform.position, 3f).OnComplete(() =>
        {
            thunderDinoAnim.gameObject.SetActive(false);
            smokeBienFirstFx.Play();
            SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
            boyAnim.gameObject.SetActive(true);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                ShowOptionUI();
            });
            boyAnim.AnimationState.SetAnimation(0, "1/bi lac", true);
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.gameObject.transform.DOMoveX(9.4f, 0f);
        smokeBienSecondFx.Play();

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        wolfAnim.gameObject.SetActive(false);
        DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
        {
            Camera.main.gameObject.transform.DOMoveX(13.53f, 2f);
            boyAnim.gameObject.transform.DOMoveX(secondStopPos.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "2/idle", true);
                ChangeImgOptionUI();
                ShowOptionUI();
                optionLeftBtn.onClick.AddListener(Option11);
                optionRightBtn.onClick.AddListener(Option22);
            });
        });
    }
    private void IntroStageThird()
    {
        Camera.main.transform.DOMoveX(19.6f, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.transform.DOMoveX(thirdStopPos.transform.position.x, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.SetActive(true);
        Camera.main.transform.DOMoveX(25.3f, 2f);
        boyAnim.gameObject.transform.DOMoveX(smokeBienFifthFx.transform.position.x, 2.5f).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "3/doi bung", true);
            ChangeImgTwoTimeOptionUI();
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option111);
            optionRightBtn.onClick.AddListener(Option222);
        });
    }

    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        wolfAnim.gameObject.SetActive(true);
        wolfAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            wolfAnim.AnimationState.SetAnimation(0, "ngui", true);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                wolfAnim.AnimationState.SetAnimation(0, "walk", true);
                boyAnim.gameObject.transform.DOMoveX(firstStopPos.transform.position.x, 0f);
                Camera.main.gameObject.transform.DOMoveX(9.4f, 4f);
                Invoke("ShowFootStep", 2.2f);
                BeforeOnPass(NameThreeLevel.LevelFirst);
                wolfAnim.gameObject.transform.DOMoveX(wolfStopPos.transform.position.x, 4f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    wolfAnim.AnimationState.SetAnimation(0, "idle", false);
                    DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                    {
                        DataController.Instance.indexLevel += 1;
                        HideOptionUI();
                        IntroStageSecond();
                    });
                });
            });

        });
    }
    private void ShowFootStep()
    {
        footStepObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
        {
            secondFootStepObject.SetActive(true);
        }).OnComplete(() =>
        {
            DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
            {
                thirdFootStepObject.SetActive(true);
            });
        });
    }
    private void Option2()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        dogAnim.gameObject.SetActive(true);
        dogAnim.AnimationState.SetAnimation(0, "1/idle", true);
        DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
        {
            dogAnim.AnimationState.SetAnimation(0, "(2)/ngui", true);
            Camera.main.gameObject.transform.DOMoveX(5.72f, 3.5f);
            dogAnim.gameObject.transform.DOMoveX(dogStopPos.transform.position.x, 3.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelFirst);
                dogAnim.AnimationState.SetAnimation(0, "(2)/ngat", false);
                DOTween.Sequence().AppendInterval(1).AppendCallback(() =>
                {
                    HideOptionUI();
                    OnFail();
                });
            });
        });
    }

    private void Option11()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        snakeAnim.gameObject.SetActive(true);
        snakeAnim.AnimationState.SetAnimation(0, "swim", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            Camera.main.transform.DOMoveX(19.6f, 4f);
            Invoke("WindBlowing", 1.5f);
            BeforeOnPass(NameThreeLevel.LevelSecond);
            snakeAnim.gameObject.transform.DOMoveX(thirdStopPos.transform.position.x, 4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                SoundController.Instance.StopSoundFx();
                windFx.gameObject.SetActive(false);
                smokeBienFourthFx.Play();
                boyAnim.transform.DOMoveX(thirdStopPos.transform.position.x, 0f);
                boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                boyAnim.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                snakeAnim.gameObject.SetActive(false);
                DataController.Instance.indexLevel += 1;
                HideOptionUI();
                IntroStageThird();
            });
        });
    }

    private void WindBlowing()
    {
        windFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Wind);
    }
    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienThirdFx.gameObject.transform.DOMove(eagleAnim.gameObject.transform.position, 0f);
        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        eagleAnim.gameObject.SetActive(true);
        eagleAnim.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            Camera.main.transform.DOMoveX(15.78f, 3f);
            Invoke("WindBlowing", 0.5f);
            BeforeOnFail(NameThreeLevel.LevelSecond);
            eagleAnim.gameObject.transform.DOMove(egaleStopPos.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                eagleAnim.AnimationState.SetAnimation(0, "quat", true);
                eagleAnim.gameObject.transform.DOMoveX(egaleStopPos.transform.position.x - 3.5f, 2.5f);
                HideOptionUI();
                OnContinue();
            });
        });
    }

    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFifthFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        giraffeAnim.gameObject.SetActive(true);
        DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
        {
            smokeBienFifthFx.Play();
            boyAnim.AnimationState.SetAnimation(0, "0/run 2", true);
            boyAnim.gameObject.SetActive(true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
            giraffeAnim.gameObject.SetActive(false);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                BeforeOnPass(NameThreeLevel.LevelThird);
                boyAnim.gameObject.transform.DOMoveX(boyAnim.gameObject.transform.position.x + 5.5f, 2.7f).OnComplete(() =>
                {
                    HideOptionUI();
                    OnPass();
                });
            });
        });

    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFifthFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        monkeyAnim.gameObject.SetActive(true);

        monkeyAnim.AnimationState.SetAnimation(0, "step 1", false);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            monkeyAnim.AnimationState.SetAnimation(0, "step 2", false);
            aboriginalAnim.gameObject.SetActive(true);
            aboriginalAnim.AnimationState.SetAnimation(0, "can duong", true);
        });
        monkeyAnim.gameObject.transform.DOMove(monkeyStopPos.transform.position, 0.7f).SetEase(Ease.Linear).OnComplete(() =>
        {
            monkeyAnim.AnimationState.SetAnimation(0, "step 3", false);
            monkeyAnim.AnimationState.SetAnimation(0, "eat apple", true);
            aboriginalAnim.AnimationState.SetAnimation(0, "nem khi", false);
            DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
            {
                stoneObject.SetActive(true);
                stoneObject.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);
                stoneObject.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
                aboriginalAnim.AnimationState.SetAnimation(0, "idle", true);
                DOTween.Sequence().AppendInterval(1.4f).AppendCallback(() =>
                {
                    BeforeOnFail(NameThreeLevel.LevelThird);
                    monkeyAnim.AnimationState.SetAnimation(0, "bi duoi", true);
                    DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        OnContinue();
                    });
                });
            });
        });
    }
}


