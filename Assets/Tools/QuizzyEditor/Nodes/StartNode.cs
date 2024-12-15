using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using System;

namespace QuizGraphEditor
{
    public class StartNode : Node
    {
        public string GUID { get; private set; }

        public StartNode()
        {
            InitializeNode();
        }

        public StartNode(StartNodeData data)
        {
            InitializeNode();

            // Load data
            GUID = data.GUID;
            SetPosition(new Rect(data.Position, Vector2.zero));
            ApplyColorPreferences();
        }

        private void InitializeNode()
        {
            title = "Start";
            GUID = Guid.NewGuid().ToString();
            Debug.Log("Node " + this.title + " GUID: " + GUID);
            capabilities = Capabilities.Movable | Capabilities.Selectable;

            // Create a single output port
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            outputPort.portName = "Start Quiz";
            outputPort.name = outputPort.portName; // For serialization
            outputContainer.Add(outputPort);
            AddToClassList("start-node");

            RefreshExpandedState();
            RefreshPorts();
            ApplyColorPreferences();
        }
        public void ApplyColorPreferences()
        {
            style.backgroundColor = UserPreferences.StartNodeColor;
        }
        public StartNodeData GetData()
        {
            return new StartNodeData
            {
                GUID = GUID,
                Position = GetPosition().position
            };
        }
    }
}
