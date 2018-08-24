using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ParallaxManager : ScriptableObject {

    public ParallaxImage[] parallaxImages;

    private ParallaxImage farClipParallaxImage;
    public ParallaxImage FarClipParallaxImage
    {
        get
        {
            return farClipParallaxImage;
        }
    }
    private ParallaxImage nearClipParallaxImage;
    public ParallaxImage NearClipParallaxImage
    {
        get
        {
            return nearClipParallaxImage;
        }
    }

    private void OnEnable()
    {
        farClipParallaxImage = parallaxImages[0];
        //nearClipParallaxImage = parallaxImages[1];
    }

    public void ChangeParallaxImage(string ID,bool isFarClip)
    {

        foreach (ParallaxImage image in parallaxImages)
        {
            if (image.name == ID)
            {
                if (isFarClip)
                {
                    farClipParallaxImage.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
                    farClipParallaxImage = image;
                }
                else
                {
                    nearClipParallaxImage.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
                    nearClipParallaxImage = image;
                }
            }
        }
    }
}
