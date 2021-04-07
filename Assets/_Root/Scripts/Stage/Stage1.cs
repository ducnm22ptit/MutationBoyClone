using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using DG.Tweening;

public class Stage1 : BaseStage
{
    [SerializeField] private SkeletonAnimation boy;

    [SerializeField] private SkeletonAnimation mosquito;

    [SerializeField] private SkeletonAnimation mouse;

    [SerializeField] private ParticleSystem smokeBienFx, smokeMosquitoFx, electricFx;

    [SerializeField] private GameObject boyStop, OptionUI, electricPlug, electricBroke, lazerRay, mosquitoStop, mosquitoDie;

    [SerializeField] private Button optionLeft, optionRight;

    private void Start()
    {
        optionLeft.onClick.AddListener(Option1);

        optionRight.onClick.AddListener(Option2);

        MoveBoy();
    }

    private void MoveBoy()
    {
        boy.AnimationState.SetAnimation(0, "0/run", true);
        boy.gameObject.transform.DOMove(new Vector3(boyStop.transform.position.x, boyStop.transform.position.y, boyStop.transform.position.z), 2f).OnComplete(() =>
        {
            boy.AnimationState.SetAnimation(0, "0/afraid", true);
            OptionUI.SetActive(true);

        });
    }

    private void Option1()
    {
        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();
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
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    lazerRay.SetActive(false);
                    smokeBienFx.Play();
                    mouse.gameObject.SetActive(false);
                    boy.gameObject.SetActive(true);
                    boy.AnimationState.SetAnimation(0, "idle", true);
                    DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                    {
                        boy.AnimationState.SetAnimation(0, "0/run", true);
                        boy.gameObject.transform.DOMove(new Vector3(4, boy.transform.position.y, boy.transform.position.z), 3f);
                    });
                });

            });
        });
    }
    private void Option2()
    {
        smokeBienFx.gameObject.SetActive(true);
        smokeBienFx.Play();
        boy.gameObject.SetActive(false);
        mosquito.gameObject.SetActive(true);
        mosquito.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            mosquito.gameObject.transform.DOMove(new Vector3(mosquitoStop.transform.position.x, mosquito.transform.position.y, mosquito.transform.position.z), 2f).OnComplete(() =>
            {
                mosquito.AnimationState.SetAnimation(0, "die", true);
                smokeMosquitoFx.gameObject.SetActive(true);
                smokeMosquitoFx.Play();
                mosquito.gameObject.transform.DOMove(new Vector3(mosquitoDie.transform.position.x, mosquitoDie.transform.position.y, mosquito.transform.position.z),0.5f);
            });
        });
    }


}
