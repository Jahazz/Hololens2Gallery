using System;
using UnityEngine;

public class ImageRequest
{
    public string UrlToImage { get; private set; }
    public Action<Sprite> Callback { get; private set; }

    public ImageRequest (string urlToImage, Action<Sprite> callback)
    {
        UrlToImage = urlToImage;
        Callback = callback;
    }
}
