using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioSource audioSource;


    public AudioClip move; //움직일때 사운드
    public AudioClip dontmove; //못움직일때 움직이라고 입력하면 사운드
    public AudioClip clear; //클리어 사운드
    public AudioClip fail; //실패 사운드
    public AudioClip coin;
    public AudioClip button;
    public AudioClip attack;
    public AudioClip destroy;
    public AudioClip moveobj;
    public AudioClip block;
    public AudioClip potal;
    public AudioClip turn;



    public AudioClip MouseOn;
    public AudioClip MouseOff;


    public static SoundManger instance;

    void Awake()
    {
        if (SoundManger.instance == null)
        {
            SoundManger.instance = this;
        }
    }
    //움직일때
    public void MoveSound()
    {
        audioSource.PlayOneShot(move);
    }
    //못움직이는거 움직이려고하면
    public void DontMoveSound()
    {
        audioSource.PlayOneShot(dontmove);
    }
    //클리어
    public void ClearSound()
    {
        audioSource.PlayOneShot(clear);
    }
    //졌을때
    public void FailSound()
    {
        audioSource.PlayOneShot(fail);
    }
    //코인
    public void CoinSound()
    {
        audioSource.PlayOneShot(coin);
    }
    //버튼
    public void ButtonSound()
    {
        audioSource.PlayOneShot(button);
    }
    //공격 111
    public void AttackSound()
    {
        audioSource.PlayOneShot(attack);
    }
    //부서질때
    public void DestroySound()
    {
        audioSource.PlayOneShot(destroy);
    }
    //오브젝트 밀때
    public void MoveObjSound()
    {
        audioSource.PlayOneShot(moveobj);
    }
    //공격 막을때
    public void BlockSound()
    {
        audioSource.PlayOneShot(block);
    }
    //마우스 커서에 가져다 댔을때
    public void MouseOnSound()
    {
        audioSource.PlayOneShot(MouseOn);
    }
    //마우스 커서에서 빠져나올때
    public void MouseOffSound()
    {
        audioSource.PlayOneShot(MouseOff);
    }

    //포탈 탈때
    public void PotalSound()
    {
        audioSource.PlayOneShot(potal);
    }
    //회전할때 탈때
    public void TurnSound()
    {
        audioSource.PlayOneShot(turn);
    }
}
