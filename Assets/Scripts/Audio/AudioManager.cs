using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager 
{
    #region Fields

    private static bool  initialized = false;
    private static AudioSource audioSource;
    private static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region properties

    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Public Methods

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BallCollision, 
            Resources.Load<AudioClip>("BallCollision1"));
        audioClips.Add(AudioClipName.BallLost,
            Resources.Load<AudioClip>("BallLost"));
        audioClips.Add(AudioClipName.BallSpawn,
            Resources.Load<AudioClip>("BallSpawn"));
        audioClips.Add(AudioClipName.FreezerEffectActivated,
            Resources.Load<AudioClip>("FreezerEffectActivated"));
        audioClips.Add(AudioClipName.FreezerEffectDeactivated,
            Resources.Load<AudioClip>("FreezerEffectDeactivated"));
        audioClips.Add(AudioClipName.GameLost,
            Resources.Load<AudioClip>("GameLost"));
        audioClips.Add(AudioClipName.MenuButtonClick,
            Resources.Load<AudioClip>("MenuButtonClick"));
        audioClips.Add(AudioClipName.SpeedupEffectActivated,
            Resources.Load<AudioClip>("SpeedupEffectActivated"));
        audioClips.Add(AudioClipName.SpeedupEffectDeactivated,
            Resources.Load<AudioClip>("SpeedupEffectDeactivated"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    #endregion
}
