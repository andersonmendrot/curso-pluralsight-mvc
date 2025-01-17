﻿using SistemaLojaMVC.Models;
using System.Collections.Generic;

namespace SistemaLojaMVC.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
