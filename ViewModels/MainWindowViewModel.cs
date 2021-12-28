using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using GraphStudy.Models;

namespace GraphStudy.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Generate = ReactiveCommand.Create(GenerateExecuted);
            Run = ReactiveCommand.Create(RunExecuted);
            Reset = ReactiveCommand.Create(ResetExecuted);
        }

        public ReactiveCommand<Unit, Unit> Generate { get; }
        public ReactiveCommand<Unit, Unit> Run { get; }
        public ReactiveCommand<Unit, Unit> Reset { get; }

        void GenerateExecuted()
        {
            State.Instance.Reset();
            
            Nodes = new ObservableCollection<Node>((new Generator()).Generate());

            Graph.Refresh();
            Matrix.Refresh();
        }

        void RunExecuted()
        {
            State.Instance.DeSelect();

            Graph.Refresh();
            Matrix.Refresh();

            Algorithm? algorithm = Algorithm.Create(State.Instance, Settings.Algorithm);
            if (null == algorithm)
                return;

            algorithm.Execute(Nodes);

            Graph.Refresh();
            Matrix.Refresh();
        }

        void ResetExecuted()
        {
            State.Instance.Reset();

            Graph.Refresh();
            Matrix.Refresh();
        }

        ObservableCollection<Node> m_nodes = new ObservableCollection<Node>();
        public ObservableCollection<Node> Nodes
        {
            get { return m_nodes; }
            private set { if (value != m_nodes) { this.RaiseAndSetIfChanged(ref m_nodes, value); NodesChanged(); } }
        }

        GraphViewModel? m_graph;
        public GraphViewModel Graph
        {
            get 
            {
                if (null == m_graph)
                    m_graph = new GraphViewModel(Nodes);
                return m_graph; 
            }
        }

        MatrixViewModel? m_matrix;
        public MatrixViewModel Matrix
        {
            get
            {
                if (null == m_matrix)
                    m_matrix = new MatrixViewModel(Nodes);
                return m_matrix;
            }
        }

        SettingsViewModel m_settings = new SettingsViewModel();
        public SettingsViewModel Settings
        {
            get { return m_settings; }
        }

        void NodesChanged()
        {
            Graph.Nodes = Nodes;
            Matrix.Nodes = Nodes;
        }
    }
}
