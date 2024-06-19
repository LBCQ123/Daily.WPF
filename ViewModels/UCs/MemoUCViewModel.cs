using Daily.WPF.DTO;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.ViewModels.UCs
{
    public class MemoUCViewModel : BindableBase
    {

        public MemoUCViewModel()
        {
            _MemoInfos = new List<MemoInfoDTO>()
            {
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
            };
        }


        private List<MemoInfoDTO> _MemoInfos;

        public List<MemoInfoDTO> MemoInfos
        {
            get { return _MemoInfos; }
            set => SetProperty(ref _MemoInfos, value);
        }



    }
}
