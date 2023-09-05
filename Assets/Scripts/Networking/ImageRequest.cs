using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Gallery.FlickrAPIIntegration.Mediator
{
    public class ImageRequest
    {
        public string UrlToImage { get; private set; }
        public Action<Sprite> Callback { get; private set; }
        public bool IsRequestActive { get; set; } = true;
        public float RequestProgress {
            get {
                return CurrentRequest != null ? CurrentRequest.downloadProgress : 0.0f;
            }
        }
        private UnityWebRequest CurrentRequest { get; set; }

        public ImageRequest (string urlToImage, Action<Sprite> callback)
        {
            UrlToImage = urlToImage;
            Callback = callback;
        }

        public void AbortRequest ()
        {
            IsRequestActive = false;
            CurrentRequest?.Abort();
            CurrentRequest = null;
        }

        internal Texture2D DownloadImage ()
        {
            Texture2D output = null;
            CurrentRequest = UnityWebRequestTexture.GetTexture(UrlToImage);
            CurrentRequest.SendWebRequest();

            if (IsRequestActive == true)
            {
                output = ((DownloadHandlerTexture)CurrentRequest.downloadHandler).texture;
            }

            return output;
        }
    }
}
