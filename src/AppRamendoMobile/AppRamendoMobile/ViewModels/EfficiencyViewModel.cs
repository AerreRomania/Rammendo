using AppRammendoMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRammendoMobile.ViewModels
{
    public class EfficiencyViewModel : ViewModelBase
    {
        public IEnumerable<Efficiency> EfficiencyListByHour { get; set; }
        public EfficiencyViewModel()
        {
            EfficiencyListByHour = new List<Efficiency>() 
            { 
                new Efficiency() 
                { 
                    Hour = 1, Good = 2, Eff = 90 
                } ,
                new Efficiency()
                {
                  
                    Hour = 2, Good = 5, Eff = 80
                },
                 new Efficiency()
                { 
                     Hour = 3, Good = 2, Eff = 90
                } ,
                  new Efficiency()
                {
                      Hour = 4, Good = 2, Eff = 90
                } ,
                   new Efficiency()
                {
                       Hour = 5, Good = 2, Eff = 90
                } ,
                    new Efficiency()
                { 
                        Hour = 6, Good = 2, Eff = 90
                } ,
                     new Efficiency()
                { 
                         Hour = 7, Good = 2, Eff = 90
                } ,
                      new Efficiency()
                {
                          Hour = 8, Good = 2, Eff = 90
                } ,
                       new Efficiency()
                {
                           Hour = 9, Good = 2, Eff = 90
                } ,
                        new Efficiency()
                {
                            Hour = 10, Good = 2, Eff = 90
                } ,
                         new Efficiency()
                { 
                             Hour = 11, Good = 2, Eff = 90
                } ,
                          new Efficiency()
                { 
                              Hour = 12, Good = 2, Eff = 90
                } ,
                           new Efficiency()
                { 
                               Hour = 13, Good = 2, Eff = 90
                } ,
                            new Efficiency()
                { 
                                Hour = 14, Good = 2, Eff = 90
                } ,
                             new Efficiency()
                { 
                                 Hour = 15, Good = 2, Eff = 90
                } 
            };
            
           // Eff = new Efficiency();
        }
    }
}
