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
            Generate = ReactiveCommand.Create(GenerateGraph);
        }

        public string Greeting => "Welcome to Avalonia!";

        public ReactiveCommand<Unit, Unit> Generate { get; }

        void GenerateGraph()
        {
            Nodes = new ObservableCollection<Node>((new Generator()).Generate());
        }

        ObservableCollection<Node> m_nodes = new ObservableCollection<Node>((new Generator()).Generate());
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

        SettingsViewModel m_settings = new SettingsViewModel();
        public SettingsViewModel Settings
        {
            get { return m_settings; }
        }

        void NodesChanged()
        {
            Graph.Nodes = Nodes;
        }
    }
}
