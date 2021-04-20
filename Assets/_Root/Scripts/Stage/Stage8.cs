using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage8 : StageTwoLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation elephantAnim, elephantSecondAnim;

    [SerializeField] private SkeletonAnimation spiderAnim, spiderSecondAnim;

    [SerializeField] private SkeletonAnimation eagleAnim;

    [SerializeField] private SkeletonAnimation fanAnim, fanOffAnim;
    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, windFx, fanWindFx;

    [SerializeField] private GameObject boyStopPos, boyStopPosSecond, boyStopPosThird, eagleStopPos, elephantStopPos, backGroundSecond, backGroundFisrt, spiderWeb;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    void Start()
    {
        if (DataController.Instance.indexLevel == 0)
        {
            optionLeftBtn.onClick.AddListener(Option1);
            optionRightBtn.onClick.AddListener(Option2);
            IntroStageFirst();
        }
        else if (DataController.Instance.indexLevel == 1)
        {
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
            ChangeImgOptionUI();
            BeforeOnPass(NameLevel.LevelFirst);
            IntroStageSecond();
        }
    }

    private void Option1()
    {
        optionRightBtn.onClick.RemoveListener(Option1);
        optionLeftBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        elephantAnim.gameObject.SetActive(true);
        elephantAnim.AnimationState.SetAnimation(0, "jam", true);
        backGroundSecond.SetActive(true);
        Camera.main.transform.DOMoveY(boyStopPosSecond.transform.position.y, 4f);
        elephantAnim.gameObject.transform.DOMove(elephantStopPos.transform.position, 3f).OnComplete(() =>
        {
            BeforeOnPass(NameLevel.LevelFirst);
            DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
            {
                boyAnim.gameObject.transform.DOMove(boyStopPosSecond.transform.position, 0f);
                boyAnim.gameObject.transform.DORotate(new Vector3(0, 360, 0), 0f);
                boyAnim.gameObject.SetActive(true);
                smokeBienFirstFx.Play();
                elephantAnim.gameObject.SetActive(false);
                HideOptionUI();
                boyAnim.AnimationState.SetAnimation(0, "fall2", true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                Camera.main.transform.DOMove(new Vector3(4.58f, -10.53f, -10), 1.8f);
                backGroundSecond.SetActive(false);
                boyAnim.gameObject.transform.DOMove(boyStopPosThird.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    DataController.Instance.indexLevel += 1;
                    IntroStageSecond();
                });
            });
        });

    }

    private void Option2()
    {
        optionRightBtn.onClick.RemoveListener(Option1);
        optionLeftBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        eagleAnim.gameObject.SetActive(true);
        eagleAnim.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
        {
            eagleAnim.gameObject.transform.DOMove(eagleStopPos.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                windFx.Play();
                SoundController.Instance.PlaySoundFx(AudioClipName.Wind);
                eagleAnim.AnimationState.SetAnimation(0, "quat", true);
                BeforeOnFail(NameLevel.LevelFirst);
                eagleAnim.gameObject.transform.DOMoveX(eagleStopPos.gameObject.transform.position.x - 3, 3f).OnComplete(() =>
                {
                    HideOptionUI();
                    OnFail();
                });
            });
        });

    }

    private void Option11()
    {
        optionRightBtn.onClick.RemoveListener(Option11);
        optionLeftBtn.onClick.RemoveListener(Option22);

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        spiderAnim.gameObject.SetActive(true);
        spiderAnim.AnimationState.SetAnimation(0, "attack", false);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            spiderWeb.SetActive(true);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                spiderAnim.gameObject.SetActive(false);
                spiderSecondAnim.gameObject.SetActive(true);
                BeforeOnPass(NameLevel.LevelTwo);
                DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                {
                    fanWindFx.Pause();
                    fanAnim.gameObject.SetActive(false);
                    fanOffAnim.gameObject.SetActive(true);
                    spiderSecondAnim.gameObject.SetActive(false);
                    smokeBienSecondFx.Play();
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                    boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
                    boyAnim.gameObject.SetActive(true);
                    boyAnim.gameObject.transform.DOMoveX(boyStopPosThird.transform.position.x + 12f, 3f).OnComplete(() =>
                    {
                        HideOptionUI();
                        OnPass();
                    });
                });
            });
        });
    }

    private void Option22()
    {
        optionRightBtn.onClick.RemoveListener(Option11);
        optionLeftBtn.onClick.RemoveListener(Option22);

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        elephantSecondAnim.gameObject.SetActive(true);
        elephantSecondAnim.AnimationState.SetAnimation(0, "jam", true);
        backGroundSecond.SetActive(true);
        BeforeOnFail(NameLevel.LevelTwo);
        DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
           {
               HideOptionUI();
               OnContinue();
           });
    }

    private void IntroStageFirst()
    {
        Camera.main.transform.DOMove(new Vector3(0, 0, -10f), 0f);

        boyAnim.AnimationState.SetAnimation(0, "creep", true);
        boyAnim.gameObject.transform.DOMoveX(boyAnim.gameObject.transform.position.x - 2.5f, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            boyAnim.AnimationState.SetAnimation(0, "fall2", true);
            boyAnim.gameObject.transform.DOMove(boyStopPos.transform.position, 1f).OnComplete(() =>
            {
                ShowOptionUI();
            });
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMove(new Vector3(4.58f, -10.53f, -10), 0);
        backGroundSecond.SetActive(false);
        backGroundFisrt.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Wind);
        boyAnim.gameObject.transform.DORotate(new Vector3(0, 360, 0), 0f);
        boyAnim.gameObject.transform.DOMove(boyStopPosThird.transform.position, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        Camera.main.transform.DOMoveX(boyStopPosThird.transform.position.x + 8.7f, 2f);
        boyAnim.gameObject.transform.DOMoveX(boyStopPosThird.transform.position.x + 7.5f, 4.7f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "fly", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
            ChangeImgOptionUI();
            ShowOptionUI();
        });
    }
}
