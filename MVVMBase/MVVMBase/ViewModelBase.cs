using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Windows.Input;

namespace MVVMBase
{
    #region Class : ViewModelBase
    /// <summary>
    /// ViewModel Base
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        #region INotifyProopertyChanged API
        /// <summary>
        /// INotifyPropertyChangedの実装
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// INotifyPropertyChanged.PropertyChangedイベントを発生させる
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IDataErrorInfo API
        /// <summary>
        /// IDataErrorInfo用のエラーメッセージを保持する辞書
        /// </summary>
        private Dictionary<string, string> ErrorMessages = new Dictionary<string, string>();

        /// <summary>
        /// IDaraErrorInfo.Errorの実装
        /// </summary>
        string IDataErrorInfo.Error
        {
            get => (ErrorMessages.Count > 0) ? "Has Error" : null;
        }

        /// <summary>
        /// IDataErrorInfo.Itemの実装
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (ErrorMessages.ContainsKey(columnName))
                    return ErrorMessages[columnName];
                else
                    return null;
            }
        }
        /// <summary>
        /// エラー情報が更新された時に発生するイベント
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// ErrorsChangedのイベントを発生させる
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaiseErrorChanged([CallerMemberName]string propertyName = "")
        {
            var h = this.ErrorsChanged;
            if (h != null)
            {
                h(this, new DataErrorsChangedEventArgs(propertyName));
            }

        }

        /// <summary>
        /// エラーメッセージを取得する
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return null;
            if (!ErrorMessages.ContainsKey(propertyName)) return null;
            return ErrorMessages[propertyName];
        }

        /// <summary>
        /// エラーメッセージの有無
        /// </summary>
        public bool HasErrors
        {
            get => ErrorMessages.Values.Any(x => x != null);
        }

        #endregion
    }
    #endregion
}
