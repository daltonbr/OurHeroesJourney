using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class AnimationManager : MonoBehaviour, IManager
{
    public ManagerState CurrentState { get; private set; }

    private Animator _panelAnimator;

    public void BootSequence()
    {
        Debug.Log(string.Format("{0} is booting up", GetType().Name));

        _panelAnimator = GameObject.Find("Canvas").GetComponent<Animator>();
        CurrentState = ManagerState.Completed;

        Debug.Log(string.Format("{0} status = {1}", GetType().Name, CurrentState));
    }

    public IEnumerator IntroAnimation()
    {
        AnimationTuple introAnim = Constants.AnimationTuples.IntroAnimation;
        _panelAnimator.SetBool(introAnim.Parameter, introAnim.Value);

        yield return new WaitForSeconds(1);
    }

    public IEnumerator ExitAnimation()
    {
        AnimationTuple exitAnim = Constants.AnimationTuples.ExitAnimation;
        _panelAnimator.SetBool(exitAnim.Parameter, exitAnim.Value);

        yield return new WaitForSeconds(1);
    }

}
