﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public int Count
        {
            get { return Models.Settings.Instance.Nodes; }
            set { Models.Settings.Instance.Nodes = value; }
        }
        public int Edges
        {
            get { return Models.Settings.Instance.Edges; }
            set { Models.Settings.Instance.Edges = value; }
        }
    }
}
