using UnityEngine;
using UnityEngine.Playables;

public class PlayTimelineOnceOnGrab : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;

    private bool hasPlayed = false;

    private void Awake()
    {
        if (timeline == null)
            timeline = GetComponent<PlayableDirector>();
    }

    public void PlayOnce()
    {
        if (hasPlayed) return;

        if (timeline != null)
            timeline.Play();

        hasPlayed = true;
    }
}