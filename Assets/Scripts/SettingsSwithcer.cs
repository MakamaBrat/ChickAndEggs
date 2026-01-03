using UnityEngine;
using UnityEngine.UI;

public class SettingsSwitcher : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource musicSource;
    public AudioSource[] sfxSources;

    [Header("UI Images")]
    public Image musicImage;
    public Image sfxImage;
    public Image dummyImage;

    [Header("Optional Buttons (to block clicks)")]
    public Button musicButton;
    public Button sfxButton;
    public Button dummyButton;

    [Header("States")]
    public bool musicOn = true;
    public bool sfxOn = true;
    public bool dummyOn = true;

    [Header("Transparency")]
    [Range(0f, 1f)] public float onAlpha = 1f;
    [Range(0f, 1f)] public float offAlpha = 0.4f;

    private void Start()
    {
        ApplyMusicState();
        ApplySfxState();
        ApplyDummyState();
    }

    // --------------------
    // SWITCHERS
    // --------------------

    public void SwitchMusic()
    {
        musicOn = !musicOn;
        ApplyMusicState();
    }

    public void SwitchSfx()
    {
        sfxOn = !sfxOn;
        ApplySfxState();
    }

    public void SwitchDummy()
    {
        dummyOn = !dummyOn;
        ApplyDummyState();
    }

    // --------------------
    // APPLY STATES
    // --------------------

    void ApplyMusicState()
    {
        if (musicSource != null)
            musicSource.mute = !musicOn;

        ApplyImage(musicImage, musicButton, musicOn);
    }

    void ApplySfxState()
    {
        foreach (var sfx in sfxSources)
            if (sfx != null)
                sfx.mute = !sfxOn;

        ApplyImage(sfxImage, sfxButton, sfxOn);
    }

    void ApplyDummyState()
    {
        ApplyImage(dummyImage, dummyButton, dummyOn);
    }

    // --------------------
    // HELPER
    // --------------------

    void ApplyImage(Image img, Button btn, bool state)
    {
        if (img != null)
        {
            Color c = img.color;
            c.a = state ? onAlpha : offAlpha;
            img.color = c;
        }

    }
}
