using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScrollButtonManager : MonoBehaviour {
    public Image currentImage;
    public void ChangeSprite(Button button)
    {
        currentImage.sprite = button.image.sprite;
    }
}
