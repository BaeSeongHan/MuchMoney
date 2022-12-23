using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioSource audioSource;


    public AudioClip move; //�����϶� ����
    public AudioClip dontmove; //�������϶� �����̶�� �Է��ϸ� ����
    public AudioClip clear; //Ŭ���� ����
    public AudioClip fail; //���� ����
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
    //�����϶�
    public void MoveSound()
    {
        audioSource.PlayOneShot(move);
    }
    //�������̴°� �����̷����ϸ�
    public void DontMoveSound()
    {
        audioSource.PlayOneShot(dontmove);
    }
    //Ŭ����
    public void ClearSound()
    {
        audioSource.PlayOneShot(clear);
    }
    //������
    public void FailSound()
    {
        audioSource.PlayOneShot(fail);
    }
    //����
    public void CoinSound()
    {
        audioSource.PlayOneShot(coin);
    }
    //��ư
    public void ButtonSound()
    {
        audioSource.PlayOneShot(button);
    }
    //���� 111
    public void AttackSound()
    {
        audioSource.PlayOneShot(attack);
    }
    //�μ�����
    public void DestroySound()
    {
        audioSource.PlayOneShot(destroy);
    }
    //������Ʈ �ж�
    public void MoveObjSound()
    {
        audioSource.PlayOneShot(moveobj);
    }
    //���� ������
    public void BlockSound()
    {
        audioSource.PlayOneShot(block);
    }
    //���콺 Ŀ���� ������ ������
    public void MouseOnSound()
    {
        audioSource.PlayOneShot(MouseOn);
    }
    //���콺 Ŀ������ �������ö�
    public void MouseOffSound()
    {
        audioSource.PlayOneShot(MouseOff);
    }

    //��Ż Ż��
    public void PotalSound()
    {
        audioSource.PlayOneShot(potal);
    }
    //ȸ���Ҷ� Ż��
    public void TurnSound()
    {
        audioSource.PlayOneShot(turn);
    }
}
