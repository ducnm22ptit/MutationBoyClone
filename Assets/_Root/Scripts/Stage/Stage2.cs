using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage2 : StageOneLevel
{
    [SerializeField] private SkeletonAnimation boy, doctorFirst, doctorSecond, securityFirst, securitySecond, securityThird, geckoGreen, geckoBlue;

    [SerializeField] private ParticleSystem smokeBienFx/*, smokeMosquitoFx, electricFx*/;

    [SerializeField] private GameObject boyStop, enemyStopPos;

    [SerializeField] private Button optionLeft, optionRight;

    void Start()
    {
        optionLeft.onClick.AddListener(Option1);

        optionRight.onClick.AddListener(Option2);

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
                doctorFirst.AnimationState.SetAnimation(0, "shout", true);
                doctorFirst.AnimationState.SetAnimation(0, "idle", true);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
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
                            Camera.main.transform.DOMoveX(7.8f, 0f).OnComplete(() =>
                            {
                                boy.AnimationState.SetAnimation(0, "0/afraid", true);
                                DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                                {
                                    boy.gameObject.transform.DORotate(new Vector3(0, 0, 0), 0);
                                    boy.AnimationState.SetAnimation(0, "0/run", true);
                                    Camera.main.transform.DOMoveX(9.1f, 3f);
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
        optionLeft.onClick.RemoveAllListeners();

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
                geckoBlue.AnimationState.SetAnimation(0, "fade out", true);
            });
        });
    }

    private void Option2()
    {
        optionRight.onClick.RemoveAllListeners();


    }

}
