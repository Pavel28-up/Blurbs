using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSystems : MonoBehaviour
{
    public static SoundsSystems Instance;
    [SerializeField] private AudioClip vishkasMovementAudioClip;
    private AudioSource _vishkasMovementAbilitySource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        _vishkasMovementAbilitySource = ConvertClipToConponent(vishkasMovementAudioClip);
        OnEnabled();
    }

    private void OnEnabled()
    {
        GameEvents.Instance.OnVishkasMovement += PlayDashSound;
    }

    private void OnDisabled()
    {
        GameEvents.Instance.OnVishkasMovement -= PlayDashSound;
    }

    public void PlayDashSound()
    {
        _vishkasMovementAbilitySource.PlayOneShot(vishkasMovementAudioClip);
    }

    private AudioSource ConvertClipToConponent(AudioClip clipToConvert)
    {
        AudioSource shootingSource = gameObject.AddComponent<AudioSource>();
        shootingSource.clip = clipToConvert;
        shootingSource.playOnAwake = false;
        shootingSource.volume = 1f;
        return shootingSource;
    }
}
