using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;

    public AudioClip _itemBuyAudio;
    protected AudioSource audioSource;

    private Player _player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentSelectedItem = 0;
        currentItemCost = 200;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.gems);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        currentSelectedItem = item;

        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(80);
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-20);
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-120);
                currentItemCost = 100;
                break;

        }
    }

    public void BuyItem()
    {
        if(_player.gems >= currentItemCost)
        {
            _player.gems -= currentItemCost;
            Debug.Log("Purchased " + currentSelectedItem);

            switch (currentSelectedItem)
            {
                case 0:
                    GameManager.Instance.hasFireSword = true;
                    UIManager.Instance.itemImages[0].SetActive(true);
                    UIManager.Instance.UpdateGemCount(_player.gems);
                    UIManager.Instance.OpenShop(_player.gems);
                    PlayAudioClip(_itemBuyAudio);
                    break;
                case 1:
                    GameManager.Instance.hasDoubleJump = true;
                    UIManager.Instance.itemImages[1].SetActive(true);
                    UIManager.Instance.UpdateGemCount(_player.gems);
                    UIManager.Instance.OpenShop(_player.gems);
                    PlayAudioClip(_itemBuyAudio);
                    break;
                case 2:
                    GameManager.Instance.hasKeyToCastle = true;
                    UIManager.Instance.itemImages[2].SetActive(true);
                    UIManager.Instance.UpdateGemCount(_player.gems);
                    UIManager.Instance.OpenShop(_player.gems);
                    PlayAudioClip(_itemBuyAudio);
                    break;
            }
                
        }
        else
        {
            shopPanel.SetActive(false);
        }

    }

    public void PlayAudioClip(AudioClip clip)
    {
            audioSource.clip = clip;
            audioSource.Play();
    }
}
