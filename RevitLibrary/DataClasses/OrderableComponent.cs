using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevitLibrary.DataClasses
{
    class OrderableComponent
    {
        private List<BuildingComponent> preds;
        private List<BuildingComponent> succs;

        public List<BuildingComponent> Predecessors 
        {
            get
            {
                return preds;
            }
            set
            {
                preds = value;
            }
        }
        public List<BuildingComponent> Successors
        {
            get
            {
                return succs;
            }
            set
            {
                succs = value;
            }
        }
    }
}
