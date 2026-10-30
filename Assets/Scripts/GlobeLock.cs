using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;

public class GlobeLock : MonoBehaviour
{
    public float targetAngle = 120f;
    [SerializeField] private PlayableDirector timeline;

    private bool locked = false;

    private XRGrabInteractable grab;
    private Rigidbody rb;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (locked) return;

        float angle = transform.localEulerAngles.y;

        if (angle >= targetAngle)
        {
            locked = true;

            grab.enabled = false;
            rb.isKinematic = true;

	    if(timeline!= null)
		timeline.Play();
        }
    }
}