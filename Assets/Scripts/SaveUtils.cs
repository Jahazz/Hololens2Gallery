using Gallery.GUI;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Gallery.Saving
{
    public static class SaveUtils
    {
        private const string PNG_EXTENSION = ".png";
        private const string PNG_WILDCARD = "*.png";
        private const string SAVE_DIRECTORY = "save";

        public static void SaveCurrentPhotos (List<SingleImageData> listToSave)
        {
            string path = Path.Combine(Application.persistentDataPath, SAVE_DIRECTORY);
            SavePhotos(ComposePhotoList(listToSave), path);
        }

        public static List<SingleImageData> LoadImages ()
        {
            return LoadPhotos(Path.Combine(Application.persistentDataPath, SAVE_DIRECTORY));
        }

        private static List<Sprite> ComposePhotoList (List<SingleImageData> elementList)
        {
            List<Sprite> output = new List<Sprite>();
            Sprite biggerSprite;

            foreach (SingleImageData singleElement in elementList)
            {
                biggerSprite = singleElement.MediumSprite != null ? singleElement.MediumSprite : singleElement.ThumbnailSprite;
                output.Add(biggerSprite);
            }

            return output;
        }

        private static void SavePhotos (List<Sprite> photoListToSave, string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            Directory.CreateDirectory(path);
            int i = 0;

            foreach (Sprite singlePhoto in photoListToSave)
            {
                SavePhoto(path, i+++ PNG_EXTENSION, singlePhoto);
            }
        }


        private static void SavePhoto (string path, string fileName, Sprite spriteToSave)
        {
            using (FileStream file = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                byte[] pngEncodedSprite = spriteToSave.texture.EncodeToPNG();
                file.Write(pngEncodedSprite, 0, pngEncodedSprite.Length);
            }
        }

        public static List<SingleImageData> LoadPhotos (string path)
        {
            List<SingleImageData> output = new List<SingleImageData>();
            DirectoryInfo currentDirectory = new DirectoryInfo(path);

            foreach (FileInfo file in currentDirectory.GetFiles(PNG_WILDCARD))
            {
                output.Add(new SingleImageData(LoadPhoto(path, file.FullName)));
            }

            return output;
        }

        private static Sprite LoadPhoto (string path, string filename)
        {
            Sprite output = null;

            using (FileStream file = new FileStream(Path.Combine(path, filename), FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] pngEncodedSprite = new byte[file.Length];
                file.Read(pngEncodedSprite, 0, pngEncodedSprite.Length);
                Texture2D texture = new Texture2D(1, 1);
                ImageConversion.LoadImage(texture, pngEncodedSprite);
                output = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width, texture.height) / 2);
            }

            return output;
        }
    }
}

