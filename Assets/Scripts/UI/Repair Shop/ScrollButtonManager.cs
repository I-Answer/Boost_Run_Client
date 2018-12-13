using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScrollButtonManager : MonoBehaviour {
    public Image currentImage;
    public AudioClip clickSound;
    public void ChangeSprite(Button button)
    {
        SoundManager.PlaySound(clickSound);
        currentImage.sprite = button.image.sprite;
    }
}
