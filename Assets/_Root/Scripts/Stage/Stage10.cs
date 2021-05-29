using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage10 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation geckoAnim, cowAnim;

    [SerializeField] private SkeletonAnimation robotFisrtAnim, robotSecondAnim;

    [SerializeField] private SkeletonAnimation monkeyAnim, eelAnim, moleAnim, dinoAnim, thunderDinoAnim;

    [SerializeField] private SkeletonAnimation doctorAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, dirtyGroundFx, eplosionFireFx;

    [SerializeField] private GameObject boyStopPos, secondStopPos, wallEscape, netObject, rocketObject, robotSquad, holeObject, wallObject, brokenWallObject, brokenBg, Bg;

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

    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        cowAnim.gameObject.SetActive(true);
        cowAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            cowAnim.AnimationState.SetAnimation(0, "butt", false);
            cowAnim.gameObject.transform.DOMoveX(cowAnim.gameObject.transform.position.x + 1f, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                cowAnim.AnimationState.SetAnimation(0, "idle", true);
                doctorAnim.AnimationState.SetAnimation(0, "fly", false);
                BeforeOnPass(NameThreeLevel.LevelFirst);
                doctorAnim.gameObject.transform.DOMove(secondStopPos.transform.position, 1.5f).OnComplete(() =>
                {
                    doctorAnim.gameObject.SetActive(false);
                    smokeBienFirstFx.Play();
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                    cowAnim.gameObject.SetActive(false);
                    boyAnim.gameObject.SetActive(true);
                    boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
                    DataController.Instance.indexLevel += 1;
                    HideOptionUI();
                    IntroStageSecond();
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
        geckoAnim.gameObject.SetActive(true);
        geckoAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            geckoAnim.AnimationState.SetAnimation(0, "fade out", false);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                doctorAnim.AnimationState.SetAnimation(0, "Catch", false);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    geckoAnim.AnimationState.SetAnimation(0, "idle", true);
                    doctorAnim.AnimationState.SetAnimation(0, "runmachine", true);
                    doctorAnim.gameObject.transform.DOMoveX(geckoAnim.transform.position.x + 1f, 1f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        smokeBienFirstFx.Play();
                        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                        geckoAnim.gameObject.SetActive(false);
                        boyAnim.gameObject.SetActive(true);
                        doctorAnim.AnimationState.SetAnimation(0, "shout", true);
                        HideOptionUI();
                        OnFail();
                    });

                });

            });
        });
    }

    private void Option11()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        robotFisrtAnim.AnimationState.SetAnimation(0, "attack", false);
        DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "fall2", true);
            boyAnim.gameObject.transform.DOMoveY(boyAnim.gameObject.transform.position.y + 1.3f, 0.3f);
        });
        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
         {
             smokeBienFirstFx.Play();
             boyAnim.gameObject.SetActive(false);
             SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
             eelAnim.gameObject.SetActive(true);
             eelAnim.AnimationState.SetAnimation(0, "idle2", true);
             DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
             {
                 BeforeOnPass(NameThreeLevel.LevelSecond);
                 eelAnim.gameObject.transform.DOMoveY(eelAnim.gameObject.transform.position.y - 1.7f, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
                 {
                     eelAnim.gameObject.transform.DOMoveX(robotSecondAnim.gameObject.transform.position.x + 7f, 4f);
                     robotSecondAnim.AnimationState.SetAnimation(0, "shoot", false);
                     DOTween.Sequence().AppendInterval(0.4f).AppendCallback(() =>
                     {
                         netObject.gameObject.SetActive(true);
                         netObject.transform.DOMoveY(netObject.transform.position.y - 1.2f, 0.5f);
                         Camera.main.transform.DOMoveX(robotSecondAnim.gameObject.transform.position.x + 7f, 6f);
                         DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                         {
                             smokeBienSecondFx.Play();
                             SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                             eelAnim.gameObject.SetActive(false);
                             boyAnim.gameObject.SetActive(true);
                             boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                             boyAnim.gameObject.transform.DOMoveY(boyAnim.gameObject.transform.position.y - 1.3f, 0f);
                             boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 0f);
                             DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                             {
                                 boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                                 boyAnim.gameObject.transform.DOMoveX(boyAnim.transform.position.x + 3f, 1.8f).OnComplete(() =>
                                 {
                                     netObject.gameObject.SetActive(false);
                                     boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                                     boyAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 360f, 0), 0f, RotateMode.FastBeyond360);
                                     DataController.Instance.indexLevel += 1;
                                     HideOptionUI();
                                     ChangeImgTwoTimeOptionUI();
                                     IntroStageThird();
                                 });
                             });
                         });
                     });

                 });
             });
         });
    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        monkeyAnim.gameObject.SetActive(true);
        monkeyAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            robotFisrtAnim.AnimationState.SetAnimation(0, "idle2", false);
            monkeyAnim.AnimationState.SetAnimation(0, "turn", false);
            monkeyAnim.gameObject.transform.DOMoveX(netObject.gameObject.transform.position.x, 1f);
            robotSecondAnim.AnimationState.SetAnimation(0, "shoot", false);
            DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                netObject.gameObject.SetActive(true);
                netObject.transform.DOMoveY(netObject.transform.position.y - 1.2f, 0.5f).OnComplete(() =>
                {
                    monkeyAnim.AnimationState.SetAnimation(0, "die", false);
                    DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        OnContinue();
                    });
                });

            });
        });
    }
    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        moleAnim.gameObject.SetActive(true);
        holeObject.SetActive(true);
        moleAnim.gameObject.transform.DOMoveY(moleAnim.gameObject.transform.position.y - 3, 2f);
        dirtyGroundFx.Play();
        DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelThird);
            eplosionFireFx.Play();
            wallObject.SetActive(false);
            Bg.SetActive(false);
            brokenBg.SetActive(true);
            brokenWallObject.SetActive(true);
            rocketObject.transform.DOMoveX(rocketObject.transform.position.x + 6f, 0.6f).OnComplete(() =>
            {
                rocketObject.SetActive(false);
                moleAnim.gameObject.transform.DOMoveY(moleAnim.gameObject.transform.position.y + 3f, 1.3f).OnComplete(() =>
                {
                    smokeBienThirdFx.Play();
                    boyAnim.gameObject.transform.DORotate(new Vector3(0, 360, 0), 0f);
                    boyAnim.gameObject.SetActive(true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                    moleAnim.gameObject.SetActive(false);
                    Camera.main.transform.DOMoveX(thunderDinoAnim.transform.position.x + 5, 3f);
                    boyAnim.AnimationState.SetAnimation(0, "0/jump", false);
                    boyAnim.gameObject.transform.DOMove(thunderDinoAnim.transform.position, 0.6f).SetEase(Ease.Linear).OnComplete(() =>
                     {
                         smokeBienFourthFx.Play();
                         boyAnim.gameObject.SetActive(false);
                         SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                         thunderDinoAnim.gameObject.SetActive(true);
                         thunderDinoAnim.AnimationState.SetAnimation(0, "idle", true);
                         thunderDinoAnim.gameObject.transform.DOMoveX(thunderDinoAnim.gameObject.transform.position.x + 5f, 1.5f).OnComplete(() =>
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
        SoundController.Instance.PlaySoundFx(AudioClipName.WallFall);
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);
        smokeBienThirdFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino1);
        boyAnim.gameObject.SetActive(false);
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);
        BeforeOnFail(NameThreeLevel.LevelThird);
        rocketObject.transform.DOMoveX(rocketObject.transform.position.x + 0.6f, 0.5f).OnComplete(() =>
        {
            rocketObject.SetActive(false);
            dinoAnim.AnimationState.SetAnimation(0, "die", false);
            HideOptionUI();
            OnContinue();
        });


    }

    private void IntroStageFirst()
    {
        Camera.main.transform.DOMove(new Vector3(0, 0, -10f), 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        Camera.main.transform.DOMoveX(boyStopPos.transform.position.x, 2f);
        doctorAnim.AnimationState.SetAnimation(0, "idlemachine", true);
        boyAnim.gameObject.transform.DOMoveX(boyStopPos.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                ShowOptionUI();
            });
    }
    private void IntroStageSecond()
    {
        Camera.main.transform.DOMove(new Vector3(10.3f, 0, -10f), 0f);
        boyAnim.gameObject.transform.DOMoveX(boyStopPos.transform.position.x, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        Camera.main.transform.DOMoveX(boyStopPos.transform.position.x + 2f, 2f);
        doctorAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Robot);
        robotFisrtAnim.AnimationState.SetAnimation(0, "walk", true);
        robotSecondAnim.AnimationState.SetAnimation(0, "walk", true);
        robotSquad.transform.DOMoveX(boyStopPos.transform.position.x + 1.8f, 2f).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                robotFisrtAnim.AnimationState.SetAnimation(0, "idle", true);
                robotSecondAnim.AnimationState.SetAnimation(0, "idle", true);
                ChangeImgOptionUI();
                ShowOptionUI();
                optionLeftBtn.onClick.AddListener(Option11);
                optionRightBtn.onClick.AddListener(Option22);
            });


    }

    private void IntroStageThird()
    {
        Camera.main.transform.DOMoveX(Camera.main.transform.position.x - 7f, 0f).SetEase(Ease.Linear);
        robotSquad.transform.DOMoveX(boyStopPos.transform.position.x + 1.8f, 0f);
        boyAnim.gameObject.transform.DOMoveX(smokeBienThirdFx.transform.position.x, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        boyAnim.gameObject.SetActive(true);
        boyAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 360f, 0), 0f, RotateMode.FastBeyond360);
        robotSecondAnim.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0f);
        robotSecondAnim.AnimationState.SetAnimation(0, "shoot", false);
        DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
            {
                rocketObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.WallFall);
                rocketObject.transform.DOMoveX(rocketObject.transform.position.x + 4f, 2f).OnComplete(() =>
                {
                    SoundController.Instance.PauseSoundFx(AudioClipName.WallFall);
                });
            });
        Camera.main.transform.DOMove(new Vector3(16.39f, 0, -10f), 3.6f).SetEase(Ease.Linear).OnComplete(() =>
        {
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option111);
            optionRightBtn.onClick.AddListener(Option222);
        });
    }
}

