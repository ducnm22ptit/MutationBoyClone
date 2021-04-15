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

    [SerializeField] private ParticleSystem smokeBienFirstFx, smokeBienSecondFx;

    [SerializeField] private GameObject boyStopPos, catStopPos, guns, lineRay, escapeDoor;

    [SerializeField] private Button optionLeftBtn, optionRightBtn;

    void Start()
    {
        Camera.main.transform.DOMoveX(0, 0);

        optionLeftBtn.onClick.AddListener(Option1);

        optionRightBtn.onClick.AddListener(Option2);

        IntroStageFirst();

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
            dinoAnim.gameObject.transform.DORotate(new Vector3(0,180,0),0f);
            dinoAnim.AnimationState.SetAnimation(0, "attack", true);
            Camera.main.transform.DOShakePosition(4, 1, 3, 1, false, true).OnComplete(() =>
            {
                escapeDoor.transform.DOMoveY(-0.5f, 1f);
            });
        });

        IntroStageSecond();
    }

    private void Option2()
    {
        optionRightBtn.onClick.RemoveListener(Option1);
        optionLeftBtn.onClick.RemoveListener(Option2);



    }

    private void IntroStageFirst()
    {
        Camera.main.transform.DOMoveX(boyStopPos.transform.position.x - 2.3f, 3f);
        boyAnim.AnimationState.SetAnimation(0,"0/run", true);
        boyAnim.gameObject.transform.DOMoveX(boyStopPos.transform.position.x - 0.6f , 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            boyAnim.AnimationState.SetAnimation(0, "0/0", true);
            ShowOptionUI();
        });
    }

    private void IntroStageSecond()
    {

    }

    private void Option11()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);

        

    }

    private void Option22()
    {
        optionLeftBtn.onClick.RemoveListener(Option11);
        optionRightBtn.onClick.RemoveListener(Option22);


    }
}
