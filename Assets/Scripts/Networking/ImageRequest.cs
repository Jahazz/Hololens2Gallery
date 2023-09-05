using Codebase.Utils;
using System;
using System.Collections;
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

        internal IEnumerator DownloadImageAndCallback ()
        {
            yield return DownloadImageAndWaitForFinish();

            if (CurrentRequest != null)
            {
                Texture2D downloadedTexture = ((DownloadHandlerTexture)CurrentRequest.downloadHandler).texture;
                Callback.Invoke(Utils.Texture2DToSprite(downloadedTexture));
            }
            
        }

        private IEnumerator DownloadImageAndWaitForFinish ()
        {
            CurrentRequest = UnityWebRequestTexture.GetTexture(UrlToImage);
            UnityWebRequestAsyncOperation WebRequest = CurrentRequest.SendWebRequest();
            yield return WebRequest;
        }
    }
}
