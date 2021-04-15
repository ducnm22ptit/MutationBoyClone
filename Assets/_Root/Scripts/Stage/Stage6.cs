using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage6 : StageTwoLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation catAnim;

    [SerializeField] private SkeletonAnimation fireFlyAnim;

    [SerializeField] private SkeletonAnimation spiderAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, electricFx;

    [SerializeField] private GameObject boyStopPos, catStopPos, fishAnim, guns, lineRayFisrt, lineRaySecond;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    [SerializeField] private SpriteRenderer overlaySprite;

    void Start()
    {
        Camera.main.transform.DOMoveX(0, 0);

        optionLeftBtn.onClick.AddListener(Option1);

        optionRightBtn.onClick.AddListener(Option2);


        IntroStageFirst();
    }

    private void IntroStageFirst()
    {
        overlaySprite.DOFade(0.8f, 3f);

        Camera.main.transform.DOMoveX(boyStopPos.transform.position.x, 2f);

        boyAnim.AnimationState.SetAnimation(0, "0/run", true);

        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);

        boyAnim.gameObject.transform.DOMoveX(boyStopPos.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "9/k thay duong", true);
            ShowOptionUI();
        });


    }

    private void IntroStageSecond()
    {
        overlaySprite.DOFade(0f, 2f);
        catAnim.AnimationState.SetAnimation(0, "idle", false);
        smokeBienFirstFx.gameObject.transform.DOMoveX(catStopPos.transform.position.x, 0f);
        smokeBienFirstFx.Play();
        catAnim.gameObject.SetActive(false);
        boyAnim.gameObject.transform.DOMoveX(catStopPos.transform.position.x, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        boyAnim.gameObject.transform.DOMoveX(catStopPos.transform.position.x - 6, 4f);
        Camera.main.transform.DOMoveX(catStopPos.transform.position.x - 6, 3.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "6/nga", true);
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
        });
    }

    private void Option1()
    {
        optionRightBtn.onClick.RemoveListener(Option1);
        optionLeftBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        catAnim.gameObject.SetActive(true);
        catAnim.AnimationState.SetAnimation(0, "idle", false);
   
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            catAnim.AnimationState.SetAnimation(0, "idle flash", false);
            catAnim.AnimationState.SetAnimation(0, "walk flash", true);
            catAnim.gameObject.transform.DOMoveX(catStopPos.transform.position.x, 3f);
            BeforeOnPass(NameLevel.LevelFirst);

        }).OnComplete(() =>
        {
            Camera.main.transform.DOMoveX(catStopPos.transform.position.x, 2.5f).OnComplete(() =>
            {
                HideOptionUI();
                IntroStageSecond();
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

        fireFlyAnim.gameObject.SetActive(true);
        fireFlyAnim.AnimationState.SetAnimation(0, "fly", true);

        fireFlyAnim.gameObject.transform.DOMoveY(fireFlyAnim.transform.position.y + 1.3f, 3f);
        guns.transform.DOMoveY(guns.transform.position.y - 1f, 2f).OnComplete(() =>
        {
            lineRayFisrt.SetActive(true);
            lineRaySecond.SetActive(true);
            DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
            {
                fireFlyAnim.AnimationState.SetAnimation(0, "die", true);
                fireFlyAnim.gameObject.transform.DOMoveY(fireFlyAnim.transform.position.y - 2f, 1f);
                BeforeOnFail(NameLevel.LevelFirst);
                DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
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
        Debug.Log("Option11");
    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);
        Debug.Log("Option22");
    }
}
