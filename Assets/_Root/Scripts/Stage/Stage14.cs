using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage14 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim, boySecondAnim;

    [SerializeField] private SkeletonAnimation elephantAnim, cheetahAnim, wolfAnim, rabbitAnim, plantAnim, bridgeAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx;

    [SerializeField] private GameObject firstStopPos, finallyStopPos, cheetahStopPos, elephantStopPos, rabbitStopPos, rabbitEaten;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

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
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        Camera.main.transform.DOMoveX(4.07f, 2f);
        boyAnim.gameObject.transform.DOMoveX(smokeBienFirstFx.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            boyAnim.AnimationState.SetAnimation(0, "10/idle", true);
            bridgeAnim.AnimationState.SetAnimation(0, "animation", true);
            ShowOptionUI();
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMoveX(8.23f, 0f);
        Camera.main.transform.DOMoveX(11.28f, 3f);
        elephantAnim.gameObject.SetActive(false);

        smokeBienSecondFx.Play();
        plantAnim.AnimationState.SetAnimation(0, "idle", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.transform.DOMoveX(smokeBienSecondFx.gameObject.transform.position.x, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMoveX(smokeBienThirdFx.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "11/gap cay", true);
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
            ShowOptionUI();
        });
    }

    private void IntroStageThird()
    {
        plantAnim.gameObject.SetActive(false);
        Camera.main.transform.DOMoveX(11.28f, 0f);
        boyAnim.gameObject.transform.DOMoveX(firstStopPos.transform.position.x, 0f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMoveX(smokeBienFifthFx.transform.position.x, 3f).SetEase(Ease.Linear);
        Camera.main.transform.DOMoveX(16.74f, 1.5f).OnComplete(() =>
        {
            Camera.main.transform.DOMoveX(18.5f, 2f).OnComplete(() =>
             {
                 boyAnim.AnimationState.SetAnimation(2, "level14", true);
                 ShowOptionUI();
                 rabbitAnim.gameObject.transform.DOMove(smokeBienFifthFx.transform.position, 0f);

                 optionLeftBtn.onClick.AddListener(Option111);
                 optionRightBtn.onClick.AddListener(Option222);
             });
        });

    }

    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        elephantAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        elephantAnim.AnimationState.SetAnimation(0, "10/nga", false);
        bridgeAnim.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        bridgeAnim.AnimationState.SetAnimation(0, "animation", false);
        DOTween.Sequence().AppendInterval(0.4f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            elephantAnim.gameObject.transform.DOMove(elephantStopPos.transform.position, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                elephantAnim.AnimationState.SetAnimation(0, "10/keo len", false);
                elephantAnim.gameObject.transform.DOMoveX(elephantStopPos.transform.position.x + 0.6f, 0.2f);
                DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
                {
                    HideOptionUI();
                    ChangeImgOptionUI();
                    DataController.Instance.indexLevel += 1;
                    Camera.main.transform.DOMoveX(8.23f, 2f).OnComplete(() =>
                    {
                        IntroStageSecond();
                    });

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
        cheetahAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        cheetahAnim.AnimationState.SetAnimation(0, "jump", false);
        DOTween.Sequence().AppendInterval(0.8f).AppendCallback(() =>
        {
            bridgeAnim.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            cheetahAnim.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            cheetahAnim.gameObject.transform.DOMove(cheetahStopPos.transform.position, 0.2f); // 0.2s xong moi thuc hien tiep duoc, cap nhat cung nen bi delay
            cheetahAnim.AnimationState.SetAnimation(0, "roi", false);
            DOTween.Sequence().AppendInterval(0.1f).AppendCallback(() =>
             {
                 cheetahAnim.AnimationState.SetAnimation(0, "die", true);
                 bridgeAnim.AnimationState.SetAnimation(0, "animation", false);
             });

            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                HideOptionUI();
                OnFail();
            });
        });
    }

    private void Option11()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        rabbitAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            rabbitAnim.AnimationState.SetAnimation(0, "run", true);
            rabbitAnim.gameObject.transform.DOMoveX(rabbitStopPos.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                rabbitAnim.AnimationState.SetAnimation(0, "bi cay an", true);
                plantAnim.AnimationState.SetAnimation(0, "eat", false);
                DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                {
                    rabbitAnim.gameObject.SetActive(false);
                    rabbitAnim.gameObject.transform.DOMove(rabbitEaten.transform.position, 0.5f).OnComplete(() =>
                    {
                        BeforeOnPass(NameThreeLevel.LevelSecond);
                        rabbitAnim.gameObject.SetActive(true);
                        rabbitAnim.AnimationState.SetAnimation(0, "eat", true);
                        DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
                        {
                            HideOptionUI();
                            ChangeImgTwoTimeOptionUI();
                            plantAnim.AnimationState.SetAnimation(0, "die", false);
                            DOTween.Sequence().AppendInterval(1.4f).AppendCallback(() =>
                            {
                                rabbitAnim.gameObject.transform.DOMoveY(rabbitEaten.transform.position.y - 1f, 0.3f);
                                DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                                {
                                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                                    smokeBienFourthFx.Play();
                                    rabbitAnim.gameObject.SetActive(false);
                                    DataController.Instance.indexLevel += 1;
                                    IntroStageThird();
                                });
                            });
                        });
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
        wolfAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        wolfAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            wolfAnim.AnimationState.SetAnimation(0, "attack", false);
            wolfAnim.gameObject.transform.DOMoveX(rabbitStopPos.transform.position.x - 3f, 1.4f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelSecond);
                plantAnim.AnimationState.SetAnimation(0, "eat", false);
                DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
                {
                    wolfAnim.gameObject.SetActive(false);
                    plantAnim.AnimationState.SetAnimation(0, "nhai", true);
                    DOTween.Sequence().AppendInterval(1.5f).OnComplete(() =>
                    {
                        HideOptionUI();
                        OnContinue();
                    });
                });
            });
        });
    }

    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFifthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        elephantAnim.gameObject.transform.DOMove(smokeBienFifthFx.transform.position, 0f).OnComplete(() =>
        {
            elephantAnim.gameObject.SetActive(true);
            elephantAnim.AnimationState.SetAnimation(10, "tree", false);
        });
        DOTween.Sequence().AppendInterval(0.7f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelThird);
            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                boySecondAnim.gameObject.SetActive(true);
                boySecondAnim.AnimationState.SetAnimation(0, "0/run", true);
                smokeBienFifthFx.Play();
                SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
                elephantAnim.gameObject.SetActive(false);
                boySecondAnim.gameObject.transform.DOMoveX(finallyStopPos.transform.position.x, 2.5f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    HideOptionUI();
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
        rabbitAnim.gameObject.SetActive(true);
        rabbitAnim.AnimationState.SetAnimation(0, "tree", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelThird);
            DOTween.Sequence().AppendInterval(2f).AppendCallback(() =>
            {
                HideOptionUI();
                OnContinue();
            });
        });
    }

}
