
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class SongManager : UdonSharpBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] songs;
    void Start()
    {
        
    }

    public void PlaySong(int song)
    {
        if (song < 0 || song >= songs.Length) return;

        audioSource.Stop();
        audioSource.clip = songs[song];
        audioSource.Play();
    }
}
