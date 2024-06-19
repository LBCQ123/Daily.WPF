using Daily.WPF.DTO;
using Prism.Mvvm;
using System.Collections.Generic;

namespace Daily.WPF.ViewModels.UCs
{
    public class WaitUCViewModel : BindableBase
    {
        public WaitUCViewModel()
        {
            _WaitInfos = new List<WaitInfoDTO>()
            {
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
            };
        }

        private List<WaitInfoDTO> _WaitInfos;

        public List<WaitInfoDTO> WaitInfos
        {
            get { return _WaitInfos; }
            set => SetProperty(ref _WaitInfos, value);
        }



    }
}
