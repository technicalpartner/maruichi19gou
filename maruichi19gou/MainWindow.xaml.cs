using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace maruichi19gou
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static RoutedCommand OpenFile1Command = new RoutedCommand();
        public static RoutedCommand OpenFile2Command = new RoutedCommand();
        public static RoutedCommand OutputFileCommand = new RoutedCommand();
        public static RoutedCommand OutputCommand = new RoutedCommand();
        public static RoutedCommand CloseCommand = new RoutedCommand();

        public string OpenFile1Path { get; set; }
        public string OpenFile2Path { get; set; }
        public string OutputFilePath { get; set; }

        public string Version
        {
            get
            {
                //自分自身のAssemblyを取得
                System.Reflection.Assembly asm =
                    System.Reflection.Assembly.GetExecutingAssembly();
                //バージョンの取得
                System.Version ver = asm.GetName().Version;
                return $"{ver.Major:000}.{ver.Minor:000}.{ver.Build:000}.{ver.Revision:000}";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenFile1CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                OpenFile1Path = dialog.FileName;
                OnPropertyChanged(nameof(OpenFile1Path));
            }
        }
        private void OpenFile2CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                OpenFile2Path = dialog.FileName;
                OnPropertyChanged(nameof(OpenFile2Path));
            }
        }
        private void OutputFileCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                OutputFilePath = dialog.FileName;
                OnPropertyChanged(nameof(OutputFilePath));
            }
        }
        private void OutputCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new Exception("入力ファイル:xxxxxx.csv 行番号 : 99 の振り分けに失敗しました。");

            using (var adapter = new Adapters.FileMargeAdapter())
            {
                MessageBox.Show("完了しました。");
            }
        }
        private void CloseCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
