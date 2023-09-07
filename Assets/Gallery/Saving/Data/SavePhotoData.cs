namespace Gallery.Saving.Data
{
    public class SavePhotoData 
    {
        public SingleSaveImageData ThumbnailImage { get; set; }
        public SingleSaveImageData ProperImage { get; set; }
        public string Title { get; set; }
        public ulong ID { get; set; }
    }
}
