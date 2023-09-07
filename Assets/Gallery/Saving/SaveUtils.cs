using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Gallery.Data;
using Gallery.Saving.Data;
using Codebase.IO;
using Codebase.IO.Xml;
using System;

namespace Gallery.Saving
{
    public static class SaveUtils
    {
        private const string PNG_EXTENSION = ".png";
        private const string PNG_WILDCARD = "*.png";
        private const string SAVE_DIRECTORY = "save";
        private const string SAVE_NAME_SEPARATOR = "_";
        private const string THUMBNAIL_SUFFIX = "thumbnail";
        private const string PROPER_IMAGE_SUFFIX = "proper";
        private const string SAVED_IMAGE_FILENAME_FORMAT = "{0}{1}{2}{3}";//filename, separator, suffix, extension
        private const string XML_FILENAME = "save.xls";

        public static SaveOutputType SaveCurrentPhotos (List<SinglePhotoData> listToSave)
        {
            SaveOutputType outputType = SaveOutputType.OK;

            if (listToSave != null && listToSave.Count > 0)
            {
                try
                {
                    string path = GetSavePath();

                    DeleteOldSaveIfExists(path);
                    Directory.CreateDirectory(path);

                    GallerySaveData saveData = SavePhotos(listToSave, path);

                    XMLUtils.SerializeAndSave(saveData, path, XML_FILENAME);
                }
                catch (Exception exceptionData)
                {
                    
                }
            }
            else
            {
                outputType = SaveOutputType.EMPTY_GALLERY;
            }

            return outputType;
        }

        public static LoadOutputType LoadImages (out List<SinglePhotoData> output)
        {
            LoadOutputType outputType = LoadOutputType.OK;
            output = new List<SinglePhotoData>();

            string path = GetSavePath();

            if (InputOutput.FileExists(path, XML_FILENAME) == true)
            {
                try
                {
                    SinglePhotoData singlePhotoData;
                    GallerySaveData saveData = XMLUtils.LoadAndDeserialize<GallerySaveData>(path, XML_FILENAME);

                    foreach (PhotoSaveData photoData in saveData.PhotosInGalleryCollection)
                    {
                        singlePhotoData = new SinglePhotoData(
                            GetImageDataFromSaveData(photoData.ThumbnailImage),
                            GetImageDataFromSaveData(photoData.ProperImage),
                            photoData.Title,
                            photoData.ID
                            );
                        output.Add(singlePhotoData);
                    }
                }
                catch (Exception exceptionData)
                {
                    Debug.LogError(exceptionData.Message);
                    outputType = LoadOutputType.UNKNOWN_ERROR;
                }
            }
            else
            {
                outputType = LoadOutputType.NO_SAVE;
            }

            return outputType;
        }

        private static ImageData GetImageDataFromSaveData (SingleImageSaveData imageSaveData)
        {
            ImageData output = new ImageData(imageSaveData.Url);

            if (imageSaveData.Filename != null)
            {
                output.Sprite = GetSpriteFromPngByteArray(InputOutput.LoadBytes(GetSavePath(), imageSaveData.Filename));
            }

            return output;
        }

        private static string GetSavePath ()
        {
            return Path.Combine(Application.persistentDataPath, SAVE_DIRECTORY);
        }

        private static GallerySaveData SavePhotos (List<SinglePhotoData> listToSave, string path)
        {

            GallerySaveData saveData = new GallerySaveData();

            PhotoSaveData createdPhotoData;

            foreach (SinglePhotoData singlePhoto in listToSave)
            {
                createdPhotoData = new PhotoSaveData();
                createdPhotoData.ID = singlePhoto.ID;
                createdPhotoData.Title = singlePhoto.Title;

                createdPhotoData.ThumbnailImage = SaveSingleImageData(singlePhoto.ThumbnailImage, createdPhotoData.ID, path, THUMBNAIL_SUFFIX);
                createdPhotoData.ProperImage = SaveSingleImageData(singlePhoto.ProperImage, createdPhotoData.ID, path, PROPER_IMAGE_SUFFIX);

                saveData.PhotosInGalleryCollection.Add(createdPhotoData);
            }

            return saveData;
        }

        private static void DeleteOldSaveIfExists (string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        private static string GetFilenameForImage (ulong id, string suffix)
        {
            return string.Format(SAVED_IMAGE_FILENAME_FORMAT, id, SAVE_NAME_SEPARATOR, suffix, PNG_EXTENSION);
        }

        private static SingleImageSaveData SaveSingleImageData (ImageData dataToSave, ulong id, string path, string suffix)
        {
            SingleImageSaveData output = new SingleImageSaveData();

            output.Url = dataToSave.Url;

            if (dataToSave.Sprite != null)
            {
                output.Filename = GetFilenameForImage(id, suffix);
                byte[] bytedSprite = GetSpritePngByteArray(dataToSave.Sprite);
                InputOutput.SaveBytes(bytedSprite, path, output.Filename);
            }

            return output;
        }

        private static byte[] GetSpritePngByteArray (Sprite source)
        {
            return source.texture.EncodeToPNG();
        }

        private static Sprite GetSpriteFromPngByteArray (byte[] source)
        {
            Texture2D texture = new Texture2D(1, 1);
            ImageConversion.LoadImage(texture, source);
            Sprite output = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width, texture.height) / 2);

            return output;
        }
    }
}

