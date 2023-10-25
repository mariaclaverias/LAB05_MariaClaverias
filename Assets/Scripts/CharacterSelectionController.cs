using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour
{
    public Coin coin;

    public Button[] buttons;
    public Nave[] naves;
    public Button[] buyButtons;

    public Color[] colors;

    public AudioClip[] audioClip;

    private void Awake()
    {
        UnlockedUpdate();
    }

    public void BuyNave(Nave nave)
    {
        if (coin.coin >= nave.cost)
        {
            coin.RemoveCoin(nave.cost);
            nave.isLocked = false;
            UnlockedUpdate();
            AudioSource.PlayClipAtPoint(audioClip[0], Vector3.zero);
        }
        else
        {
            AudioSource.PlayClipAtPoint(audioClip[1], Vector3.zero);
        }
    }

    private void UnlockedUpdate()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (naves[i].isLocked)
            {
                buttons[i].interactable = false;
                buyButtons[i].gameObject.SetActive(true);
                buttons[i].GetComponent<Image>().color = colors[1];
            }
            else
            {
                buttons[i].interactable = true;
                buyButtons[i].gameObject.SetActive(false);
                buttons[i].GetComponent<Image>().color = colors[0];
            }
        }
    }
}
