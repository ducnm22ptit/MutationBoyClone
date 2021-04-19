using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage2 : StageOneLevel
{
    [SerializeField] private SkeletonAnimation boy, doctorFirst, doctorSecond, securityFirst, securitySecond, securityThird, geckoGreen, geckoBlue, rhino;

    [SerializeField] private ParticleSystem smokeBienFx, electricRhinoFx, electricBoyFx;

    [SerializeField] private GameObject boyStop, enemyStopPos, enemyStopPosSecond, enemyStopPosFinal, lockGate, openGate;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    void Start()
    {
        Camera.main.transform.DOMoveX(0, 0);

        optionLeftBtn.onClick.AddListener(Option1);

        optionRightBtn.onClick.AddListener(Option2);

        IntroStage();
    }

    protected override void OnPass()
    {
        base.OnPass();

    }

    protected override void OnFail()
    {
        base.OnFail();

    }

    protected override void BeforeOnPass()
    {
        base.BeforeOnPass();
    }

    protected override void BeforeOnFail()
    {
        base.BeforeOnFail();
    }

    private void IntroStage()
    {
        doctorFirst.AnimationState.SetAnimation(0, "worry 2", true);
        doctorSecond.AnimationState.SetAnimation(0, "worry 2", true);
        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
        {
            doctorFirst.AnimationState.SetAnimation(0, "idle", true);
            doctorSecond.AnimationState.SetAnimation(0, "idle", true);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                doctorFirst.AnimationState.SetAnimation(0, "shout", false);

                DOTween.Sequence().AppendInterval(1.6f).AppendCallback(() =>
                {
                    doctorFirst.AnimationState.SetAnimation(0, "idle", true);
                    doctorSecond.AnimationState.SetAnimation(0, "shout", true);

                    securityFirst.AnimationState.SetAnimation(0, "run", true);
                    securitySecond.AnimationState.SetAnimation(0, "run", true);
                    securityThird.AnimationState.SetAnimation(0, "run", true);

                    securityFirst.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x, 4f).SetEase(Ease.Linear);
                    securitySecond.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x, 5.7f).SetEase(Ease.Linear);
                    securityThird.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x, 5f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        doctorSecond.AnimationState.SetAnimation(0, "idle", true);
                        doctorFirst.AnimationState.SetAnimation(0, "walk", true);
                        doctorFirst.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x, 3.5f).OnComplete(() =>
                        {
                            Camera.main.transform.DOMoveX(7.9f, 0f).OnComplete(() =>
                            {
                                boy.AnimationState.SetAnimation(0, "0/afraid", true);
                                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                                {
                                    boy.gameObject.transform.DORotate(new Vector3(0, 0, 0), 0);
                                    boy.AnimationState.SetAnimation(0, "0/run", true);
                                    Camera.main.transform.DOMoveX(9.2f, 3f);
                                    SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
                                    boy.gameObject.transform.DOMoveX(boyStop.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
                                    {
                                        boy.AnimationState.SetAnimation(0, "0/afraid 2", true);
                                        ShowOptionUI();
                                    });
                                });
                            });
                        });

                    });

                });

            });

        });
    }

    private void Option1()
    {

        optionRightBtn.onClick.RemoveAllListeners();
        optionLeftBtn.onClick.RemoveAllListeners();

        smokeBienFx.Play();
        boy.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        geckoGreen.gameObject.SetActive(true);
        geckoGreen.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
        {
            geckoGreen.gameObject.SetActive(false);
            geckoBlue.gameObject.SetActive(true);
            geckoBlue.AnimationState.SetAnimation(0, "idle", true);

            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                geckoBlue.AnimationState.SetAnimation(0, "fade out", false);
                BeforeOnPass();
                DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                {

                    lockGate.SetActive(false);
                    openGate.SetActive(true);
                    HideOptionUI();
                    securityFirst.gameObject.transform.DOMoveX(enemyStopPosFinal.transform.position.x, 3f).SetEase(Ease.Linear);
                    securitySecond.gameObject.transform.DOMoveX(enemyStopPosFinal.transform.position.x, 4f).SetEase(Ease.Linear);
                    securityThird.gameObject.transform.DOMoveX(enemyStopPosFinal.transform.position.x, 5f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        smokeBienFx.Play();

                        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

                        geckoBlue.gameObject.SetActive(false);
                        boy.AnimationState.SetAnimation(0, "0/run 2", true);
                        boy.gameObject.SetActive(true);
                        boy.gameObject.transform.DOMoveX(enemyStopPosFinal.transform.position.x, 2f).OnComplete(() =>
                        {
                            OnPass();
                        });

                    });
                });

            });
        });
    }

    private void Option2()
    {

        optionRightBtn.onClick.RemoveAllListeners();
        optionLeftBtn.onClick.RemoveAllListeners();

        smokeBienFx.Play();
        boy.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        rhino.gameObject.SetActive(true);
        rhino.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1.3f).AppendCallback(() =>
        {
            rhino.AnimationState.SetAnimation(0, "attack", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Rhino);
            Camera.main.transform.DOShakePosition(2, 1, 10, 90, false, true).OnComplete(() =>
            {

                rhino.AnimationState.SetAnimation(0, "die", true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Electric);
                electricRhinoFx.gameObject.SetActive(true);
                electricRhinoFx.Play();

                BeforeOnFail();

                DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                {
                    HideOptionUI();

                    rhino.gameObject.SetActive(false);
                    electricRhinoFx.gameObject.SetActive(false);
                    boy.AnimationState.SetAnimation(0, "0/fall", true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Electric);
                    boy.gameObject.SetActive(true);
                    electricBoyFx.gameObject.SetActive(true);
                    electricBoyFx.Play();

                    securityFirst.gameObject.transform.DOMoveX(enemyStopPosSecond.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        securityFirst.AnimationState.SetAnimation(0, "idle", true);
                    });
                    securitySecond.gameObject.transform.DOMoveX(enemyStopPosSecond.transform.position.x, 4f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        securitySecond.AnimationState.SetAnimation(0, "idle", true);
                    });
                    securityThird.gameObject.transform.DOMoveX(enemyStopPosSecond.transform.position.x, 5f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        securityThird.AnimationState.SetAnimation(0, "idle", true);
                    });
                    doctorFirst.gameObject.transform.DOMoveX(enemyStopPosSecond.transform.position.x, 4.3f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        doctorFirst.AnimationState.SetAnimation(0, "idle", true);
                    });
                    DOTween.Sequence().AppendInterval(4f).AppendCallback(() =>
                    {
                        OnFail();
                    });
                });


            });
        });




    }

}
