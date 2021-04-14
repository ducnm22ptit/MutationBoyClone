using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using DG.Tweening;

public class Stage1 : StageOneLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation mosquitoAnim;

    [SerializeField] private SkeletonAnimation mouseAnim;

    [SerializeField] private SkeletonAnimation doctorFirstAnim;

    [SerializeField] private SkeletonAnimation doctorSecondAnim;

    [SerializeField] private ParticleSystem smokeBienFx, smokeMosquitoFx, earthQuake, electricFxFirst, electricFxSecond, electricFxFinal, exploreFx;

    [SerializeField] private GameObject boyStop, shadowBoyStop, shadowBoy, electricPlug, electricBroke, lazerRay, mosquitoStop, mosquitoDie, jumpPos;

    [SerializeField] private GameObject brokeMachine, normalMachine;

    [SerializeField] private Button optionLeft, optionRight;

    [SerializeField] private SpriteRenderer overlaySprite;

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
        // start intro Game
        Camera.main.transform.DOMoveX(-10.85f, 0);
        shadowBoy.transform.DOMoveY(shadowBoyStop.transform.position.y, 2.5f).OnComplete(() =>
        {

            overlaySprite.DOFade(1, 3f).OnComplete(() =>
            {
                Camera.main.transform.DOMoveX(-7.47f, 0);
                overlaySprite.DOFade(0, 3f);
                doctorFirstAnim.AnimationState.SetAnimation(0, "research", true);
                doctorSecondAnim.AnimationState.SetAnimation(0, "research", true);

                DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                {
                    Camera.main.transform.DOShakePosition(4, 1, 3, 1, false, true);
                    earthQuake.Play();
                    doctorFirstAnim.AnimationState.SetAnimation(0, "worry 1", false);
                    doctorSecondAnim.AnimationState.SetAnimation(0, "worry 1", false);
                    doctorFirstAnim.AnimationState.SetAnimation(0, "worry 2", true);
                    doctorSecondAnim.AnimationState.SetAnimation(0, "worry 2", true);

                    DOTween.Sequence().AppendInterval(2.5f).AppendCallback(() =>
                    {
                        overlaySprite.DOFade(1, 2.5f).OnComplete(() =>
                        {
                            Camera.main.transform.DOMoveX(-10.85f, 0);
                            overlaySprite.DOFade(0, 2.5f);
                            Camera.main.transform.DOShakePosition(4, 1, 3, 0.5f, false, true);
                            DOTween.Sequence().AppendInterval(1).AppendCallback(() =>
                            {
                                electricFxSecond.Play();
                                electricFxFirst.Play();
                            });
                            DOTween.Sequence().AppendInterval(2).AppendCallback(() =>
                            {
                                exploreFx.Play();
                                shadowBoy.SetActive(false);
                                normalMachine.SetActive(false);
                                brokeMachine.SetActive(true);
                                boyAnim.gameObject.SetActive(true);
                                boyAnim.AnimationState.SetAnimation(0, "0/jump", false);
                                boyAnim.gameObject.transform.DOMove(jumpPos.transform.position, 1f).OnComplete(() =>
                                {
                                    boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                                    DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                                    {
                                        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                                        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
                                        boyAnim.gameObject.transform.DOMoveX(boyStop.transform.position.x, 10f).SetEase(Ease.Linear).OnComplete(() =>
                                        {
                                            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                                            ShowOptionUI();
                                        });
                                        overlaySprite.DOFade(1, 2.5f).OnComplete(() =>
                                        {
                                            Camera.main.transform.DOMoveX(-7.47f, 0).OnComplete(() =>
                                            {
                                                overlaySprite.DOFade(0, 2.5f);
                                            });
                                            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                                            {
                                                overlaySprite.DOFade(1, 2.5f).OnComplete(() =>
                                                {
                                                    Camera.main.transform.DOMoveX(0, 0).OnComplete(() =>
                                                    {
                                                        overlaySprite.DOFade(0, 2.5f);
                                                    });
                                                });
                                            });
                                        });
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
        optionRight.onClick.RemoveAllListeners();
        optionLeft.onClick.RemoveAllListeners();

        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        boyAnim.gameObject.SetActive(false);
        mouseAnim.gameObject.SetActive(true);
        mouseAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            mouseAnim.AnimationState.SetAnimation(0, "attack", true);
            DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
            {
                electricPlug.SetActive(false);
                electricBroke.SetActive(true);
                electricFxFinal.gameObject.SetActive(true);
                electricFxFinal.Play();

                BeforeOnPass();

                lazerRay.SetActive(false);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    smokeBienFx.Play();

                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

                    mouseAnim.gameObject.SetActive(false);
                    boyAnim.gameObject.SetActive(true);
                    boyAnim.AnimationState.SetAnimation(0, "idle", true);

                    DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                        boyAnim.gameObject.transform.DOMoveX(4, 3f).OnComplete(() =>
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
        optionLeft.onClick.RemoveAllListeners();

        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        boyAnim.gameObject.SetActive(false);
        mosquitoAnim.gameObject.SetActive(true);
        mosquitoAnim.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Fly);

            mosquitoAnim.gameObject.transform.DOMove(new Vector3(mosquitoStop.transform.position.x, mosquitoAnim.transform.position.y, mosquitoAnim.transform.position.z), 2f).OnComplete(() =>
            {
                mosquitoAnim.AnimationState.SetAnimation(0, "die", true);
                smokeMosquitoFx.Play();
                BeforeOnFail();
                mosquitoAnim.gameObject.transform.DOMove(new Vector3(mosquitoDie.transform.position.x, mosquitoDie.transform.position.y, mosquitoAnim.transform.position.z), 0.5f).OnComplete(() =>
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
