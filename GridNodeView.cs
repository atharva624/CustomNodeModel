using Dynamo.Controls;
using Dynamo.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

//namespace CustomNodeModel
//{
//    internal class GridNodeView
//    {
//    }
//}

namespace CustomNodeModel.CustomNodeModel
{
    public class CustomNodeModelView : INodeViewCustomization<GridNodeModel>
    {
        public void CustomizeView(GridNodeModel model, NodeView nodeView)
        {
            //var slider = new Slider();
            var sliderControl = new SliderControl();
            sliderControl.DataContext = model; // Bind the model as DataContext
            nodeView.inputGrid.Children.Add(sliderControl);

            //var slider = new CustomNodeModel.Slider();
            //nodeView.inputGrid.Children.Add(slider);
            //slider.DataContext = model;
            if (model == null || nodeView == null)
            {
                return; // Exit early if the model or node view is null
            }

            // Create a slider and bind it to the model
            //var slider = new Slider
            //{
            //    Minimum = 0,
            //    Maximum = 100, // Adjust as needed
            //    Value = model.SliderValue // Bind to the model's property
            //};

            //slider.ValueChanged += (sender, args) =>
            //{
            //    model.SliderValue = slider.Value;
            //    model.OnNodeModified(false); // Notify the node of changes
            //};

            //nodeView.inputGrid.Children.Add(slider);
            //slider.DataContext = model;
        }

        public void Dispose()
        {
        }
    }
}