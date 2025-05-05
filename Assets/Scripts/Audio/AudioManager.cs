using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource[] soundEffects;
    [SerializeField] private AudioSource[] backgroundMusic;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public void PlaySoundEffect(int index)
    {
        if (index < soundEffects.Length)
        {
            soundEffects[index].pitch = RandomGenerator.GetRandomFloat(0.8f, 1.15f);
            soundEffects[index].Play();
        }
    }

    public void StopSoundEffect(int index)
    {
        soundEffects[index].Stop();
    }
    
    public void PlayBackgroundMusic(int index)
    {
        if (index < backgroundMusic.Length)
        {
            StopBackgroundMusic();
            backgroundMusic[index].Play();
        }
    }

    private void StopBackgroundMusic()
    {
        for (int i = 0; i < backgroundMusic.Length; i++)
        {
            backgroundMusic[i].Stop();
        }
    }

}
