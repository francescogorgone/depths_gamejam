using UnityEngine;
using UnityEngine.Rendering;

public class DeepAudioManager : MonoBehaviour
{
    public static DeepAudioManager Instance{ get; private set;}
    [SerializeField] private AudioClip game_120;
    [SerializeField] private AudioClip game_180;
    [SerializeField] private AudioClip game_alarm_180;

    private AudioSource source;
    private BackgroundMusic currentMusic;
    
    public enum BackgroundMusic
    {
        None,
        high_oxygen,
        normal_oxygen,
        low_oxygen,
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentMusic = BackgroundMusic.None;
        PlayMusic(BackgroundMusic.high_oxygen);
    }

    public void PlayMusic(BackgroundMusic music)
    {
        if(currentMusic == music){
            return;
        }
        switch (music)
        {
            case BackgroundMusic.high_oxygen:
            source.clip =game_120;
            source.loop = true;
            source.Play();
            break;

            case BackgroundMusic.normal_oxygen:
            source.clip =game_180;
            source.loop = true;
            source.Play();
            break;

            case BackgroundMusic.low_oxygen:
            source.clip =game_alarm_180;
            source.loop = true;
            source.Play();
            break;
            default:
            break;
        }
        currentMusic = music;
    }
}