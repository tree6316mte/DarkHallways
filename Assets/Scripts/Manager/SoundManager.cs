using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoSingleton<SoundManager>
{
    public string bgmHash = "BGM_Value";
    public string sfxHash = "SFX_Value";

    private Dictionary<string, AudioClip> soundDict;    // SFX와 BGM을 저장할 Dictionary
    public AudioSource bgmPlayer;                       // BGM 재생용 AudioSource
    public AudioSource sfxPlayer;                       // SFX 재생용 AudioSource

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] audioClips;    // 오디오 클립 배열

    private new void Awake()
    {
        base.Awake();
        Init();
    }

    private void Start()
    {
        PlayBGM("Atmosphere_010_Soft(SINGLE LOOP)");
        bgmPlayer.volume = PlayerPrefs.GetInt(bgmHash, 100) / 100f;
        sfxPlayer.volume = PlayerPrefs.GetInt(sfxHash, 100) / 100f;
        // bgmPlayer.volume = 0.5f; // 브금소리 너무 커서 반으로 줄임
    }

    private void Init()
    {
        soundDict = new Dictionary<string, AudioClip>();
        bgmPlayer.loop = true; // BGM은 기본적으로 반복 재생

        // Dictionary 초기화
        foreach (var clip in audioClips)
        {
            soundDict[clip.name] = clip;
        }
    }

    // SFX 재생
    public void PlaySFX(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out var clip))
        {
            sfxPlayer.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFX not found.");
        }
    }

    // BGM 재생
    public void PlayBGM(string bgmName)
    {
        if (soundDict.TryGetValue(bgmName, out var clip))
        {
            if (bgmPlayer.clip != clip)
            {
                bgmPlayer.clip = clip;
                bgmPlayer.Play();
            }
        }
        else
        {
            Debug.LogWarning("BGM not found.");
        }
    }
}