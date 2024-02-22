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
        if (topLevel == null) return;
        var file = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Imagen a extraer",
            AllowMultiple = false,
            FileTypeFilter = new[]{ FilePickerFileTypes.ImageAll }
        });

        if (file.Count < 1) return;
        var stream = await file[0].OpenReadAsync();
        View.Img.Source = new Bitmap(stream);
    }
}
