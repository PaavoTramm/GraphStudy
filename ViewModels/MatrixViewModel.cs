using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class MatrixViewModel : ViewModelBase
    {
        public MatrixViewModel(IEnumerable<Node> nodes)
        {
            Nodes = new ObservableCollection<Node>(nodes);
        }

        public ObservableCollection<Node> Nodes { get; }
    }
}
