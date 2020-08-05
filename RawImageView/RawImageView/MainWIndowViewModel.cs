using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVMBase;
using Microsoft.Win32;
using System.IO;

namespace RawImageView
{
    class MainWIndowViewModel:ViewModelBase
    {
        MainWindow mainWindow = null;

        #region Property
        private int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged("Width");
            }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        private int _headerSize;
        public int HeaderSize
        {
            get { return _headerSize; }
            set
            {
                _headerSize = value;
                RaisePropertyChanged("HeaderSize");
            }
        }

        private RawInformation.BitDepth _bitDepth;
        public RawInformation.BitDepth BitDepth
        {
            get { return _bitDepth; }
            set
            {
                _bitDepth = value;
                RaisePropertyChanged("BitDepth");
            }
        }

        private int _bitPosition;
        public int BitPosition
        {
            get { return _bitPosition; }
            set
            {
                _bitPosition = value;
                RaisePropertyChanged("BitPosition");
            }
        }

        private int _endian;
        public int Endian
        {
            get { return _endian; }
            set
            {
                _endian = value;
                RaisePropertyChanged("Endian");
            }
        }

        private int _headColor;
        public int HeadColor
        {
            get { return _headColor; }
            set
            {
                _headColor = value;
                RaisePropertyChanged("HeadColor");
            }
        }

        #endregion

        #region DelegateCommand
        private DelegateCommand _openCommnad;
        public DelegateCommand OpenCommand
        {
            get
            {
                if (_openCommnad == null)
                {
                    _openCommnad = new DelegateCommand(
                        ()=> { OnOpenCommand(); });
                }
                return _openCommnad;
            }
        }

        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new DelegateCommand(
                        () => { CloseAction?.Invoke(); });
                }
                return _closeCommand;
            }
        }
        #endregion

        #region Action
        public Action CloseAction { get; set; }
        #endregion

        #region Constructor
        public MainWIndowViewModel(MainWindow main)
        {
            mainWindow = main;
        }
        #endregion

        #region Private Method
        private void OnOpenCommand()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter= "RAWファイル (*.raw)|*.raw|TIFファイル (*.tif)|*.tif";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SettingWindow sw = new SettingWindow
                {
                    Owner = mainWindow
                };
                sw.Title = Path.GetFileName( dialog.FileName);
                sw.Show();
            }
        }

        private void ShowRawImage(string fileName)
        {
            MessageBox.Show(fileName);
        }

        private ushort[] ReadRaw(string fileName, int width, int height, int endian, RawInformation.BitDepth bitDepth, int bitPosition)
        {
            // Ushort型の配列を定義
            ushort[] result = new ushort[width * height];
            // Ushort型の変数を定義
            ushort val = 0;

            int depth = (int)bitDepth;
            int shift = 16 - depth;

            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            for (int i = 0; i < result.Length; i++)
            {
                // Endianに応じて処理
                if (endian == (int)RawInformation.Endian.LITTLE)
                {
                    val = (ushort)(br.ReadByte() >> 1 + br.ReadByte());
                }
                else if (endian == (int)RawInformation.Endian.BIG)
                {
                    val = (ushort)(br.ReadByte() + br.ReadByte() >> 1);
                }
                // BitPositionに応じて処理
                if (bitPosition == (int)RawInformation.BitPosition.LSB)
                {
                    // 何もしない
                }
                else if (bitPosition == (int)RawInformation.BitPosition.MSB)
                {

                }
                // BitDepthに応じてシフト処理
                val = (ushort)(val >> shift);
            }

            // Ushort型の配列をリターン
            return result;
        }
        #endregion
    }
}
