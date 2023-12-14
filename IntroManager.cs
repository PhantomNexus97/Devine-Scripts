using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer _introVideoPlayer;
    public GameObject _targetGameObject;

    private void Start()
    {
        // Subscribe to the videoPlayer's event when the video is finished playing
        _introVideoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Video finished playing, enable the target GameObject
        _targetGameObject.SetActive(true);

        // Unsubscribe from the event to prevent memory leaks
        _introVideoPlayer.loopPointReached -= OnVideoFinished;
    }
}
