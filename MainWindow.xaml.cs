using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms; // For FolderBrowserDialog

namespace Code_Counter;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        using (var dialog = new FolderBrowserDialog())
        {
            dialog.Description = "选择文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderPath = dialog.SelectedPath;
                FolderPathTextBox.Text = folderPath;

                // Define code file extensions
                var codeExtensions = new HashSet<string> { ".cs", ".cpp", ".h", ".java", ".py", ".js", ".ts", ".html", ".css", ".php", ".rb", ".go", ".rs", ".swift" }; // Add more as needed

                // Count code files and lines
                int fileCount = 0;
                long lineCount = 0;

                try
                {
                    var files = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories)
                        .Where(file => codeExtensions.Contains(System.IO.Path.GetExtension(file).ToLowerInvariant()));

                    foreach (var file in files)
                    {
                        fileCount++;
                        lineCount += File.ReadLines(file).Count();
                    }

                    FileCountTextBlock.Text = $"代码文件数量: {fileCount}";
                    LineCountTextBlock.Text = $"总代码行数: {lineCount}";
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"错误: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}