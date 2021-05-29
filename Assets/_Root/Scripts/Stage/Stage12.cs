using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage12 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation elephantAnim, mantisAnim;

    [SerializeField] private SkeletonAnimation dinoAnim, kangarooAnim, squirrelAnim, birdAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx;

    [SerializeField] private GameObject firstStopPos, secondStopPos, thirdStopPos, fourthStopPos, kangarooStopPos, birdStopPos;

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
        boyAnim.gameObject.transform.DOMoveX(firstStopPos.transform.position.x, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "4/mac bay 1", false);
            boyAnim.AnimationState.SetAnimation(0, "4/mac bay 2", true);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
             {
                 ShowOptionUI();
             });
        });
    }

    private void IntroStageSecond()
    {
        boyAnim.AnimationState.SetAnimation(0, "0/run 2", true);
        boyAnim.gameObject.transform.DOMoveX(firstStopPos.transform.position.x, 0f);
        Camera.main.transform.DOMoveX(0f, 0f).OnComplete(() =>
        {
            Camera.main.transform.DOMoveX(4.46f, 3f);
            boyAnim.gameObject.transform.DOMoveX(secondStopPos.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "5/bun lay", true);
                ShowOptionUI();
                optionLeftBtn.onClick.AddListener(Option11);
                optionRightBtn.onClick.AddListener(Option22);
            });
        });
    }

    private void IntroStageThird()
    {
        Camera.main.transform.DOMoveX(21.55f, 0f);
        boyAnim.gameObject.transform.DOMoveX(thirdStopPos.transform.position.x - 2f, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Breathing);
        boyAnim.gameObject.transform.DOMove(thirdStopPos.transform.position, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "6/nga", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option111);
            optionRightBtn.onClick.AddListener(Option222);
        });
    }

    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        mantisAnim.gameObject.SetActive(true);
        mantisAnim.AnimationState.SetAnimation(0, "mac bay 2", true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            mantisAnim.AnimationState.SetAnimation(0, "success", false);
            BeforeOnPass(NameThreeLevel.LevelFirst);
            DOTween.Sequence().AppendInterval(1).AppendCallback(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "0/run 2", true);
                smokeBienFirstFx.Play();
                SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                mantisAnim.gameObject.SetActive(false);
                boyAnim.gameObject.SetActive(true);
                DataController.Instance.indexLevel += 1;
                HideOptionUI();
                ChangeImgOptionUI();
                IntroStageSecond();
            });
        });
    }

    private void Option2()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        elephantAnim.gameObject.SetActive(true);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelFirst);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
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

        smokeBienSecondFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        dinoAnim.gameObject.SetActive(true);
        boyAnim.gameObject.SetActive(false);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            dinoAnim.AnimationState.SetAnimation(0, "walk", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Dino0);
            SoundController.Instance.PlaySoundFx(AudioClipName.DinoWalk);
            BeforeOnPass(NameThreeLevel.LevelSecond);
            Camera.main.transform.DOMoveX(10.54f, 3f).OnComplete(() =>
            {
                SoundController.Instance.StopSoundFx();
                HideOptionUI();
            });
            dinoAnim.gameObject.transform.DOMoveX(dinoAnim.gameObject.transform.position.x + 2f, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                smokeBienThirdFx.Play();
                SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                dinoAnim.gameObject.SetActive(false);
                boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                boyAnim.gameObject.SetActive(true);
                boyAnim.gameObject.transform.DOMoveX(smokeBienThirdFx.transform.position.x, 0f).OnComplete(() =>
                {
                    boyAnim.gameObject.transform.DOMoveX(thirdStopPos.transform.position.x - 6.5f, 2.5f).OnComplete(() =>
                    {
                        DataController.Instance.indexLevel += 1;
                        ChangeImgTwoTimeOptionUI();
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

        smokeBienSecondFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        kangarooAnim.gameObject.SetActive(true);
        boyAnim.gameObject.SetActive(false);
        kangarooAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            kangarooAnim.AnimationState.SetAnimation(0, "animation", false);
            BeforeOnFail(NameThreeLevel.LevelSecond);
            kangarooAnim.gameObject.transform.DOMove(kangarooStopPos.transform.position, 1f).OnComplete(() =>
            {
                kangarooAnim.AnimationState.SetAnimation(0, "die", true);
                HideOptionUI();
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    OnContinue();
                });
            });
        });
    }
    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFourthFx.gameObject.transform.DOMove(squirrelAnim.gameObject.transform.position, 0f);
        smokeBienFourthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        boyAnim.gameObject.SetActive(false);
        squirrelAnim.gameObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.1f).AppendCallback(() =>
        {
            Camera.main.transform.DOMoveX(23.84f, 3f);
            squirrelAnim.gameObject.transform.DOMove(fourthStopPos.transform.position, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnPass(NameThreeLevel.LevelThird);
                smokeBienFifthFx.Play();
                boyAnim.gameObject.transform.DOMove(smokeBienFifthFx.gameObject.transform.position, 0f).OnComplete(() =>
                {
                    HideOptionUI();
                });
                squirrelAnim.gameObject.SetActive(false);
                boyAnim.AnimationState.SetAnimation(0, "7/cai ao", true);
                boyAnim.gameObject.SetActive(true);
                OnPass();
            });
        });
    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienFourthFx.Play();
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        birdAnim.gameObject.SetActive(true);
        boyAnim.gameObject.SetActive(false);
        birdAnim.AnimationState.SetAnimation(0, "fly", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            birdAnim.gameObject.transform.DOMoveX(birdAnim.gameObject.transform.position.x + 1.3f, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnFail(NameThreeLevel.LevelThird);
                birdAnim.AnimationState.SetAnimation(0, "roi", true);
                birdAnim.gameObject.transform.DOMoveY(birdStopPos.transform.position.y, 1f).OnComplete(() =>
                {
                    HideOptionUI();
                    OnContinue();
                });
            });
        });
    }

}
