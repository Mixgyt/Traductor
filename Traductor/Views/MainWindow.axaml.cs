using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;

namespace Traductor.Views;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        Loaded += LoadWindow;
    }

    private void LoadWindow(object? sender, RoutedEventArgs e)
    {
        View.SearchFileBt.Click += SelectImage;
    }

    private async void SelectImage(object? sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        var file = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Imagen a extraer",
            AllowMultiple = false,
            
        });

        if (file.Count >= 1)
        {
            byte[] fs = File.ReadAllBytes("../../../../Traductor/Assets/debug/test.png");
            Stream st = new MemoryStream(fs);
            var image = new Avalonia.Media.Imaging.Bitmap(st);
            View.Img.Source = image;
        }
    }
}
