using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;

public class PendulumAngleTrigger : MonoBehaviour
{
    [SerializeField] private float triggerAngle = 15f;
    [SerializeField] private PlayableDirector clockTimeline;
    [SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] private Rigidbody rb;

    private HingeJoint hinge;
    private bool triggered = false;

    private void Awake()
    {
        hinge = GetComponent<HingeJoint>();

        if (clockTimeline == null)
            clockTimeline = GetComponentInParent<PlayableDirector>();

        if (grabInteractable == null)
            grabInteractable = GetComponent<XRGrabInteractable>();

        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (triggered || hinge == null) return;

        if (Mathf.Abs(hinge.angle) <= triggerAngle)
        {
            triggered = true;

            if (clockTimeline != null)
                clockTimeline.Play();

            if (grabInteractable != null)
                grabInteractable.enabled = false;

            if (rb != null)
                rb.isKinematic = true;
        }
    }

    private void Start()
    {
        Debug.Log("Start angle = " + hinge.angle);
    }
}

