using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] effectsClip;
    //0.move 1.dontmove 2.clear 3.fail 4.coin 5.button 6.attack 7.destroy 8.moveobj 9.block 10.potal 11.turn 12.MouseOn 13.MouseOff
    public void EffectsSound(int num)
    {
        audioSource.PlayOneShot(effectsClip[num]);
    }
}
