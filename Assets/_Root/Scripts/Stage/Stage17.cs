using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage17 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation airPlaneAnim, hippoAnim, tigerAnim, dinoAnim, eagleAnim, prangolinAnim, elephantAnim, geckoAnim, lionAnim, firstSecurityAnim, secondSecurityAnim, doctorAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx, firstExplosionFx, secondExplosionFx, thirdExplosionFx, electricFx, electricElephantFx;

    [SerializeField] private GameObject airPlaneStop, secondAirPlaneStop, thirdAirPlaneStop, fourthAirPlaneStop, doorObject, enemyObject, animalStopPos, rocketObject;

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
        Camera.main.transform.DOMove(new Vector3(0, 0, -10), 0);
        Camera.main.transform.DOMoveX(5.09f, 2f).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
            doorObject.transform.DOMoveY(doorObject.transform.position.y + 6.3f, 2.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                airPlaneAnim.gameObject.transform.DOMoveX(airPlaneStop.transform.position.x, 2.5f).OnComplete(() =>
                {
                    Camera.main.transform.DOMove(new Vector3(-5.83f, 17.6f, -10), 0f);
                    airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0f);
                    airPlaneAnim.gameObject.transform.DOMove(secondAirPlaneStop.transform.position, 0f).OnComplete(() =>
                    {
                        airPlaneAnim.gameObject.transform.DOMoveY(secondAirPlaneStop.transform.position.y - 5f, 2f).OnComplete(() =>
                        {
                            enemyObject.SetActive(true);
                            doctorAnim.AnimationState.SetAnimation(0, "fly2", true);

                            firstSecurityAnim.AnimationState.SetAnimation(0, "fly", true);
                            firstSecurityAnim.gameObject.transform.DOMoveY(doctorAnim.transform.position.y - 1.5f, 0.5f).OnComplete(() =>
                             {
                                 firstSecurityAnim.AnimationState.SetAnimation(0, "idle", true);

                             });
                            secondSecurityAnim.AnimationState.SetAnimation(0, "fly", true);
                            secondSecurityAnim.gameObject.transform.DOMoveY(doctorAnim.transform.position.y - 1.6f, 0.8f).OnComplete(() =>
                            {
                                secondSecurityAnim.AnimationState.SetAnimation(0, "idle", true);
                            });
                            doctorAnim.gameObject.transform.DOMoveY(doctorAnim.transform.position.y - 1.8f, 1f).OnComplete(() =>
                            {
                                doctorAnim.AnimationState.SetAnimation(0, "idlemachine", true);
                                DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
                                 {
                                     ShowOptionUI();
                                 });
                            });
                        });
                    });
                    eagleAnim.AnimationState.SetAnimation(0, "fly", true);
                    eagleAnim.gameObject.transform.DOMove(boyAnim.transform.position, 2.3f).OnComplete(() =>
                    {
                        smokeBienFirstFx.Play();
                        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                        eagleAnim.gameObject.SetActive(false);
                        boyAnim.gameObject.SetActive(true);
                        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                    });
                });
            });
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMove(new Vector3(-5.83f, 17.6f, -10), 0f);
        SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
        airPlaneAnim.gameObject.transform.DOMove(thirdAirPlaneStop.transform.position, 0f);
        airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            airPlaneAnim.AnimationState.SetAnimation(0, "anim2", true);
        });
        Camera.main.transform.DOMove(new Vector3(2.16f, 17.6f, -10), 6f).OnComplete(() =>
        {
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
        });
    }

    private void IntroStageThird()
    {
        Camera.main.transform.DOMove(new Vector3(2.16f, 17.6f, -10), 0f);
        SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 0f);
        airPlaneAnim.gameObject.transform.DOMove(fourthAirPlaneStop.transform.position, 0f);
        airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMoveX(smokeBienThirdFx.transform.position.x, 5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        });
        Camera.main.transform.DOMove(new Vector3(10.14f, 17.6f, -10), 6f).OnComplete(() =>
        {
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
        hippoAnim.AnimationState.SetAnimation(0, "walk", true);
        tigerAnim.AnimationState.SetAnimation(0, "run2", true);
        boyAnim.gameObject.SetActive(false);
        lionAnim.gameObject.SetActive(true);
        lionAnim.AnimationState.SetAnimation(0, "animation", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        SoundController.Instance.PlaySoundFx(AudioClipName.Lion);

        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
         {
             hippoAnim.gameObject.transform.DOMoveX(animalStopPos.transform.position.x, 7f).OnComplete(() =>
             {
                 hippoAnim.gameObject.SetActive(false);
             });
             tigerAnim.gameObject.transform.DOMoveX(animalStopPos.transform.position.x, 6f).OnComplete(() =>
             {
                 tigerAnim.gameObject.SetActive(false);
             });

             firstSecurityAnim.AnimationState.SetAnimation(0, "afraid", true);
             secondSecurityAnim.AnimationState.SetAnimation(0, "afraid", true);

             DOTween.Sequence().AppendInterval(1.2f).AppendCallback(() =>
             {
                 BeforeOnPass(NameThreeLevel.LevelFirst);

                 airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
                 firstSecurityAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
                 doctorAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0f);
                 secondSecurityAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
                 firstSecurityAnim.AnimationState.SetAnimation(0, "run afraid", true);
                 secondSecurityAnim.AnimationState.SetAnimation(0, "run afraid", true);
                 doctorAnim.AnimationState.SetAnimation(0, "runmachine", true);

                 doctorAnim.gameObject.transform.DOMoveX(animalStopPos.transform.position.x, 5f).OnComplete(() =>
                 {
                     doctorAnim.gameObject.SetActive(false);
                 });
                 firstSecurityAnim.gameObject.transform.DOMoveX(animalStopPos.transform.position.x, 4.7f).OnComplete(() =>
                 {
                     firstSecurityAnim.gameObject.SetActive(false);
                 });
                 secondSecurityAnim.gameObject.transform.DOMoveX(animalStopPos.transform.position.x, 2f).OnComplete(() =>
                 {
                     secondSecurityAnim.gameObject.SetActive(false);
                 });
                 airPlaneAnim.gameObject.transform.DOMove(thirdAirPlaneStop.transform.position, 2f).OnComplete(() =>
                 {
                     DOTween.Sequence().AppendInterval(1.3f).AppendCallback(() =>
                     {
                         airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0f);
                         smokeBienFirstFx.Play();
                         SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                         boyAnim.gameObject.SetActive(true);
                         boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                         lionAnim.gameObject.SetActive(false);
                         DataController.Instance.indexLevel += 1;
                         HideOptionUI();
                         ChangeImgOptionUI();
                         IntroStageSecond();
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
        geckoAnim.gameObject.SetActive(true);
        geckoAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
        {
            geckoAnim.AnimationState.SetAnimation(0, "fade out", true);
            doctorAnim.AnimationState.SetAnimation(0, "Catch", true);
            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelFirst);
                firstSecurityAnim.AnimationState.SetAnimation(0, "Electric", false);
                SoundController.Instance.PlaySoundFx(AudioClipName.Electric);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    smokeBienFirstFx.Play();
                    geckoAnim.gameObject.SetActive(false);
                    boyAnim.AnimationState.SetAnimation(0, "0/fall", true);
                    boyAnim.gameObject.SetActive(true);
                    electricFx.Play();
                    DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                    {
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

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino1);


        DOTween.Sequence().AppendInterval(1.2f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelSecond);
            dinoAnim.AnimationState.SetAnimation(0, "lash", true);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 30), 0f);
                DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                {
                    airPlaneAnim.gameObject.transform.DOMove(fourthAirPlaneStop.transform.position, 2f).OnComplete(() =>
                    {
                        airPlaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 180, 0), 0f);
                        airPlaneAnim.AnimationState.SetAnimation(0, "anim1", true);
                        smokeBienSecondFx.Play();
                        boyAnim.gameObject.SetActive(true);
                        dinoAnim.gameObject.SetActive(false);
                        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                        DataController.Instance.indexLevel += 1;
                        HideOptionUI();
                        ChangeImgTwoTimeOptionUI();
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

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        elephantAnim.gameObject.SetActive(true);
        elephantAnim.AnimationState.SetAnimation(0, "electric", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        DOTween.Sequence().AppendInterval(1.2f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelSecond);
            elephantAnim.AnimationState.SetAnimation(0, "die", true);
            electricElephantFx.Play();
            SoundController.Instance.PlaySoundFx(AudioClipName.Electric);
            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                HideOptionUI();
                OnContinue();
            });
        });
    }

    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        prangolinAnim.gameObject.SetActive(true);
        prangolinAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            prangolinAnim.AnimationState.SetAnimation(0, "attack", true);
            prangolinAnim.gameObject.transform.DOMoveX(prangolinAnim.transform.position.x + 8f, 4f).OnComplete(() =>
             {
                 HideOptionUI();
                 OnPass();
             });
            rocketObject.gameObject.SetActive(true);
            rocketObject.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 0.7f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnPass(NameThreeLevel.LevelSecond);
                rocketObject.gameObject.SetActive(false);
                firstExplosionFx.Play();
                secondExplosionFx.Play();
                thirdExplosionFx.Play();
            });
        });
    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        dinoAnim.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 0f);
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino1);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            rocketObject.gameObject.SetActive(true);
            rocketObject.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 1f).OnComplete(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                rocketObject.gameObject.SetActive(false);
                firstExplosionFx.Play();
                secondExplosionFx.Play();
                thirdExplosionFx.Play();
                dinoAnim.AnimationState.SetAnimation(0, "die", false);
            });
            DOTween.Sequence().AppendInterval(3.5f).AppendCallback(() =>
            {
                HideOptionUI();
                OnContinue();
            });
        });
    }
}
