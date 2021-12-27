using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using GraphStudy.Models;
using Avalonia.Media;

namespace GraphStudy.ViewModels
{
    public class MatrixElement : ReactiveObject
    {
        Node m_row;
        Node m_column;

        public MatrixElement(Node row, Node column)
        {
            m_row = row;
            m_column = column;

            if (row == column)
            {
                Value = "0";
            }
            else
            {
                Edge? edge = row.Edges.FirstOrDefault(x => ReferenceEquals(x.Node, column));
                if (null != edge)
                    Value = ((int)(edge.Cost)).ToString();
                else
                    Value = "-";
            }
        }

        public String Value
        {
            get;
            set;
        }

        public FontWeight Boldness
        {
            get 
            {
                if (State.Instance.Selected(m_row) && State.Instance.Selected(m_column))
                    return FontWeight.Bold;
                return FontWeight.Normal;
            }
        }

        public virtual void Update()
        {
            this.RaisePropertyChanged("Boldness");
        }
    }
}
