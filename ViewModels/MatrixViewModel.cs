using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class MatrixViewModel : ViewModelBase
    {
        public MatrixViewModel(IEnumerable<Node> nodes)
        {
            Nodes = new ObservableCollection<Node>(nodes);
        }

        public void Refresh()
        {
            foreach (MatrixElement element in Elements)
                element.Update();
        }

        ObservableCollection<Node> m_nodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> Nodes
        {
            get { return m_nodes; }
            set { if (value != m_nodes) { this.RaiseAndSetIfChanged(ref m_nodes, value); ReCreatePresentation(); } }
        }

        ObservableCollection<MatrixElement> m_elements = new ObservableCollection<MatrixElement>();
        public ObservableCollection<MatrixElement> Elements
        {
            get { return m_elements; }
            set { if (value != m_elements) { this.RaiseAndSetIfChanged(ref m_elements, value); } }
        }

        void ReCreatePresentation()
        {
            List<MatrixElement> elements = new List<MatrixElement>();
            foreach (Node y in m_nodes)
            {
                foreach (Node x in m_nodes)
                    elements.Add(new MatrixElement(x, y));
            }

            Elements = new ObservableCollection<MatrixElement>(elements);
        }
    }
}
