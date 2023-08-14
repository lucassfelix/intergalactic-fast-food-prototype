using UnityEngine;

/// <summary>
/// Base class used for audio events.
/// </summary>
public abstract class AudioEvent : ScriptableObject
{
    /// <summary>
    /// Abstract function. Override it for each new child of AudioEvent.
    /// </summary>
    /// <param name="source">The audio source you want this clip to be played on.</param>
    public abstract void Play(AudioSource source);
}
