using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVMBase;

namespace RawImageView
{
    class MainWIndowViewModel:ViewModelBase
    {

        #region 
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
        #endregion

        #region Constructor
        public MainWIndowViewModel(MainWindow main)
        {

        }
        #endregion

        #region Private Method
        private void OnOpenCommand()
        {
            MessageBox.Show("Hello World!");
        }
        #endregion
    }
}
