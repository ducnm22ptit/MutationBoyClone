using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage3 : StageOneLevel
{

    [SerializeField] private SkeletonAnimation boyAnim, gorillaAnim, turtleAnim;

    [SerializeField] private ParticleSystem smokeBienFx;

    [SerializeField] private GameObject boyStop, wallStop, obstaclesWall, leftWall, rightWall, hideDoor;

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
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        Camera.main.transform.DOMoveX(boyStop.transform.position.x, 3f).SetEase(Ease.Linear);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMoveX(boyStop.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            obstaclesWall.transform.DOMoveY(wallStop.transform.position.y, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                ShowOptionUI();
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

        gorillaAnim.gameObject.SetActive(true);
        gorillaAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {

            leftWall.transform.DOMoveX(leftWall.transform.position.x + 0.5f, 5f).SetEase(Ease.Linear);
            rightWall.transform.DOMoveX(rightWall.transform.position.x - 0.5f, 5f).SetEase(Ease.Linear);
            SoundController.Instance.PlaySoundFx(AudioClipName.Gorilla);
            gorillaAnim.AnimationState.SetAnimation(0, "shout", false);
            DOTween.Sequence().AppendInterval(1.3f).AppendCallback(() =>
            {
                hideDoor.GetComponent<Rigidbody2D>().gravityScale = 1;
                SoundController.Instance.PlaySoundFx(AudioClipName.Door);
                BeforeOnPass();
            }).OnComplete(() =>
            {
                DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                {
                    HideOptionUI();
                    gorillaAnim.AnimationState.SetAnimation(0, "climb", false);
                    gorillaAnim.gameObject.transform.Rotate(0, 0, -25);

                    gorillaAnim.gameObject.transform.DOMoveY(gorillaAnim.gameObject.transform.position.y + 1, 1f);

                    DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                    {
                        OnPass();
                    });

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

        turtleAnim.gameObject.SetActive(true);
        turtleAnim.AnimationState.SetAnimation(0, "gather", false);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            turtleAnim.AnimationState.SetAnimation(0, "rung", true);
            leftWall.transform.DOMoveX(leftWall.transform.position.x + 1.5f, 3f).SetEase(Ease.Linear);
            rightWall.transform.DOMoveX(rightWall.transform.position.x - 1.5f, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnFail();
                turtleAnim.AnimationState.SetAnimation(0, "break", true);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
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
