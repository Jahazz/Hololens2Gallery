using Gallery.FlickrAPIIntegration.Client;
using Gallery.FlickrAPIIntegration.Endpoints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Gallery.FlickrAPIIntegration.Mediator
{
    public class NetworkingMediator : MonoBehaviour
    {
        private FlickrSoapClient FlickrClient { get; set; }
        private Queue<ImageRequest> ImageRequestQueue { get; set; } = new Queue<ImageRequest>();
        private bool IsRequestCoroutineRunning { get; set; } = false;

        public void SearchForPhotosByName (string queryText, int maxItemCount, Action<List<Photo>> callback)
        {
            StartCoroutine(SearchForPhotosByNameCoroutine(queryText, maxItemCount, callback));
        }

        public void RequestImageFromUrl (string urlToImage, Action<Sprite> callback)
        {
            ImageRequest request = new ImageRequest(urlToImage, callback);
            ImageRequestQueue.Enqueue(request);

            if (IsRequestCoroutineRunning == false)
            {
                StartCoroutine(HandleImageRequestQueue());
            }
        }

        protected virtual void Start ()
        {
            InitializeClient();
        }

        private void InitializeClient ()
        {
            FlickrClient = new FlickrSoapClient();
        }

        private IEnumerator SearchForPhotosByNameCoroutine (string queryText, int maxItemCount, Action<List<Photo>> callback)
        {
            yield return null;
            PhotosSearchRequest request = RequestFactory.GetPhotosSearchRequest(queryText, maxItemCount);
            Task<PhotosSearchResponse> asyncQuery = PhotosSearch.Execute(FlickrClient, request);
            asyncQuery.Wait();
            callback?.Invoke(asyncQuery.Result.PhotoCollection);
        }

        private IEnumerator HandleImageRequestQueue ()
        {
            IsRequestCoroutineRunning = true;
            yield return null;

            while (ImageRequestQueue.Count > 0)
            {
                ImageRequest currentRequest = ImageRequestQueue.Dequeue();
                Sprite output = Texture2DToSprite(DownloadImage(currentRequest.UrlToImage));
                currentRequest.Callback.Invoke(output);
            }

            IsRequestCoroutineRunning = false;
        }
        private Texture2D DownloadImage (string imageUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
            request.SendWebRequest();
            return ((DownloadHandlerTexture)request.downloadHandler).texture;
        }

        private Sprite Texture2DToSprite (Texture2D source)
        {
            return Sprite.Create(source, new Rect(0.0f, 0.0f, source.width, source.height), Vector2.one / 2, 100.0f);
        }
    }
}
