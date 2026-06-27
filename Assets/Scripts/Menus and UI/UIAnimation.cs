using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{

    public GameObject titleimage;
    public GameObject playbutton;
    public GameObject optionsbutton;
    public GameObject exitbutton;
    
    void Start()
    {
        UIAnimations();
    }

    void UIAnimations()
    {
        titleimage.transform.localScale = Vector3.zero;
        LeanTween.scale(titleimage, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack).setDelay(1f);
        LeanTween.moveLocalY(titleimage, 150, 1f).setEase(LeanTweenType.easeOutBounce).setDelay(0.2f);
        LeanTween.moveLocalX(playbutton, 0, 1f).setEase(LeanTweenType.easeOutBounce).setDelay(1.2f);
        LeanTween.moveLocalX(optionsbutton, 0, 1f).setEase(LeanTweenType.easeOutBounce).setDelay(1.4f);
        LeanTween.moveLocalX(exitbutton, 0, 1f).setEase(LeanTweenType.easeOutBounce).setDelay(1.6f);





    }

}
