using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage5 : StageOneLevel
{
    [SerializeField] private SkeletonAnimation boyAnim, securityFirstAnim, securitySecondAnim, securityThirdAnim, dinoAnim, tigerAnim;

    [SerializeField] private ParticleSystem smokeBienFx, electricFx;

    [SerializeField] private GameObject boyStop, lockGate, openGate, enemyStopPos, enemyBackPos;

    [SerializeField] private Button optionLeft, optionRight;


    void Start()
    {
        Camera.main.transform.DOMoveX(0, 0);

        optionLeft.onClick.AddListener(Option1);

        optionRight.onClick.AddListener(Option2);

        IntroStage();
    }

    private void IntroStage()
    {
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMoveX(boyStop.transform.position.x, 4f).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/afraid", true);
        });
        Camera.main.transform.DOMoveX(-8.21f, 3.5f).OnComplete(() =>
        {
            lockGate.SetActive(false);
            openGate.SetActive(true);
            DOTween.Sequence().AppendInterval(0.2f).AppendCallback(() =>
            {
                securityFirstAnim.AnimationState.SetAnimation(0, "run", true);
                securitySecondAnim.AnimationState.SetAnimation(0, "run", true);
                securityThirdAnim.AnimationState.SetAnimation(0, "run", true);
            
                securitySecondAnim.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x, 2f).SetEase(Ease.Linear);
                securityThirdAnim.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x + 0.5f, 2.3f).SetEase(Ease.Linear);
                securityFirstAnim.gameObject.transform.DOMoveX(enemyStopPos.transform.position.x + 0.2f, 3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    securityFirstAnim.AnimationState.SetAnimation(0, "idle", true);
                    securitySecondAnim.AnimationState.SetAnimation(0, "idle", true);
                    securityThirdAnim.AnimationState.SetAnimation(0, "idle", true);
                    ShowOptionUI();
                });
            });
        });
    }

    private void Option1()
    {
        optionRight.onClick.RemoveAllListeners();
        optionLeft.onClick.RemoveAllListeners();

        smokeBienFx.Play();
        boyAnim.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
        
        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", false);
        SoundController.Instance.PlaySoundFx(AudioClipName.Dino2);
        dinoAnim.AnimationState.SetAnimation(0, "stamp", true);
        Camera.main.transform.DOShakePosition(4, 1, 3, 1, false, true);
        BeforeOnPass();
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            HideOptionUI();
            securityFirstAnim.AnimationState.SetAnimation(0, "afraid", false);
            securitySecondAnim.AnimationState.SetAnimation(0, "afraid", false);
            securityThirdAnim.AnimationState.SetAnimation(0, "afraid", false);

            securityFirstAnim.gameObject.transform.DORotate(new Vector3(0,0,0), 0f);
            securitySecondAnim.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0f);
            securityThirdAnim.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0f);

            securityFirstAnim.AnimationState.SetAnimation(0, "run afraid", true);
            securitySecondAnim.AnimationState.SetAnimation(0, "run afraid", true);
            securityThirdAnim.AnimationState.SetAnimation(0, "run afraid", true);

            securitySecondAnim.gameObject.transform.DOMoveX(enemyBackPos.transform.position.x, 3f).SetEase(Ease.Linear);
            securityThirdAnim.gameObject.transform.DOMoveX(enemyBackPos.transform.position.x, 3f).SetEase(Ease.Linear);
            securityFirstAnim.gameObject.transform.DOMoveX(enemyBackPos.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                smokeBienFx.Play();
                boyAnim.gameObject.SetActive(true);
                dinoAnim.gameObject.SetActive(false);
                boyAnim.AnimationState.SetAnimation(0, "0/run", true);
                boyAnim.gameObject.transform.DOMoveX(enemyBackPos.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    OnPass();
                });
            });
        });
    }

    private void Option2()
    {
        optionRight.onClick.RemoveAllListeners();
        optionLeft.onClick.RemoveAllListeners();

        smokeBienFx.Play();
        boyAnim.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        tigerAnim.gameObject.SetActive(true);
        tigerAnim.AnimationState.SetAnimation(0, "idle", false);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            securityFirstAnim.AnimationState.SetAnimation(0, "electric", false);
            securitySecondAnim.AnimationState.SetAnimation(0, "Electric", false);
            securityThirdAnim.AnimationState.SetAnimation(0, "Electric", false);
            electricFx.Play();
            tigerAnim.AnimationState.SetAnimation(0, "electric", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Electric);
            BeforeOnFail();
        }); 
        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
        {
            HideOptionUI();
        });
        DOTween.Sequence().AppendInterval(3f).AppendCallback(() =>
        {
            OnFail();
        });
    }

}
