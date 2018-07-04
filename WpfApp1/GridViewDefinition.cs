using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class GridViewDefinition : ViewDefinition
    {
        public object RelationalColumn
        {
            get => GetValue(RelationalColumn_Property);
            set => SetValue(RelationalColumn_Property, value);
        }
        public static readonly DependencyProperty RelationalColumn_Property =
            DependencyProperty.Register("RelationalColumn", typeof(object), typeof(GridViewDefinition));
        public CustomDataGrid DataGrid
        {
            get => (CustomDataGrid)GetValue(DataGrid_Property);
            set => SetValue(DataGrid_Property, value);
        }
        public static readonly DependencyProperty DataGrid_Property = 
            DependencyProperty.Register("DataGrid", typeof(CustomDataGrid), typeof(GridViewDefinition));
    }
}
