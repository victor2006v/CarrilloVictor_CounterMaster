
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform runnersParent;

    public void Run() {
        for (int i = 0; i < runnersParent.childCount; i++) {
            Transform runner = runnersParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();
            runnerAnimator.Play("Walk");
        }
    }
    public void Idle() {
        for (int i = 0; i < runnersParent.childCount; i++) {
            Transform runner = runnersParent.GetChild(i);
            Animator runnerAnimator = runner.GetComponent<Animator>();
            runnerAnimator.Play("Idle");
        }
    }
}
