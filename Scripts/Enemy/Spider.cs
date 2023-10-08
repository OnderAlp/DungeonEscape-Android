using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    public int Health { get; set; }

    public AudioClip _attackAudio;
    public AudioClip _deathAudio;

    //Use for initalize
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
        base.Update();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            PlayAudioClip(_attackAudio);
        }

    }
    public void Damage()
    {
        if (isDead)
            return;

        if (GameManager.Instance.hasFireSword)
        {
            Health -= 2;
        }
        else
        {
            Health--;
        }

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            PlayAudioClipDelayless(_deathAudio);
            StartCoroutine(loot());
        }
    }

    public override void Movement()
    {
        
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
    IEnumerator loot()
    {
        for (int i = 0; i < gems; i++)
        {
            Instantiate(diamondPreFab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void PlayAudioClip(AudioClip clip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

    }
    public void PlayAudioClipDelayless(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
