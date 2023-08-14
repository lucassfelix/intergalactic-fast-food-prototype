using UnityEngine.UI;

public class AudioButton : Button
{
    public AudioEvent clickAudioEvent;

    protected override void Awake()
    {
        base.Awake();
        onClick.AddListener(OnClickAudio);
    }

    private void OnClickAudio()
    {
        AudioManager.Instance.PlayEvent(clickAudioEvent);
    }
}
