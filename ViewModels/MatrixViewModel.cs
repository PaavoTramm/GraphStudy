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

        public bool Populated
        {
            get { return Elements != null && Elements.Count > 0; }
        }

        public String Description
        {
            get
            {
                if (m_nodes == null || m_nodes.Count == 0)
                    return "No values";
                if(m_nodes.Count > 50)
                    return "Matrix too large";
                return $"{m_nodes.Count} by {m_nodes.Count} matrix";
            }
        }

        ObservableCollection<Node> m_nodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> Nodes
        {
            get { return m_nodes; }
            set { if (value != m_nodes) { this.RaiseAndSetIfChanged(ref m_nodes, value); ReCreatePresentation(); } }
        }

        ObservableCollection<MatrixElement>? m_elements;
        public ObservableCollection<MatrixElement> Elements
        {
            get 
            {
                if (m_elements == null)
                    m_elements = CreatePresentation();
                return m_elements; 
            }

            set 
            { 
                if (value != m_elements) 
                { 
                    this.RaiseAndSetIfChanged(ref m_elements, value); 
                } 
            }
        }

        ObservableCollection<MatrixElement> CreatePresentation()
        {
            List<MatrixElement> elements = new List<MatrixElement>();

            if (m_nodes.Count <= 50)
            {
                foreach (Node y in m_nodes)
                {
                    foreach (Node x in m_nodes)
                        elements.Add(new MatrixElement(x, y));
                }
            }
            return new ObservableCollection<MatrixElement>(elements);
        }

        void ReCreatePresentation()
        {
            if(m_elements != null)
                Elements = CreatePresentation();

            this.RaisePropertyChanged("Populated");
            this.RaisePropertyChanged("Description");
        }
    }
}
