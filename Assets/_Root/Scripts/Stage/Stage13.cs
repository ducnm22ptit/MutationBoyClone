using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage13 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation corcodieAnim, snakeAnim, birdAnim, catAnim, fireFlyAnim, eyeFirstAnim, eyeSecondAnim, eyeThirdAnim, kangarooAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx;

    [SerializeField] private GameObject eyesAnim, firstStopPos, secondStopPos, woodObject, twinkleObject, kangarooStopPos, birdStopPos, birdStopPosSecond, fishAnim, fishStopPos, fishSecondStopPos, snakeStopPos, woodStopPos;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    [SerializeField] private SpriteRenderer drarkImg;
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
        Camera.main.transform.DOMoveX(0f, 0f);
        boyAnim.AnimationState.SetAnimation(0, "7/cai ao", true);
        ShowOptionUI();
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMoveX(9.74f, 0f);
        woodObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "8/bi can duong", true);
        boyAnim.gameObject.transform.DOMove(woodObject.transform.position, 0f);
        woodObject.transform.DOMove(woodStopPos.transform.position, 3f).SetEase(Ease.Linear);
        boyAnim.gameObject.transform.DOMove(woodStopPos.transform.position, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
        });
    }

    private void IntroStageThird()
    {
        boyAnim.gameObject.transform.DOMove(birdStopPosSecond.transform.position, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.SetActive(true);
        Camera.main.transform.DOMoveX(22f, 0f);
        boyAnim.gameObject.transform.DOMoveX(smokeBienFifthFx.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            drarkImg.DOFade(0.6f, 1f);
            boyAnim.AnimationState.SetAnimation(0, "9/k thay duong", true);
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option111);
            optionRightBtn.onClick.AddListener(Option222);
        });
    }

    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.gameObject.transform.DOMoveX(snakeAnim.transform.position.x, 0f);
        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        snakeAnim.gameObject.SetActive(true);
        snakeAnim.AnimationState.SetAnimation(0, "swim water", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            Camera.main.transform.DOMoveX(3f, 4f);
            snakeAnim.gameObject.transform.DOMoveX(snakeStopPos.transform.position.x, 4f).OnComplete(() =>
            {
                smokeBienSecondFx.Play();
                snakeAnim.gameObject.SetActive(false);
                boyAnim.gameObject.transform.DOMove(smokeBienSecondFx.transform.position, 0f);
                boyAnim.AnimationState.SetAnimation(0, "7/ngoi tren van go", true);
                boyAnim.gameObject.SetActive(true);
                DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
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
        boyAnim.gameObject.SetActive(false);
        fishAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(0.1f).AppendCallback(() =>
        {
            fishAnim.gameObject.transform.DOMove(fishStopPos.transform.position, 0.4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                fishAnim.gameObject.transform.DOMove(fishSecondStopPos.transform.position, 0.1f);
            });
            DOTween.Sequence().AppendInterval(0.4f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelFirst);
                fishAnim.SetActive(false);
                corcodieAnim.gameObject.SetActive(true);
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

        birdAnim.gameObject.transform.DOMove(boyAnim.transform.position, 0f);
        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        birdAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
        {
            birdAnim.gameObject.transform.DOMove(birdStopPos.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                Camera.main.transform.DOMoveX(19.65f, 4.3f);
                BeforeOnPass(NameThreeLevel.LevelSecond);
                birdAnim.gameObject.transform.DOMove(birdStopPosSecond.transform.position, 3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    HideOptionUI();
                    ChangeImgTwoTimeOptionUI();
                    DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                    {
                        boyAnim.gameObject.transform.DOMove(birdStopPosSecond.transform.position, 0f);
                        smokeBienFourthFx.Play();
                        birdAnim.gameObject.SetActive(false);
                        boyAnim.gameObject.SetActive(true);
                        Camera.main.transform.DOMoveX(22f, 3f);
                        DataController.Instance.indexLevel += 1;
                        IntroStageThird();
                    });

                });
            });
        });

    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        kangarooAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            kangarooAnim.AnimationState.SetAnimation(0, "nga", false);
            BeforeOnFail(NameThreeLevel.LevelSecond);
            kangarooAnim.gameObject.transform.DOMove(kangarooStopPos.transform.position, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                HideOptionUI();
                kangarooAnim.gameObject.transform.DOMoveY(kangarooStopPos.transform.position.y - 3f, 0.4f).OnComplete(() =>
                {
                    // HideOptionUI();
                    OnContinue();
                });
            });
        });

    }

    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFifthFx.Play();
        boyAnim.gameObject.SetActive(false);
        fireFlyAnim.gameObject.SetActive(true);
        fireFlyAnim.AnimationState.SetAnimation(0, "fly", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            twinkleObject.SetActive(true);
            BeforeOnPass(NameThreeLevel.LevelThird);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                HideOptionUI();
                drarkImg.DOFade(0f, 1f).OnComplete(() =>
                {
                    twinkleObject.SetActive(false);
                });
                fireFlyAnim.gameObject.transform.DOMoveX(fireFlyAnim.gameObject.transform.position.x + 4f, 3.8f).OnComplete(() =>
                {
                    OnPass();
                });
            });
        });

    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFifthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        catAnim.gameObject.SetActive(true);
        eyesAnim.gameObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
        {
            catAnim.AnimationState.SetAnimation(0, "afraid", true);
            DOTween.Sequence().AppendInterval(0.8f).AppendCallback(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelThird);
                eyeFirstAnim.AnimationState.SetAnimation(0, "eye2", true);
                eyeSecondAnim.AnimationState.SetAnimation(0, "eye2", true);
                eyeThirdAnim.AnimationState.SetAnimation(0, "eye2", true);
                catAnim.AnimationState.SetAnimation(0, "run", true);
                catAnim.gameObject.transform.DORotate(new Vector3(0, 360f, 0), 0f).OnComplete(() =>
                {
                    HideOptionUI();
                    catAnim.gameObject.transform.DOMoveX(catAnim.gameObject.transform.position.x - 4f, 3f).OnComplete(() =>
                    {
                        OnContinue();
                    });
                });
            });
        });
    }
}
