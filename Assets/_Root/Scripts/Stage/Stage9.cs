using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage9 : StageThreeLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation sharkAnim, dieSharkAnim, whaleAnim, machineSharkFisrt, machineSharkSecond, machineSharkThird;

    [SerializeField] private SkeletonAnimation securityFisrtAnim, securitySecondAnim, securityThirdAnim;

    [SerializeField] private SkeletonAnimation mantisAnim, cheetahAnim;

    [SerializeField] private SkeletonAnimation gorillaAnim, mokeyAnim, catAnim;

    [SerializeField] private SkeletonAnimation dinoAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeBienFourFx, waterFirstFx, waterSecondFx, electricFx, electricSecondFx;

    [SerializeField] private GameObject boyStopPos, doorEscape, machineShark, securityAnims, secondStopPos, columnFirst, columnSecond, listLazer;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    void Start()
    {
        if (DataController.Instance.indexLevel == 0)
        {
            optionLeftBtn.onClick.AddListener(Option1);
            optionRightBtn.onClick.AddListener(Option2);
            IntroStageFirst();
        }
        else if (DataController.Instance.indexLevel == 1)
        {
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
            ChangeImgOptionUI();
            BeforeOnPass(NameThreeLevel.LevelFirst);
            IntroStageSecond();
        }
        else if (DataController.Instance.indexLevel == 2)
        {
            optionLeftBtn.onClick.AddListener(Option111);
            optionRightBtn.onClick.AddListener(Option222);
            ChangeImgTwoTimeOptionUI();
            BeforeOnPass(NameThreeLevel.LevelSecond);
            IntroStageThird();
        }

    }
    private void Option1()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);
        smokeBienFirstFx.gameObject.transform.DOScale(5, 0f);
        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        BeforeOnPass(NameThreeLevel.LevelFirst);
        whaleAnim.gameObject.SetActive(true);
        whaleAnim.AnimationState.SetAnimation(0, "idle2", true);
        waterFirstFx.Play();
        waterSecondFx.Play();

        machineShark.transform.DOMoveY(machineShark.transform.position.y - 4f, 4f).OnComplete(() =>
        {
            smokeBienFirstFx.gameObject.transform.DOScale(2, 0f);
            HideOptionUI();
            DataController.Instance.indexLevel += 1;
        });
        Camera.main.transform.DOMove(new Vector3(11, 0, -10f), 4f).OnComplete(() =>
         {
             IntroStageSecond();
         });

    }

    private void Option2()
    {
        optionLeftBtn.onClick.RemoveListener(Option1);
        optionRightBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        sharkAnim.gameObject.SetActive(true);
        sharkAnim.AnimationState.SetAnimation(0, "afraid", true);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            machineSharkFisrt.AnimationState.SetAnimation(0, "attack", true);
            machineSharkSecond.AnimationState.SetAnimation(0, "attack", true);
            machineSharkThird.AnimationState.SetAnimation(0, "attack", true);
            BeforeOnFail(NameThreeLevel.LevelFirst);
            machineSharkFisrt.gameObject.transform.DOMove(sharkAnim.gameObject.transform.position, 0.6f).SetEase(Ease.Linear);
            machineSharkSecond.gameObject.transform.DOMove(sharkAnim.gameObject.transform.position, 0.8f).SetEase(Ease.Linear);
            machineSharkThird.gameObject.transform.DOMove(sharkAnim.gameObject.transform.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                sharkAnim.gameObject.SetActive(false);
                dieSharkAnim.gameObject.SetActive(true);
                machineSharkFisrt.gameObject.SetActive(false);
                machineSharkSecond.gameObject.SetActive(false);
                machineSharkThird.gameObject.SetActive(false);
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

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        mantisAnim.gameObject.SetActive(true);
        mantisAnim.AnimationState.SetAnimation(0, "idle2", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            mantisAnim.AnimationState.SetAnimation(0, "hit1", false);
            mantisAnim.gameObject.transform.DOMove(securityFisrtAnim.gameObject.transform.position, 0.3f).OnComplete(() =>
            {
                securityFisrtAnim.AnimationState.SetAnimation(0, "die", false);
                securitySecondAnim.gameObject.transform.DORotate(new Vector3(0, 360, 0), 0);
                securitySecondAnim.AnimationState.SetAnimation(0, "afraid", false);
                securityThirdAnim.gameObject.transform.DORotate(new Vector3(0, 360, 0), 0);
                securityThirdAnim.AnimationState.SetAnimation(0, "afraid", false);
                DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                {
                    mantisAnim.AnimationState.SetAnimation(0, "hit2", false);
                    mantisAnim.AnimationState.SetAnimation(0, "hit3", false);
                    securitySecondAnim.AnimationState.SetAnimation(0, "die", false);
                    mantisAnim.AnimationState.SetAnimation(0, "hit4", false);
                    mantisAnim.AnimationState.SetAnimation(0, "hit5", false);
                    securityThirdAnim.AnimationState.SetAnimation(0, "die", false);
                    DOTween.Sequence().AppendInterval(0.6f).AppendCallback(() =>
                    {
                        BeforeOnPass(NameThreeLevel.LevelSecond);
                        mantisAnim.AnimationState.SetAnimation(0, "idle2", true);
                        smokeBienSecondFx.gameObject.transform.DOMove(mantisAnim.transform.position, 0f);
                        boyAnim.gameObject.transform.DOMove(mantisAnim.transform.position, 0f);
                        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                        {
                            ChangeImgTwoTimeOptionUI();
                            HideOptionUI();
                            smokeBienSecondFx.Play();
                            mantisAnim.gameObject.SetActive(false);
                            boyAnim.gameObject.SetActive(true);
                            boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                            Camera.main.transform.DOMoveX(18.5f, 3.5f);
                            boyAnim.gameObject.transform.DOMove(secondStopPos.transform.position, 3.5f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                DataController.Instance.indexLevel += 1;
                                IntroStageThird();
                            });
                        });
                    });

                });
            });
        });
    }

    private void Option22()
    {
        optionRightBtn.onClick.RemoveListener(Option22);
        optionLeftBtn.onClick.RemoveListener(Option11);

        smokeBienSecondFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        cheetahAnim.gameObject.SetActive(true);
        cheetahAnim.AnimationState.SetAnimation(0, "attack", false);
        DOTween.Sequence().AppendInterval(0.4f).AppendCallback(() =>
        {
            electricFx.Play();
            securityFisrtAnim.AnimationState.SetAnimation(0, "electric", false);
            securitySecondAnim.AnimationState.SetAnimation(0, "Electric", false);
            securityThirdAnim.AnimationState.SetAnimation(0, "Electric", false);
            cheetahAnim.AnimationState.SetAnimation(0, "die", true);
            BeforeOnFail(NameThreeLevel.LevelSecond);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
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

        smokeBienFourFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            dinoAnim.AnimationState.SetAnimation(0, "stamp", true);
            Camera.main.transform.DOShakePosition(2, 1, 3, 1, false, true);
            BeforeOnPass(NameThreeLevel.LevelThird);
            DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
            {
                columnFirst.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
                columnSecond.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
                listLazer.SetActive(false);
                dinoAnim.AnimationState.SetAnimation(0, "idle", true);
                mokeyAnim.AnimationState.SetAnimation(0, "turn", true);
                catAnim.AnimationState.SetAnimation(0, "run", true);
                DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
                {
                    smokeBienFourFx.Play();
                    dinoAnim.gameObject.SetActive(false);
                    boyAnim.gameObject.SetActive(true);
                    boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                    boyAnim.gameObject.transform.DOMoveX(boyAnim.transform.position.x + 8, 3.3f);
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
        smokeBienFourFx.Play();
        boyAnim.gameObject.SetActive(false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        gorillaAnim.gameObject.SetActive(true);
        gorillaAnim.AnimationState.SetAnimation(0, "idle", true);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            gorillaAnim.AnimationState.SetAnimation(0, "Hit", false);
            DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
            {
                electricSecondFx.Play();
                gorillaAnim.AnimationState.SetAnimation(0, "electric", true);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    HideOptionUI();
                    OnContinue();
                });
            });
        });
    }

    private void IntroStageFirst()
    {
        Camera.main.transform.DOMove(new Vector3(0, 0, -10f), 0f);

        doorEscape.transform.DOMoveY(doorEscape.transform.position.y - 7.6f, 1f).SetEase(Ease.Linear);
        boyAnim.AnimationState.SetAnimation(0, "creep", true);
        machineSharkFisrt.AnimationState.SetAnimation(0, "idle", true);
        machineSharkSecond.AnimationState.SetAnimation(0, "idle", true);
        machineSharkThird.AnimationState.SetAnimation(0, "idle", true);
        boyAnim.gameObject.transform.DOMoveX(boyAnim.gameObject.transform.position.x + 1f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            SoundController.Instance.PlaySoundFx(AudioClipName.Scream);
            boyAnim.AnimationState.SetAnimation(0, "fall2", true);
            boyAnim.gameObject.transform.DOMove(boyStopPos.transform.position, 1f).OnComplete(() =>
            {
                ShowOptionUI();
            });
        });
    }

    private void IntroStageSecond()
    {
        Camera.main.transform.DOMove(new Vector3(11, 0, -10f), 0f);
        whaleAnim.gameObject.SetActive(false);
        smokeBienSecondFx.Play();
        boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        boyAnim.gameObject.SetActive(true);
        boyAnim.gameObject.transform.DOMove(mantisAnim.gameObject.transform.position, 0f);
        securityAnims.SetActive(true);
        securityFisrtAnim.AnimationState.SetAnimation(0, "run", true);
        securitySecondAnim.AnimationState.SetAnimation(0, "run", true);
        securityThirdAnim.AnimationState.SetAnimation(0, "run", true);
        securityAnims.transform.DOMoveX(securityAnims.transform.position.x - 4, 1.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            securityFisrtAnim.AnimationState.SetAnimation(0, "idle", true);
            securitySecondAnim.AnimationState.SetAnimation(0, "idle", true);
            securityThirdAnim.AnimationState.SetAnimation(0, "idle", true);
            ChangeImgOptionUI();
            ShowOptionUI();
            optionLeftBtn.onClick.AddListener(Option11);
            optionRightBtn.onClick.AddListener(Option22);
        });
    }

    private void IntroStageThird()
    {
        Camera.main.transform.DOMoveX(18.5f, 0f);
        mokeyAnim.AnimationState.SetAnimation(0, "bi duoi", true);
        catAnim.AnimationState.SetAnimation(0, "afraid", true);
        boyAnim.AnimationState.SetAnimation(0, "level9", true);
        ShowOptionUI();
        optionLeftBtn.onClick.AddListener(Option111);
        optionRightBtn.onClick.AddListener(Option222);
    }
}