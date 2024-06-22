﻿using Daily.WPF.DTO;
using Daily.WPF.Services;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Daily.WPF.ViewModels.Dialogs
{
    public class AddMemoUCViewModel :BindableBase, IDialogHostAware
    {
        public AddMemoUCViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private MemoInfoDTO _MemoInfoDTO = new MemoInfoDTO();

        public MemoInfoDTO MemoInfoDTO
        {
            get { return _MemoInfoDTO; }
            set => SetProperty(ref _MemoInfoDTO, value);
        }


        /// <summary>
        /// 保存命令
        /// </summary>
        public DelegateCommand SaveCommand { get; set; }

        /// <summary>
        /// 取消命令
        /// </summary>
        public DelegateCommand CancelCommand { get; set; }

        /// <summary>
        /// 要被注入的主机名
        /// </summary>
        public string DailogHostName { get; set; } = string.Empty;

        private void Save()
        {
            if(string.IsNullOrEmpty(MemoInfoDTO.Content) == true 
                || string.IsNullOrEmpty(MemoInfoDTO.Title) == true)
            {
                MessageBox.Show("标题和内容不能为空");
                return;
            }
            
            if (DialogHost.IsDialogOpen(DailogHostName))
            {
                IDialogResult para = new DialogResult(ButtonResult.OK);
                para.Parameters.Add("MemoInfoDTO", MemoInfoDTO);
                DialogHost.Close(DailogHostName, para);
            }
        }

        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DailogHostName))
            {
                DialogHost.Close(DailogHostName, new DialogResult(ButtonResult.No));
            }
        }

        /// <summary>
        /// 打开时传入参数
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpening(IDialogParameters parameters)
        {
            
        }



    }
}
