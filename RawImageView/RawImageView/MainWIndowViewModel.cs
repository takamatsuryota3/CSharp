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
                SettingWindow sw = new SettingWindow();
                sw.Title = Path.GetFileName( dialog.FileName);
                sw.ShowDialog();
            }
        }

        private void ShowRawImage(string fileName)
        {
            MessageBox.Show(fileName);
        }

        private void ReadRaw(string fileName)
        {

        }
        #endregion
    }
}
