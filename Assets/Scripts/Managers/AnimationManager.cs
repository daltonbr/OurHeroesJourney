using System.Collections;
using UnityEngine;
using Constants;

public class AnimationManager : MonoBehaviour, IManager
{
    public ManagerState CurrentState { get; private set; }

    private Animator _panelAnimator;

    public void BootSequence()
    {
        Debug.Log($"{GetType().Name} is booting up");

        _panelAnimator = GameObject.Find("Canvas").GetComponent<Animator>();
        CurrentState = ManagerState.Completed;

        Debug.Log($"{GetType().Name} status = {CurrentState}");
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
