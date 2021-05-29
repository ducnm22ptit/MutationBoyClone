using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage16 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation cowAnim, hippoAnim, cheetahAnim, moleAnim, eagleAnim, birdAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienThirdFx, smokeBienFourthFx, smokeBienFifthFx, eatRockFx, windFx, firstDirtyirtyFx, secondDirtyirtyFx;

    [SerializeField] private GameObject firstPit, secondPit, stoneObject, coverObject, dropStoneObject, stonesObject, maskObject, eagleStop, firstBirdStop, sescondBirdStop;

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
        Camera.main.transform.DOMoveX(0, 0);
        InvokeRepeating("VibrateCamera", 0, 2f);
        SoundController.Instance.PlaySoundFx(AudioClipName.Mountain);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/run", true);
            stoneObject.SetActive(true);
            boyAnim.gameObject.transform.DOMove(smokeBienFirstFx.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
                SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
                ShowOptionUI();
            });
        });
    }

    private void VibrateCamera()
    {
        Camera.main.transform.DOShakePosition(4, new Vector3(0.3f, 0.3f, 0.3f), 10, 120, false, true);
    }
    private void IntroStageSecond()
    {
        Camera.main.transform.DOMoveX(3.7f, 1f).OnComplete(() =>
        {
            Camera.main.transform.DOMoveX(4.47f, 2f);
            stonesObject.gameObject.SetActive(true);
        });
        Camera.main.transform.DOMoveX(4.47f, 2f);
        boyAnim.gameObject.SetActive(true);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMove(smokeBienSecondFx.transform.position, 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
        });
    }

    private void IntroStageThird()
    {
        SoundController.Instance.StopSoundFx();
        Camera.main.transform.DOMove(new Vector3(10.3f, -2.07f, -10f), 0f);
        boyAnim.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 0f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.SetActive(true);
        boyAnim.gameObject.transform.DOMoveX(smokeBienThirdFx.transform.position.x + 1f, 1f).OnComplete(() =>
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
        hippoAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        hippoAnim.gameObject.SetActive(true);

        coverObject.SetActive(false);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelFirst);
            hippoAnim.AnimationState.SetAnimation(0, "animation", false);
            eatRockFx.Play();
            stoneObject.SetActive(false);
            DOTween.Sequence().AppendInterval(0.1f).AppendCallback(() =>
            {
                CancelInvoke();
                DOTween.Sequence().AppendInterval(3f).AppendCallback(() =>
                {
                    smokeBienFirstFx.Play();
                    boyAnim.gameObject.SetActive(true);
                    hippoAnim.gameObject.SetActive(false);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
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
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        cowAnim.gameObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
        {
            cowAnim.AnimationState.SetAnimation(0, "butt2", false);
            cowAnim.AnimationState.SetAnimation(0, "crazy", true);
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
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        dropStoneObject.SetActive(true);
        moleAnim.gameObject.SetActive(true);
        firstPit.SetActive(true);
        maskObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
        {
            firstDirtyirtyFx.Play();
            moleAnim.gameObject.transform.DOMoveY(moleAnim.transform.position.y - 1, 1.5f).OnComplete(() =>
            {
                BeforeOnPass(NameThreeLevel.LevelSecond);
                Camera.main.transform.DOMove(new Vector3(10.3f, -2.07f, -10f), 4.5f);
                secondPit.SetActive(true);
                moleAnim.gameObject.transform.DOMove(secondDirtyirtyFx.transform.position, 0f).OnComplete(() =>
                {
                    moleAnim.gameObject.transform.DOMoveY(secondDirtyirtyFx.transform.position.y - 1f, 0).OnComplete(() =>
                    {
                        secondDirtyirtyFx.Play();
                        moleAnim.gameObject.transform.DOMoveY(moleAnim.transform.position.y + 1f, 1.5f).OnComplete(() =>
                        {
                            smokeBienThirdFx.Play();
                            boyAnim.gameObject.transform.DOMove(smokeBienThirdFx.transform.position, 0f);
                            boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                            boyAnim.gameObject.SetActive(true);
                            SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                            dropStoneObject.SetActive(true);
                            moleAnim.gameObject.SetActive(false);
                            secondPit.SetActive(false);
                            maskObject.SetActive(false);
                            DataController.Instance.indexLevel += 1;
                            HideOptionUI();
                            ChangeImgTwoTimeOptionUI();
                            IntroStageThird();
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

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        cheetahAnim.gameObject.SetActive(true);
        dropStoneObject.SetActive(true);
        DOTween.Sequence().AppendInterval(0.3f).AppendCallback(() =>
        {
            BeforeOnFail(NameThreeLevel.LevelSecond);
            cheetahAnim.AnimationState.SetAnimation(0, "jump", false);
            cheetahAnim.AnimationState.SetAnimation(0, "die", true);
            DOTween.Sequence().AppendInterval(3f).AppendCallback(() =>
            {
                HideOptionUI();
                OnContinue();
            });
        });
    }

    private void Option111()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienThirdFx.gameObject.transform.DOMove(eagleAnim.transform.position, 0f);
        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        eagleAnim.gameObject.SetActive(true);
        eagleAnim.AnimationState.SetAnimation(0, "fly", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            BeforeOnPass(NameThreeLevel.LevelThird);
            eagleAnim.gameObject.transform.DOMove(eagleStop.transform.position, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                HideOptionUI();
                OnPass();
            });
        });
    }

    private void Option222()
    {
        optionLeftBtn.onClick.RemoveListener(Option111);
        optionRightBtn.onClick.RemoveListener(Option222);

        smokeBienThirdFx.gameObject.transform.DOMove(birdAnim.transform.position, 0f);
        smokeBienThirdFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        birdAnim.gameObject.SetActive(true);
        birdAnim.AnimationState.SetAnimation(0, "fly", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            birdAnim.gameObject.transform.DOMove(firstBirdStop.transform.position, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
           {
               BeforeOnFail(NameThreeLevel.LevelThird);
               windFx.Play();
               birdAnim.AnimationState.SetAnimation(0, "roi", true);
               DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
                {
                    birdAnim.gameObject.transform.DOMove(sescondBirdStop.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        HideOptionUI();
                        OnContinue();
                    });
                });
           });
        });

    }

}
