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

            Message = "Click 'Generate' to build random node tree";
        }

        public ReactiveCommand<Unit, Unit> Generate { get; }
        public ReactiveCommand<Unit, Unit> Run { get; }
        public ReactiveCommand<Unit, Unit> Reset { get; }

        void GenerateExecuted()
        {
            State.Instance.Reset();

            Generator generator = new Generator();

            Nodes = new ObservableCollection<Node>(generator.Generate());

            Graph.Refresh();
            Matrix.Refresh();
            
            if(Nodes.Count == 0)
                Message = "Generator did not produce any nodes";
            else
                Message = $"Generated tree with {Nodes.Count} vertices";
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

            Message = $"{Settings.Algorithm} selected {State.Instance.Nodes} vertices";
        }

        void ResetExecuted()
        {
            State.Instance.Reset();

            Graph.Refresh();
            Matrix.Refresh();

            Message = $"Selection cleared";
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

        String m_message = "";
        public String Message
        {
            get { return m_message; }
            private set { if (value != m_message) { this.RaiseAndSetIfChanged(ref m_message, value); } }
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
