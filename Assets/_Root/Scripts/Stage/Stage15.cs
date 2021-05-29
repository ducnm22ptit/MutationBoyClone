using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage15 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation deerAnim, turtleAnim, dinoAnim, rabbitAnim, dragonAnim, skunkAnim, dolphinAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx, smokeSkunkFx, fireDragonFx;

    [SerializeField] private GameObject dolphinStopPos, dragonStopPos, treeStopPos, coverObject, treeObject, firstRock, secondRock, thirdRock;

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
        Camera.main.transform.DOMoveX(0, 0);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMoveX(smokeBienFirstFx.gameObject.transform.position.x, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            ShowOptionUI();
        });
    }

    private void IntroStageSecond()
    {

        Camera.main.transform.DOMoveX(5.07f, 0f);
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        ShowOptionUI();
        optionLeftBtn.onClick.AddListener(Option11);
        optionRightBtn.onClick.AddListener(Option22);
    }

    private void IntroStageThird()
    {
        Camera.main.transform.DOMoveX(22, 0);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dragon);
        boyAnim.gameObject.transform.DOMove(smokeBienFourthFx.transform.transform.position, 0f);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            boyAnim.gameObject.transform.DOMoveX(smokeBienFifthFx.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                ShowOptionUI();
                optionLeftBtn.onClick.AddListener(Option111);
                optionRightBtn.onClick.AddListener(Option222);
            });
        });

    }

    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        deerAnim.gameObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            treeObject.transform.DOMove(treeStopPos.transform.position, 0.3f).OnComplete(() =>
            {
                treeObject.transform.DOMoveY(treeStopPos.transform.position.y - 50f, 2f).OnComplete(() =>
                {
                    smokeBienFirstFx.Play();
                    boyAnim.gameObject.SetActive(true);
                    boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                    deerAnim.gameObject.SetActive(false);
                    Camera.main.transform.DOMoveX(5.07f, 2f);
                    boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 2f).OnComplete(() =>
                    {
                        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                        HideOptionUI();
                        ChangeImgOptionUI();
                        DataController.Instance.indexLevel += 1;
                        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                        {
                            IntroStageSecond();
                        });
                    });
                });
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
        turtleAnim.gameObject.SetActive(true);
        turtleAnim.AnimationState.SetAnimation(0, "gather", false);
        coverObject.SetActive(false);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelFirst);
            turtleAnim.AnimationState.SetAnimation(0, "die", false);
            DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
            {
                turtleAnim.gameObject.SetActive(false);
            }).OnComplete(() =>
            {
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
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

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        rabbitAnim.gameObject.SetActive(true);
        rabbitAnim.AnimationState.SetAnimation(0, "run2", true);
        Camera.main.transform.DOMoveX(22, 6).SetEase(Ease.Linear);
        rabbitAnim.gameObject.transform.DOMove(firstRock.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            rabbitAnim.gameObject.transform.DOMove(secondRock.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnPass(NameThreeLevel.LevelSecond);
                rabbitAnim.gameObject.transform.DOMove(thirdRock.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    DataController.Instance.indexLevel += 1;
                    HideOptionUI();
                    ChangeImgTwoTimeOptionUI();
                    rabbitAnim.gameObject.transform.DOMove(smokeBienFourthFx.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        smokeBienFourthFx.Play();
                        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                        rabbitAnim.gameObject.SetActive(false);
                        IntroStageThird();
                    });
                });
            });
        });
    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        dolphinAnim.gameObject.SetActive(true);
        dolphinAnim.AnimationState.SetAnimation(0, "swim", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            Camera.main.transform.DOMoveX(12, 2.5f);
            BeforeOnFail(NameThreeLevel.LevelSecond);
            dolphinAnim.gameObject.transform.DOMoveX(dolphinStopPos.gameObject.transform.position.x, 2.5f).OnComplete(() =>
            {
                dolphinAnim.AnimationState.SetAnimation(0, "die", true);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    HideOptionUI();
                    OnContinue();
                });
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
        skunkAnim.gameObject.SetActive(true);
        skunkAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelThird);
            skunkAnim.gameObject.transform.DORotate(new Vector3(0, 360, 0), 0f);
            skunkAnim.AnimationState.SetAnimation(0, "deflate", false);
            smokeSkunkFx.Play();
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                dragonAnim.AnimationState.SetAnimation(0, "walk", true);
                dragonAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 360, 0), 0f);
                DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
                {
                    dragonAnim.gameObject.transform.DOMoveX(dragonStopPos.transform.position.x, 2f).OnComplete(() =>
                    {
                        smokeBienFifthFx.Play();
                        boyAnim.gameObject.SetActive(true);
                        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                        skunkAnim.gameObject.SetActive(false);
                        boyAnim.gameObject.transform.DOMoveX(dragonStopPos.transform.position.x - 2f, 3f).OnComplete(() =>
                        {
                            HideOptionUI();
                            OnPass();
                        });
                    });
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
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino1);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelThird);
            dinoAnim.AnimationState.SetAnimation(0, "die", false);
            fireDragonFx.Play();
            dragonAnim.AnimationState.SetAnimation(0, "fire", false);
            DOTween.Sequence().AppendInterval(3f).AppendCallback(() =>
            {
                HideOptionUI();
                OnContinue();
                fireDragonFx.Stop();
            });
        });
    }
}
