using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage18 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation spiderAnim, birdAnim, monkeyAnim, eagleAnim, thunderDinoAnim, firstAirplaneAnim, secondAirplaneAnim, birdOneAim, birdTwoAnim, birdThreeAnim, birdFourAnim, birdFiveAnim, birdSixAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx;

    [SerializeField] private GameObject boyStopPos, firstRay, secondRay, firstAirplaneRay, secondAirplaneRay, birdStopPos, airplanesObject, airplaneStopPos, airplaneFirstStopPos, airplaneSecondStopPos, thunderStopPos, monkeyDiePos, backGround, stopBirdOne, stopBirdTwo, stopBirdThree;

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
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMoveX(boyStopPos.transform.position.x, 2f).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            ShowOptionUI();
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMoveY(10.71f, 0f);
        SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
        boyAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        boyAnim.gameObject.transform.DOMove(monkeyAnim.transform.position, 0f).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
            firstAirplaneAnim.AnimationState.SetAnimation(0, "anim1", true);
            secondAirplaneAnim.AnimationState.SetAnimation(0, "anim1", true);
            airplanesObject.gameObject.transform.DOMove(airplaneStopPos.transform.position, 3f).OnComplete(() =>
            {
                ShowOptionUI();
                optionLeftBtn.onClick.AddListener(Option11);
                optionRightBtn.onClick.AddListener(Option22);
            });
        });
    }

    private void IntroStageThird()
    {
        Camera.main.gameObject.transform.DOMove(new Vector3(-12.06f, 12.71f, -10), 0f);
        backGround.GetComponent<BackgroundRepeaterStage>().enabled = true;
        SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
        firstAirplaneAnim.AnimationState.SetAnimation(0, "anim1", true);
        secondAirplaneAnim.AnimationState.SetAnimation(0, "anim1", true);
        thunderDinoAnim.gameObject.transform.DOMove(thunderStopPos.transform.position, 0f).SetEase(Ease.Linear).OnComplete(() =>
         {
             thunderDinoAnim.gameObject.SetActive(true);
             thunderDinoAnim.AnimationState.SetAnimation(0, "idle", true);
             firstAirplaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
             secondAirplaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
             firstAirplaneAnim.gameObject.transform.DOMove(airplaneFirstStopPos.transform.position, 0f).SetEase(Ease.Linear);
             secondAirplaneAnim.gameObject.transform.DOMove(airplaneSecondStopPos.transform.position, 0f).SetEase(Ease.Linear);
             SoundController.Instance.PlaySoundFx(AudioClipName.Dino0);
             ShowOptionUI();
             optionLeftBtn.onClick.AddListener(Option111);
             optionRightBtn.onClick.AddListener(Option222);
         });
    }
    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.gameObject.transform.DOMove(spiderAnim.transform.position, 0f);
        smokeBienFirstFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        spiderAnim.gameObject.SetActive(true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            spiderAnim.AnimationState.SetAnimation(0, "creep", true);
            Camera.main.transform.DOMoveY(10.71f, 4f);
            spiderAnim.gameObject.transform.DOMoveY(monkeyAnim.transform.position.y - 0.6f, 4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                spiderAnim.gameObject.SetActive(false);
                SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                smokeBienSecondFx.Play();
                DataController.Instance.indexLevel += 1;
                HideOptionUI();
                ChangeImgOptionUI();
                IntroStageSecond();
            });
            DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
            {
                firstRay.gameObject.SetActive(true);
                secondRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            });
        });
    }

    private void Option2()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.gameObject.transform.DOMove(birdAnim.transform.position, 0f);
        smokeBienFirstFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        birdAnim.gameObject.SetActive(true);
        birdAnim.AnimationState.SetAnimation(0, "fly", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {

            Camera.main.transform.DOMoveY(4f, 2f);
            birdAnim.gameObject.transform.DOMoveY(birdStopPos.transform.position.y, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                birdAnim.AnimationState.SetAnimation(0, "die", true);
                birdAnim.gameObject.transform.DOMoveY(boyAnim.transform.position.y, 1f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    HideOptionUI();
                    OnFail();
                });
            });
            DOTween.Sequence().AppendInterval(1.8f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelFirst);
                firstRay.gameObject.SetActive(true);
                secondRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            });
        });
    }

    private void Option11()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienSecondFx.gameObject.transform.DOMove(thunderDinoAnim.transform.position, 0f);
        smokeBienSecondFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        thunderDinoAnim.gameObject.SetActive(true);
        thunderDinoAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Airplane);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino0);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelSecond);
            Camera.main.gameObject.transform.DOMove(new Vector3(-12.06f, 12.71f, -10), 3f).OnComplete(() =>
            {
                HideOptionUI();
                ChangeImgTwoTimeOptionUI();
            });
            thunderDinoAnim.gameObject.transform.DOMove(thunderStopPos.transform.position, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                firstAirplaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
                secondAirplaneAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
                firstAirplaneAnim.gameObject.transform.DOMove(airplaneFirstStopPos.transform.position, 2f).SetEase(Ease.Linear);
                secondAirplaneAnim.gameObject.transform.DOMove(airplaneSecondStopPos.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    DataController.Instance.indexLevel += 1;
                    IntroStageThird();
                });
            });
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                backGround.GetComponent<BackgroundRepeaterStage>().enabled = true;
            });

        });
    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienSecondFx.gameObject.transform.DOMove(monkeyAnim.transform.position, 0f);
        smokeBienSecondFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        monkeyAnim.gameObject.SetActive(true);
        monkeyAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            monkeyAnim.gameObject.transform.DOMove(monkeyDiePos.transform.position, 0.8f).SetEase(Ease.Linear).OnComplete(() =>
            {
                monkeyAnim.gameObject.transform.DOMove(birdStopPos.transform.position, 0.6f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    HideOptionUI();
                    OnContinue();
                });
            });

            monkeyAnim.AnimationState.SetAnimation(0, "step 1", false);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                monkeyAnim.AnimationState.SetAnimation(0, "step 2", false);
                DOTween.Sequence().AppendInterval(0.1f).AppendCallback(() =>
                {

                    monkeyAnim.AnimationState.SetAnimation(0, "dieblack", false);
                    DOTween.Sequence().AppendInterval(0.1f).AppendCallback(() =>
                    {
                        monkeyAnim.AnimationState.SetAnimation(0, "dieblack2", false);
                    });
                });
            });

            DOTween.Sequence().AppendInterval(0.4f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                firstAirplaneRay.gameObject.SetActive(true);
                secondAirplaneRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            });
        });
    }

    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienThirdFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        thunderDinoAnim.gameObject.SetActive(false);
        birdAnim.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 0f);
        birdAnim.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0f);
        birdAnim.gameObject.SetActive(true);
        birdAnim.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
         {
             BeforeOnPass(NameThreeLevel.LevelThird);
             SoundController.Instance.StopSoundFx();
             airplanesObject.gameObject.transform.DOMoveX(airplanesObject.transform.position.x - 12, 3f).OnComplete(() =>
             {
                 HideOptionUI();
                 OnPass();
             });
         });
    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienThirdFx.gameObject.transform.DOMove(eagleAnim.transform.position, 0f);
        smokeBienThirdFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        thunderDinoAnim.gameObject.SetActive(false);
        eagleAnim.gameObject.SetActive(true);
        eagleAnim.AnimationState.SetAnimation(0, "fly", true);
        birdOneAim.gameObject.transform.DOMove(stopBirdOne.transform.position, 1.5f);
        birdTwoAnim.gameObject.transform.DOMove(stopBirdTwo.transform.position, 1.5f);
        birdThreeAnim.gameObject.transform.DOMove(stopBirdTwo.transform.position, 1.5f);
        birdFourAnim.gameObject.transform.DOMove(stopBirdThree.transform.position, 1.5f);
        birdFiveAnim.gameObject.transform.DOMove(stopBirdThree.transform.position, 1.5f);
        birdSixAnim.gameObject.transform.DOMove(stopBirdThree.transform.position, 1f).OnComplete(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelThird);
            secondAirplaneRay.gameObject.SetActive(true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
           {
               eagleAnim.AnimationState.SetAnimation(0, "die", true);
               eagleAnim.gameObject.transform.DOMoveY(eagleAnim.transform.position.y - 8f, 1.5f);
           });
            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                HideOptionUI();
                OnContinue();
            });
        });
    }
}
