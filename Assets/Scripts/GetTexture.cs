using UnityEngine;
using System.IO;
using System.Net.Mime;

public class GetTexture : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    
    public void SaveToGallery() {
        
        // Получаем текстуру для сохранения
        Texture2D texture = GetTextureToSave();

        NativeGallery.SaveImageToGallery(texture, "AndroidPuzzle",
            $"Game_{System.DateTime.Now.ToString("MM-dd-yy(HH-mm-ss)")}.png");
        // Создаем путь для сохранения изображения
        /*string path = Path.Combine(Application.persistentDataPath, $"Game_{System.DateTime.Now.ToString("MM-dd-yy(HH-mm-ss)")}.png");

        // Сохраняем изображение в указанном пути
        File.WriteAllBytes(path, texture.EncodeToPNG());

        
        // Обновляем галерею, чтобы отобразить сохраненное изображение
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        mediaScanner.CallStatic("scanFile", new object[] { path, $"Game_{System.DateTime.Now.ToString("MM-dd-yy(HH-mm-ss)")}.png" }, null, null);*/
    }

    private Texture2D GetTextureToSave() {
        // Здесь должен быть код для получения текстуры, которую нужно сохранить
        return _texture;
    }
}