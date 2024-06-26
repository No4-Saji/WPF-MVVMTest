﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MVVMTest.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        private string _value1;
        ///<summary>
        ///入力値１
        ///</summary>
        public string Value1
        {
            get => _value1;
            set
            {
                SetProperty(ref _value1, value);
                CalculateCommand?.NotifyCanExecuteChanged();
            }
        }

        private string _value2;
        ///<summary>
        ///入力値２
        ///</summary>
        public string Value2
        {
            get => _value2;
            set
            {
                SetProperty(ref _value2, value);
                CalculateCommand?.NotifyCanExecuteChanged();
            }
        }
        private string _result;
        /// <summary>
        /// 計算結果
        /// </summary>
        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public IRelayCommand CalculateCommand { get; }

        ///<summary>
        ///コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            CalculateCommand = new RelayCommand(
                execute: () =>
                {
                    try
                    {
                        Result = $"{Value1} + {Value2} = {int.Parse(Value1) + int.Parse(Value2)}";
                    }
                    catch
                    {
                        Result = "Error!";
                    }
                },
                canExecute: () =>
                {
                    return !string.IsNullOrEmpty(Value1) && !string.IsNullOrEmpty(Value2);
                });
        }
    }
}
