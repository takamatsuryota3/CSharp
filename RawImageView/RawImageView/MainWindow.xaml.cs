using System;
using System.Collections.Generic;
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

namespace RawImageView
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWIndowViewModel vm = null;
        // SettingWindowから受取るもの
        // Width
        public int WidthValue
        {
            set { vm.Width = value; }
        }
        // Height
        public int HeightValue
        {
            set { vm.Height = value; }
        }
        // HeaderSize
        public int HeaderSize
        {
            set { vm.HeaderSize = value; }
        }
        // BitDepth
        public RawInformation.BitDepth BitDepth
        {
            set { vm.BitDepth = value; }
        }
        // BitPosition
        public int BitPosition
        {
            set { vm.BitPosition = value; }
        }
        // Endian
        public int Endian
        {
            set { vm.Endian = value; }
        }
        // HeadColor
        public int HeadColor
        {
            set { vm.HeadColor = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            vm = new MainWIndowViewModel(this);
            vm.CloseAction = new Action(() => this.Close());
            DataContext = vm;
        }
    }
}
