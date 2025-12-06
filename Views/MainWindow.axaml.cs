using Avalonia.Controls;

namespace DSBattery.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_OnClosing(object? sender, WindowClosingEventArgs e)
    {
        // Impede o fechamento
        e.Cancel = true;

        // Esconde a janela (vai para a tray)
        Hide();
    }
}