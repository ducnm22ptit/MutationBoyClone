using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage20 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation securityFatAnim, securityThinAnim, pangolinAnim, monkeyAnim, bearAnim, snakeAnim, doctorAnim, dinoAnim, dragonAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, dieSmokeFx, fireDragonFx;

    [SerializeField] private GameObject diePangolinStop, firstRay, secondRay, securityStop, netObject, netStop, netSecondStop;

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
        Camera.main.gameObject.transform.DOMoveX(-5.11f, 2f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMove(smokeBienFirstFx.transform.position, 2f).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            ShowOptionUI();
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.gameObject.transform.DOMove(new Vector3(-19.32f, 0, -10), 0f);
        Camera.main.gameObject.transform.DOMove(new Vector3(-16f, 0, -10), 2f);
        securityFatAnim.AnimationState.SetAnimation(0, "run", true);
        securityThinAnim.AnimationState.SetAnimation(0, "run", true);
        securityFatAnim.gameObject.transform.DOMoveX(securityStop.transform.position.x, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            securityFatAnim.AnimationState.SetAnimation(0, "idle", true);
        });
        securityThinAnim.gameObject.transform.DOMoveX(securityStop.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            securityThinAnim.AnimationState.SetAnimation(0, "idle", true);
        });
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x + 2f, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.transform.position.x, 1.5f).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
        });
    }

    private void IntroStageThird()
    {
        Camera.main.gameObject.transform.DOMove(new Vector3(-41.77f, 0, -10), 0f);
        Camera.main.gameObject.transform.DOMove(new Vector3(-45.1f, 0, -10), 3f);
        securityFatAnim.gameObject.transform.DOMoveX(doctorAnim.transform.position.x + 1, 0f);
        securityFatAnim.AnimationState.SetAnimation(0, "idle", true);
        doctorAnim.AnimationState.SetAnimation(0, "idlemachine", true);

        boyAnim.gameObject.transform.DOMoveX(smokeBienThirdFx.transform.position.x, 0f).OnComplete(() =>
        {
            smokeBienThirdFx.Play();
            SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        });
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMoveX(smokeBienFourthFx.transform.position.x, 2f).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
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
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        monkeyAnim.gameObject.SetActive(true);
        monkeyAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            monkeyAnim.AnimationState.SetAnimation(0, "turn", true);
            DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
            {
                firstRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            });
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                secondRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            });
            monkeyAnim.gameObject.transform.DOMoveX(dieSmokeFx.gameObject.transform.position.x - 1.7f, 1.6f).SetEase(Ease.Linear).OnComplete(() =>
            {
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    DataController.Instance.indexLevel += 1;
                    HideOptionUI();
                    ChangeImgOptionUI();
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
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        pangolinAnim.gameObject.SetActive(true);

        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelFirst);
            pangolinAnim.AnimationState.SetAnimation(0, "attack", true);
            DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
            {
                firstRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            });
            pangolinAnim.gameObject.transform.DOMoveX(dieSmokeFx.gameObject.transform.position.x, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                secondRay.gameObject.SetActive(true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
                dieSmokeFx.Play();
                pangolinAnim.AnimationState.SetAnimation(0, "die2", true);
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
        boyAnim.gameObject.SetActive(false);
        snakeAnim.gameObject.SetActive(true);
        BeforeOnPass(NameThreeLevel.LevelSecond);

        DOTween.Sequence().AppendInterval(1).AppendCallback(() =>
        {
            snakeAnim.gameObject.transform.DOMoveX(snakeAnim.transform.position.x - 7, 2f);
            DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
            {
                HideOptionUI();
                ChangeImgTwoTimeOptionUI();
                IntroStageThird();
            });
        });
    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienSecondFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        bearAnim.gameObject.SetActive(true);
        bearAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            securityFatAnim.AnimationState.SetAnimation(0, "net", false);
            DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                netObject.SetActive(true);
                bearAnim.AnimationState.SetAnimation(0, "die", false);
                netObject.transform.DOMove(netStop.transform.position, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
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

        smokeBienFourthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        dragonAnim.gameObject.SetActive(true);
        dragonAnim.AnimationState.SetAnimation(0, "fire2", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dragon);

        DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
        {
            fireDragonFx.Play();
            doctorAnim.AnimationState.SetAnimation(0, "die fire", false);
            securityFatAnim.AnimationState.SetAnimation(0, "die", false);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                dragonAnim.AnimationState.SetAnimation(0, "idle", true);
                fireDragonFx.Stop();
                HideOptionUI();
                OnPass();
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
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "die2", false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino1);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            netObject.transform.DOMove(securityFatAnim.transform.position, 0f);
            securityFatAnim.AnimationState.SetAnimation(0, "net", false);
            DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                netObject.SetActive(true);
                netObject.transform.DOLocalRotate(new Vector3(0, 0, 30f), 0f);
                netObject.transform.DOMove(netSecondStop.transform.position, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
                {
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
