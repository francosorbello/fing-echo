using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageToSpriteComponent : MonoBehaviour
{
    [SerializeField] private Image image;

    public void SetImage(Texture2D imageTex)
    {
        image.sprite = Sprite.Create(imageTex,new Rect(0,0,imageTex.width,imageTex.height),new Vector2(0.5f,0.5f));
    }
}
