using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public AudioClip _walkAudio;
    public AudioClip _attackAudio;
    public AudioClip _hitAudio;
    public AudioClip _deathAudio;

    //Use for initalize
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();

    }

    public override void Update()
    {
        base.Update();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            PlayAudioClip(_walkAudio);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            PlayAudioClip(_attackAudio);
        }

    }

    public void Damage()
    {
        if(isDead)
            return;

        Debug.Log("MossGiant:Damage");
        if (GameManager.Instance.hasFireSword)
        {
            Health -= 2;
        }
        else
        {
            Health--;
        }
        
        anim.SetTrigger("Hit");
        PlayAudioClip(_hitAudio);
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {

            isDead = true;
            anim.SetTrigger("Death");
            PlayAudioClipDelayless(_deathAudio);
            StartCoroutine(loot());
        }
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
