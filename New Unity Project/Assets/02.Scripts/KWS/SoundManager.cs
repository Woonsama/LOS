using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    public enum ESound
    {
        MAP_OPEN,
        SCORE_UP,
        MONSTER_ATTACK_FAR,
        PLAYER_DEAD,
        GET_ITEM,
        MONSTER_HIT,
        PLAYER_ATTACK,
        MONSTER_DEAD,
        GAME_CLEAR,
    }

    private static AudioSource audioSoruce;

    [Header("맵 오픈")]
    public AudioClip map_Open;

    [Header("스코어 업")]
    public AudioClip score_Up;

    [Header("몬스터 원거리 공격")]
    public AudioClip monster_Attack_Far;

    [Header("주인공 사망")]
    public AudioClip player_Dead;

    [Header("아이템 획득")]
    public AudioClip get_Item;

    [Header("몬스터 피해")]
    public AudioClip monster_Hit;

    [Header("플레이어 공격")]
    public AudioClip player_Attack;

    [Header("몬스터 사망")]
    public AudioClip monster_Dead;

    [Header("게임 클리어")]
    public AudioClip game_Clear;

    private static Dictionary<ESound, AudioClip> map_Sound = new Dictionary<ESound, AudioClip>();

    private void Awake()
    {
        audioSoruce = GetComponent<AudioSource>();
        InitDictionary();
    }

    public static void Do_SFX(ESound eSound)
    {
        audioSoruce.PlayOneShot(map_Sound[eSound]);
        Debug.Log(eSound + "SFX 실행! : " + map_Sound[eSound]);
    }

    private void InitDictionary()
    {
        map_Sound.Add(ESound.GAME_CLEAR, game_Clear);
        map_Sound.Add(ESound.GET_ITEM, get_Item);
        map_Sound.Add(ESound.MAP_OPEN, map_Open);
        map_Sound.Add(ESound.MONSTER_ATTACK_FAR, monster_Attack_Far);
        map_Sound.Add(ESound.MONSTER_DEAD, monster_Dead);
        map_Sound.Add(ESound.MONSTER_HIT, monster_Hit);
        map_Sound.Add(ESound.PLAYER_ATTACK, player_Attack);
        map_Sound.Add(ESound.PLAYER_DEAD, player_Dead);
        map_Sound.Add(ESound.SCORE_UP, score_Up);
    }
}
