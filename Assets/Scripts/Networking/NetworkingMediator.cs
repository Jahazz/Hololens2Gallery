using Gallery.FlickrAPIIntegration.Client;
using Gallery.FlickrAPIIntegration.Endpoints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Codebase.Utils;

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

        public ImageRequest RequestImageFromUrl (string urlToImage, Action<Sprite> callback)
        {
            ImageRequest request = new ImageRequest(urlToImage, callback);
            ImageRequestQueue.Enqueue(request);

            if (IsRequestCoroutineRunning == false)
            {
                StartCoroutine(HandleImageRequestQueue());
            }
            return request;
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
            Sprite downloadOutput = null;

            while (ImageRequestQueue.Count > 0)
            {
                ImageRequest currentRequest = ImageRequestQueue.Dequeue();

                if (currentRequest.IsRequestActive == true)
                {
                    downloadOutput = Utils.Texture2DToSprite(currentRequest.DownloadImage());
                    currentRequest.Callback.Invoke(downloadOutput);
                }
            }

            IsRequestCoroutineRunning = false;
        }
    }
}
