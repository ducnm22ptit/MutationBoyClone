using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage19 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation rihAnim, robotAnim, birdAnim, cockRoachAnim, mouseAnim, airplaneAnim, securityFatAnim, securityThinAnim, tigerAnim, locustAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx;

    [SerializeField] private GameObject birdStopPos, firstAirplaneStopPos, secondAirplaneStopPos, dieAirplane, fatSecurityStop, netObject, netStop;

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
        Camera.main.gameObject.transform.DOMove(new Vector3(0, 0, -10), 0f);

        birdAnim.gameObject.transform.DOMove(smokeBienFirstFx.transform.position, 2f).OnComplete(() =>
        {
            smokeBienFirstFx.gameObject.transform.DOMove(boyAnim.transform.position, 0f);
            smokeBienFirstFx.Play();
            SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
            boyAnim.gameObject.SetActive(true);
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            birdAnim.gameObject.SetActive(false);
            ShowOptionUI();
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMove(new Vector3(-20.84f, 0, -10), 0f);
        Camera.main.transform.DOMoveX(-13.9f, 5f);
        securityFatAnim.AnimationState.SetAnimation(0, "run", true);
        securityThinAnim.AnimationState.SetAnimation(0, "run", true);
        securityFatAnim.gameObject.transform.DOMoveX(fatSecurityStop.transform.position.x, 2.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            securityFatAnim.AnimationState.SetAnimation(0, "idle", true);
            securityThinAnim.gameObject.transform.DOMoveX(securityThinAnim.transform.position.x - 2.6f, 1f).SetEase(Ease.Linear).OnComplete(() =>
             {
                 securityThinAnim.AnimationState.SetAnimation(0, "idle", true);
                 ShowOptionUI();
                 optionLeftBtn.onClick.AddListener(Option11);
                 optionRightBtn.onClick.AddListener(Option22);
             });
        });
    }

    private void IntroStageThird()
    {
        Camera.main.transform.DOMoveX(-29.69f, 0f);
        smokeBienThirdFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        locustAnim.gameObject.SetActive(false);
        boyAnim.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMove(smokeBienFourthFx.transform.position, 2f).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Door);
            robotAnim.AnimationState.SetAnimation(0, "walk", true);
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            robotAnim.gameObject.transform.DOMoveX(robotAnim.transform.position.x + 3, 2f).OnComplete(() =>
             {
                 robotAnim.AnimationState.SetAnimation(0, "idle", true);
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
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        cockRoachAnim.gameObject.SetActive(true);
        cockRoachAnim.AnimationState.SetAnimation(0, "run", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            cockRoachAnim.gameObject.transform.DOMoveX(cockRoachAnim.gameObject.transform.position.x - 2f, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                cockRoachAnim.gameObject.SetActive(false);
                airplaneAnim.AnimationState.SetAnimation(0, "anim1", true);
                airplaneAnim.gameObject.transform.DOMove(firstAirplaneStopPos.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    airplaneAnim.AnimationState.SetAnimation(0, "anim2", true);
                    DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                    {
                        dieAirplane.gameObject.transform.DOMove(secondAirplaneStopPos.transform.position, 2f);
                        dieAirplane.transform.GetChild(0).gameObject.SetActive(false);
                        airplaneAnim.gameObject.transform.DOMove(secondAirplaneStopPos.transform.position, 2f).OnComplete(() =>
                        {
                            DataController.Instance.indexLevel += 1;
                            HideOptionUI();
                            ChangeImgOptionUI();
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
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        mouseAnim.gameObject.SetActive(true);
        mouseAnim.AnimationState.SetAnimation(0, "walk", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelFirst);
            mouseAnim.gameObject.transform.DOMoveX(cockRoachAnim.gameObject.transform.position.x - 2f, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                mouseAnim.AnimationState.SetAnimation(0, "choke", false);
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
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        locustAnim.gameObject.SetActive(true);
        locustAnim.AnimationState.SetAnimation(0, "animation", true);

        DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelSecond);
            locustAnim.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 4f).OnComplete(() =>
            {
                Camera.main.transform.DOMoveX(-29.69f, 3f).OnComplete(() =>
                {
                    DataController.Instance.indexLevel += 1;
                    HideOptionUI();
                    ChangeImgTwoTimeOptionUI();
                    IntroStageThird();
                });
            });
        });

    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienSecondFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        tigerAnim.gameObject.SetActive(true);
        tigerAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
        {
            tigerAnim.AnimationState.SetAnimation(0, "attack", false);
            DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                SoundController.Instance.PlaySoundFx(AudioClipName.Electric);
                securityFatAnim.AnimationState.SetAnimation(0, "electric", false);
                securityThinAnim.AnimationState.SetAnimation(0, "Electric", false);
                tigerAnim.AnimationState.SetAnimation(0, "die", false);
                DOTween.Sequence().AppendInterval(1).AppendCallback(() =>
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

        smokeBienFourthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        mouseAnim.gameObject.transform.DOMove(smokeBienFourthFx.transform.position, 0f);
        mouseAnim.gameObject.SetActive(true);
        mouseAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            mouseAnim.AnimationState.SetAnimation(0, "jump", false);
            mouseAnim.gameObject.transform.DOMove(robotAnim.transform.position, 0.7f).SetEase(Ease.Linear).OnComplete(() =>
            {
                mouseAnim.gameObject.SetActive(false);
                robotAnim.AnimationState.SetAnimation(0, "sudden", false);
                DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
                {
                    robotAnim.AnimationState.SetAnimation(0, "die", false);
                });
                DOTween.Sequence().AppendInterval(2.5f).AppendCallback(() =>
                {
                    smokeBienFourthFx.gameObject.transform.DOMove(mouseAnim.transform.position, 0f);
                    smokeBienFourthFx.Play();
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                    boyAnim.gameObject.transform.DOMove(robotAnim.transform.position, 0f);
                    boyAnim.gameObject.SetActive(true);
                    boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                    boyAnim.gameObject.transform.DOMoveX(robotAnim.transform.position.x - 1f, 1f).SetEase(Ease.Linear).OnComplete(() =>
                     {
                         HideOptionUI();
                         OnPass();
                     });
                });
            });
        });
    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFourthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        rihAnim.gameObject.SetActive(true);
        rihAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            robotAnim.AnimationState.SetAnimation(0, "shoot", false);
            DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                netObject.SetActive(true);
                rihAnim.AnimationState.SetAnimation(0, "die2", false);
                netObject.transform.DOMove(netStop.transform.position, 0.6f).OnComplete(() =>
                {
                    robotAnim.AnimationState.SetAnimation(0, "idle", false);
                    DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        OnContinue();
                    });
                });

            });
        });
    }
}
