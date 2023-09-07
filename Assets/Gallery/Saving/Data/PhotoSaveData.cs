namespace Gallery.Saving.Data
{
    public class PhotoSaveData 
    {
        public SingleImageSaveData ThumbnailImage { get; set; }
        public SingleImageSaveData ProperImage { get; set; }
        public string Title { get; set; }
        public ulong ID { get; set; }
    }
}
