using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using DG.Tweening;
using UnityEngine.UI;

public class Stage7 : StageTwoLevel
{
    [SerializeField] private SkeletonAnimation boyAnim;

    [SerializeField] private SkeletonAnimation dinoAnim;

    [SerializeField] private SkeletonAnimation batAnim;

    [SerializeField] private SkeletonAnimation mouseAnim;

    [SerializeField] private SkeletonAnimation cockRoachAnim;

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx, smokeFire;

    [SerializeField] private GameObject boyStopPos, boyStopPosSecond, catStopPos, guns, lineRay, escapeDoor;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    void Start()
    {
        Camera.main.transform.DOMoveX(0, 0);

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
            BeforeOnPass(NameLevel.LevelFirst);
            Debug.Log("intro2");
            IntroStageSecond();
        }


    }

    private void Option1()
    {
        optionRightBtn.onClick.RemoveListener(Option1);
        optionLeftBtn.onClick.RemoveListener(Option2);

        smokeBienFirstFx.Play();
        boyAnim.gameObject.SetActive(false);

        SoundController.Instance.PlaySoundFx(AudioClipName.Trans);

        dinoAnim.gameObject.SetActive(true);
        dinoAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            dinoAnim.gameObject.transform.DORotate(new Vector3(0, 180, 0), 0f);
            dinoAnim.AnimationState.SetAnimation(0, "attack", true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Dino2);
            SoundController.Instance.PlaySoundFx(AudioClipName.Mountain);
            Camera.main.transform.DOShakePosition(2, 1, 5, 1, false, true).OnComplete(() =>
            {
                escapeDoor.transform.DOMoveY(-0.8f, 1f).OnComplete(() =>
                {
                    dinoAnim.AnimationState.SetAnimation(0, "idle", true);
                    smokeBienFirstFx.Play();
                    boyAnim.gameObject.SetActive(true);
                    SoundController.Instance.PlaySoundFx(AudioClipName.Trans);
                    dinoAnim.gameObject.SetActive(false);
                    BeforeOnPass(NameLevel.LevelFirst);
                    DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() =>
                    {
                        HideOptionUI();
                        boyAnim.AnimationState.SetAnimation(0, "0/jump", false);
                        boyAnim.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                        boyAnim.gameObject.transform.DOMove(boyStopPosSecond.transform.position, 1f).OnComplete(() =>
                        {
                            DataController.Instance.indexLevel += 1;
                            IntroStageSecond();
                        });

                    });

                });
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

        batAnim.gameObject.SetActive(true);
        batAnim.AnimationState.SetAnimation(0, "fly", true);
        batAnim.gameObject.transform.DOMoveY(batAnim.gameObject.transform.position.x + 2.7f, 2f);

        guns.transform.DOMoveY(guns.transform.position.y - 1f, 2f).OnComplete(() =>
        {
            lineRay.SetActive(true);
            SoundController.Instance.PlaySoundFx(AudioClipName.Laser);
            BeforeOnFail(NameLevel.LevelFirst);
            batAnim.AnimationState.SetAnimation(0, "die", true);
            batAnim.gameObject.transform.DOMoveY(batAnim.gameObject.transform.position.y - 1.7f, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                HideOptionUI();
                OnFail();
            });
        });

    }

    private void IntroStageFirst()
    {
        Camera.main.transform.DOMoveX(boyStopPos.transform.position.x - 2f, 3f);
        boyAnim.AnimationState.SetAnimation(0, "0/run", true);
        boyAnim.gameObject.transform.DOMoveX(boyStopPos.transform.position.x, 3f).SetEase(Ease.Linear).OnComplete(() =>
       {
           boyAnim.AnimationState.SetAnimation(0, "0/0", true);
           ShowOptionUI();
       });
    }

    private void IntroStageSecond()
    {
        boyAnim.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Camera.main.transform.DOMoveX(-12.98f, 0);
        boyAnim.gameObject.transform.DOMove(new Vector3(boyStopPosSecond.transform.position.x - 4f, boyStopPosSecond.transform.position.y - 0.5f, 0), 0f);
        boyAnim.AnimationState.SetAnimation(0, "creep", true);
        DOTween.Sequence().AppendInterval(0.5f).AppendCallback(() =>
        {
            boyAnim.gameObject.transform.DOMoveX(boyStopPosSecond.transform.position.x - 6.5f, 4f).OnComplete(() =>
            {
                boyAnim.AnimationState.SetAnimation(0, "creepsmoke", true);
                ChangeImgOptionUI();
                ShowOptionUI();
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

        cockRoachAnim.gameObject.SetActive(true);
        cockRoachAnim.AnimationState.SetAnimation(0, "run", true);
        BeforeOnPass(NameLevel.LevelTwo);
        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            cockRoachAnim.gameObject.transform.DOMoveX(cockRoachAnim.gameObject.transform.position.x - 5f, 3.5f).OnComplete(() =>
            {
                HideOptionUI();
                OnPass();
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

        mouseAnim.gameObject.SetActive(true);
        mouseAnim.AnimationState.SetAnimation(0, "idle", true);

        DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
        {
            mouseAnim.AnimationState.SetAnimation(0, "walk", true);
            mouseAnim.gameObject.transform.DOMoveX(mouseAnim.gameObject.transform.position.x - 2f, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                BeforeOnFail(NameLevel.LevelTwo);
                mouseAnim.AnimationState.SetAnimation(0, "choke", false);
                DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                {
                    HideOptionUI();
                    OnContinue();
                });
            });
        });


    }
}
