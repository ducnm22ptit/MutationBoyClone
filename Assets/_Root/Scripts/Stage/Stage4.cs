using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage4 : StageOneLevel
{
    [SerializeField] private SkeletonAnimation boyAnim, mouseAnim, mosquitoAnim, robotAnim;

    [SerializeField] private ParticleSystem smokeBienFx;

    [SerializeField] private GameObject boyStop, wall, doorCover;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;


    void Start()
    {
        Camera.main.transform.DOMoveX(0, 0);

        optionLeftBtn.onClick.AddListener(Option1);

        optionRightBtn.onClick.AddListener(Option2);

        IntroStage();
    }

    private void IntroStage()
    {
        doorCover.transform.DOMoveX(doorCover.transform.position.x + 1.1f, 1f).OnComplete(() =>
        {
            boyAnim.gameObject.transform.DOMoveY(boyStop.transform.position.y, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "0/jump", false);
                boyAnim.gameObject.transform.DOMoveX(boyStop.transform.position.x, 1f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
                    Camera.main.transform.DOMoveX(-5.21f, 2f);
                    boyAnim.gameObject.transform.DOMoveX(boyStop.transform.position.x - 1.5f, 2f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                        robotAnim.AnimationState.SetAnimation(0, "idle", true);
                        ShowOptionUI();
                    });
                });
            });
        });





    }

    private void Option1()
    {

        optionRightBtn.onClick.RemoveAllListeners();
        optionLeftBtn.onClick.RemoveAllListeners();

        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();
        boyAnim.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        mosquitoAnim.gameObject.SetActive(true);
        mosquitoAnim.AnimationState.SetAnimation(0, "fly", true);

        SoundController.Instance.PlaySoundFx(AudioClipName.Fly);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() => {

            mosquitoAnim.gameObject.transform.DOMoveX(mosquitoAnim.gameObject.transform.position.x - 5f, 2f);
            robotAnim.AnimationState.SetAnimation(0,"idle2", false);
            BeforeOnPass();
            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                HideOptionUI();
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    OnPass();
                });
            });
            
        });
       

    }

    private void Option2()
    {

        optionRightBtn.onClick.RemoveAllListeners();
        optionLeftBtn.onClick.RemoveAllListeners();

        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();
        boyAnim.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        mouseAnim.gameObject.SetActive(true);
        mouseAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            robotAnim.AnimationState.SetAnimation(0, "walk", true);
            robotAnim.gameObject.transform.DOMoveX(robotAnim.gameObject.transform.position.x + 2f, 1.5f).OnComplete(() =>
            {

                robotAnim.AnimationState.SetAnimation(0, "attack", false);
                BeforeOnFail();
                DOTween.Sequence().AppendInterval(4f).AppendCallback(() =>
                {

                });
                DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                {
                    mouseAnim.gameObject.transform.DOMoveY(mouseAnim.transform.position.y + 0.94f, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        mouseAnim.AnimationState.SetAnimation(0, "die", true);
                    });
                    HideOptionUI();
                });
                DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                {
                    OnFail();
                });
            });
        });
    }

}
