namespace Proyecto_Turismo.UI.Helpers
{
    public static class ImageHelper
    {
        public static string GetImageMimeType(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length < 4)
                return null;

            if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
                return "image/png";
            if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8)
                return "image/jpeg";
            if (imageBytes[0] == 0x47 && imageBytes[1] == 0x49 && imageBytes[2] == 0x46)
                return "image/gif";
            if (imageBytes[0] == 0x42 && imageBytes[1] == 0x4D)
                return "image/bmp";
            if (imageBytes[0] == 0x49 && imageBytes[1] == 0x49 && imageBytes[2] == 0x2A)
                return "image/tiff";
            if (imageBytes[0] == 0x4D && imageBytes[1] == 0x4D && imageBytes[2] == 0x2A)
                return "image/tiff";

            return null;
        }
    }
}
