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
                new WaitInfoDTO(1,"A1","AA1",0),
                new WaitInfoDTO(2,"A2","AA2",0),
                new WaitInfoDTO(3,"A3","AA3",0),
                new WaitInfoDTO(4,"A4","AA4",0),
                new WaitInfoDTO(5,"A5","AA5",0),
                new WaitInfoDTO(6,"A6","AA6",0),
                new WaitInfoDTO(7,"A7","AA7",0),
                new WaitInfoDTO(8,"A8","AA8",0),
                new WaitInfoDTO(9,"A9","AA9",0),
                new WaitInfoDTO(10,"A10","AA10",0),
                new WaitInfoDTO(11,"A11","AA11",0),
                new WaitInfoDTO(12,"A12","AA12",0),
                new WaitInfoDTO(13,"A13","AA13",0),
                new WaitInfoDTO(14,"A14","AA14",0),
                new WaitInfoDTO(15,"A15","AA15",0),
                new WaitInfoDTO(16,"A16","AA16",0),
                new WaitInfoDTO(17,"A17","AA17",0),
                new WaitInfoDTO(18,"A18","AA18",0),
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
