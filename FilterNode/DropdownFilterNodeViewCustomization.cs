using System;
using System.Collections.Generic;
using System.Linq;
using Dynamo.Graph.Nodes;
using Dynamo.UI.Commands;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;

namespace CustomDynamoNodes
{
    [NodeName("Dropdown Filter Node")]
    [NodeCategory("Custom.Nodes")]
    [NodeDescription("Filters a string from a list of strings based on a dropdown selection.")]
    [OutPortNames("Result")]
    [OutPortDescriptions("The filtered string or empty if not found.")]
    [OutPortTypes("string")]
    public class DropdownFilterNode : NodeModel
    {
        private string _selectedItem;
        private List<string> _items;

        [JsonConstructor]
        public DropdownFilterNode()
        {
            RegisterAllPorts();
            Items = new List<string>();
            SelectedItem = string.Empty;
        }

        public List<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
                OnNodeModified();
            }
        }

        public DelegateCommand UpdateItemsCommand => new DelegateCommand(UpdateItems);

        private void UpdateItems(object obj)
        {
            // Populate dropdown with default items
            Items = new List<string> { "Option1", "Option2", "Option3" };
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            if (inputAstNodes == null || inputAstNodes.Count < 1)
                return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };

            var selectedAst = AstFactory.BuildStringNode(SelectedItem);
            var inputList = inputAstNodes[0];
            var resultCondition = AstFactory.BuildFunctionCall(
                new Func<string, List<string>, string>((s, list) => list.Contains(s) ? s : string.Empty),
                new List<AssociativeNode> { selectedAst, inputList });

            return new[]
            {
                AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), resultCondition)
            };
        }
    }
}
