using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using DG.Tweening;

public class Stage1 : StageOneLevel
{
    [SerializeField] private SkeletonAnimation boy;

    [SerializeField] private SkeletonAnimation mosquito;

    [SerializeField] private SkeletonAnimation mouse;

    [SerializeField] private ParticleSystem smokeBienFx, smokeMosquitoFx, electricFx;

    [SerializeField] private GameObject boyStop, electricPlug, electricBroke, lazerRay, mosquitoStop, mosquitoDie;

    [SerializeField] private Button optionLeft, optionRight;
    private void Start()
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
        boy.AnimationState.SetAnimation(0, "0/run", true);

        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);

        boy.gameObject.transform.DOMoveX(boyStop.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boy.AnimationState.SetAnimation(0, "0/afraid", true);
            ShowOptionUI();
        });
    }

    private void Option1()
    {
        optionLeft.onClick.RemoveAllListeners();

        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        boy.gameObject.SetActive(false);
        mouse.gameObject.SetActive(true);
        mouse.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            mouse.AnimationState.SetAnimation(0, "attack", true);
            DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
            {
                electricPlug.SetActive(false);
                electricBroke.SetActive(true);
                electricFx.gameObject.SetActive(true);
                electricFx.Play();

                BeforeOnPass();

                lazerRay.SetActive(false);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    smokeBienFx.Play();

                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

                    mouse.gameObject.SetActive(false);
                    boy.gameObject.SetActive(true);
                    boy.AnimationState.SetAnimation(0, "idle", true);

                    DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        boy.AnimationState.SetAnimation(0, "0/run", true);
                        boy.gameObject.transform.DOMoveX(4, 3f).OnComplete(() =>
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

        optionRight.onClick.RemoveAllListeners();

        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        boy.gameObject.SetActive(false);
        mosquito.gameObject.SetActive(true);
        mosquito.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Fly);

            mosquito.gameObject.transform.DOMove(new Vector3(mosquitoStop.transform.position.x, mosquito.transform.position.y, mosquito.transform.position.z), 2f).OnComplete(() =>
            {
                mosquito.AnimationState.SetAnimation(0, "die", true);
                smokeMosquitoFx.Play();
                BeforeOnFail();
                mosquito.gameObject.transform.DOMove(new Vector3(mosquitoDie.transform.position.x, mosquitoDie.transform.position.y, mosquito.transform.position.z), 0.5f).OnComplete(() =>
                {
                    DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        smokeMosquitoFx.gameObject.SetActive(true);
                    }).OnComplete(() =>
                    {
                        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                        {
                            OnFail();
                        });
                    });
                });


            });
        });
    }


}
