using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup.Primitives;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CustomDataGrid.xaml
    /// </summary>
    public partial class CustomDataGrid : DataGrid, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property)); }

        private List<DataGridRow> _ListDataGridRows;
        public List<DataGridRow> ListDataGridRows { get => _ListDataGridRows; set { _ListDataGridRows = value; RaisePropertyChanged("ListDataGridRows"); } }

        public DetailsViewDefinition DetailsViewDefinition
        {
            get => (DetailsViewDefinition)GetValue(DetailsViewDefinitionProperty);
            set => SetValue(DetailsViewDefinitionProperty, value);
        }
        public static readonly DependencyProperty DetailsViewDefinitionProperty = DependencyProperty.Register(
            "DetailsViewDefinition",
            typeof(DetailsViewDefinition),
            typeof(CustomDataGrid),
            new PropertyMetadata(new DetailsViewDefinition())
        );

        public CustomDataGrid()
        {
            InitializeComponent();
        }

        ControlTemplate CreateControlTemplate(string itemSource)
        {
            ControlTemplate template = new ControlTemplate();
            // Create Grid Parent
            FrameworkElementFactory grid_Parent = new FrameworkElementFactory(typeof(Grid));
            // RowDefinition of Grid
            FrameworkElementFactory grid_RowDefinition_Parent_Auto = new FrameworkElementFactory(typeof(RowDefinition));
            FrameworkElementFactory grid_RowDefinition_Parent_Star = new FrameworkElementFactory(typeof(RowDefinition));
            grid_RowDefinition_Parent_Auto.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Auto));
            grid_RowDefinition_Parent_Star.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Star));
            grid_Parent.AppendChild(grid_RowDefinition_Parent_Auto);
            grid_Parent.AppendChild(grid_RowDefinition_Parent_Star);
            // Border of Grid
            FrameworkElementFactory border_grid_Parent = new FrameworkElementFactory(typeof(Border));
            border_grid_Parent.SetValue(Grid.RowProperty, 0);
            border_grid_Parent.SetValue(Border.SnapsToDevicePixelsProperty, true);
            border_grid_Parent.SetValue(Border.BorderBrushProperty, new TemplateBindingExtension(DataGridRow.BorderBrushProperty));
            border_grid_Parent.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(DataGridRow.BorderThicknessProperty));
            border_grid_Parent.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(DataGridRow.BackgroundProperty));
            // SelectiveScrollingGrid
            FrameworkElementFactory selectiveScrollingGrid_border_grid_Parent = new FrameworkElementFactory(typeof(SelectiveScrollingGrid));
            // ColumnDefinition of SelectiveScrollingGrid
            FrameworkElementFactory selectiveScrollingGrid_ColumnDefinition_Parent_Auto = new FrameworkElementFactory(typeof(ColumnDefinition));
            FrameworkElementFactory selectiveScrollingGrid_ColumnDefinition_Parent_Star = new FrameworkElementFactory(typeof(ColumnDefinition));
            selectiveScrollingGrid_ColumnDefinition_Parent_Auto.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            selectiveScrollingGrid_ColumnDefinition_Parent_Star.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            selectiveScrollingGrid_border_grid_Parent.AppendChild(selectiveScrollingGrid_ColumnDefinition_Parent_Auto);
            selectiveScrollingGrid_border_grid_Parent.AppendChild(selectiveScrollingGrid_ColumnDefinition_Parent_Star);
            // RowDefinition of SelectiveScrollingGrid
            FrameworkElementFactory selectiveScrollingGrid_RowDefinition_Parent_Star = new FrameworkElementFactory(typeof(RowDefinition));
            FrameworkElementFactory selectiveScrollingGrid_RowDefinition_Parent_Auto = new FrameworkElementFactory(typeof(RowDefinition));
            selectiveScrollingGrid_RowDefinition_Parent_Star.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Star));
            selectiveScrollingGrid_RowDefinition_Parent_Auto.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Auto));
            selectiveScrollingGrid_border_grid_Parent.AppendChild(selectiveScrollingGrid_RowDefinition_Parent_Star);
            selectiveScrollingGrid_border_grid_Parent.AppendChild(selectiveScrollingGrid_RowDefinition_Parent_Auto);
            // DataGridRowHeader of SelectiveScrollingGrid
            FrameworkElementFactory dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent = new FrameworkElementFactory(typeof(DataGridRowHeader));
            dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent.SetValue(SelectiveScrollingGrid.RowProperty, 0);
            dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent.SetValue(SelectiveScrollingGrid.ColumnProperty, 0);
            dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent.SetValue(SelectiveScrollingGrid.RowSpanProperty, 2);
            dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent.SetValue(SelectiveScrollingGrid.SelectiveScrollingOrientationProperty, SelectiveScrollingOrientation.Vertical);
            dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent.SetValue(DataGridRowHeader.VisibilityProperty, new Binding()
            {
                Path = new PropertyPath("HeadersVisibility"),
                ConverterParameter = DataGridHeadersVisibility.Row,
                Converter = DataGrid.HeadersVisibilityConverter,
                RelativeSource = new RelativeSource() { AncestorType = typeof(DataGrid) }
            });
            // Add DataGridRowHeader for SelectiveScrollingGrid
            selectiveScrollingGrid_border_grid_Parent.AppendChild(dataGridRowHeader_selectiveScrollingGrid_border_grid_Parent);
            // DataGridCellsPresenter of SelectiveScrollingGrid
            FrameworkElementFactory dataGridCellsPresenter_selectiveScrollingGrid_border_grid_Parent = new FrameworkElementFactory(typeof(DataGridCellsPresenter));
            dataGridCellsPresenter_selectiveScrollingGrid_border_grid_Parent.SetValue(SelectiveScrollingGrid.RowProperty, 0);
            dataGridCellsPresenter_selectiveScrollingGrid_border_grid_Parent.SetValue(SelectiveScrollingGrid.ColumnProperty, 1);
            dataGridCellsPresenter_selectiveScrollingGrid_border_grid_Parent.SetValue(DataGridCellsPresenter.ItemsPanelProperty, new TemplateBindingExtension(DataGridRow.ItemsPanelProperty));
            dataGridCellsPresenter_selectiveScrollingGrid_border_grid_Parent.SetValue(DataGridCellsPresenter.SnapsToDevicePixelsProperty, new TemplateBindingExtension(DataGridRow.SnapsToDevicePixelsProperty));
            // Add DataGridCellsPresenter for SelectiveScrollingGrid
            selectiveScrollingGrid_border_grid_Parent.AppendChild(dataGridCellsPresenter_selectiveScrollingGrid_border_grid_Parent);
            // Add SelectiveScrollingGrid for Border
            border_grid_Parent.AppendChild(selectiveScrollingGrid_border_grid_Parent);
            // Add Border for Grid Parrent
            grid_Parent.AppendChild(border_grid_Parent);
            // Grid of Grid
            FrameworkElementFactory dataGridDetailsPresenter_grid_Parent = new FrameworkElementFactory(typeof(DataGridDetailsPresenter));
            dataGridDetailsPresenter_grid_Parent.SetValue(Grid.RowProperty, 1);
            dataGridDetailsPresenter_grid_Parent.SetValue(DataGridDetailsPresenter.VisibilityProperty, new TemplateBindingExtension(DataGridRow.DetailsVisibilityProperty));
            dataGridDetailsPresenter_grid_Parent.SetValue(DataGridDetailsPresenter.MarginProperty, new Thickness(30, 10, 10, 10));
            //FrameworkElementFactory grid_grid_Parent = new FrameworkElementFactory(typeof(Grid));
            //grid_grid_Parent.Name = "Part_Presenter_Grid";
            //grid_grid_Parent.SetValue(Grid.RowProperty, 1);
            //grid_grid_Parent.SetValue(Grid.BackgroundProperty, Brushes.Red);
            //grid_grid_Parent.SetValue(Grid.MarginProperty, new Thickness(30, 10, 10, 10));
            //grid_grid_Parent.SetValue(Grid.VisibilityProperty, Visibility.Collapsed);
            //// DataGrid
            //FrameworkElementFactory customDataGrid_grid_Parent = new FrameworkElementFactory(typeof(DataGrid));
            //customDataGrid_grid_Parent.SetValue(DataGrid.ItemsSourceProperty, new Binding(itemSource));
            //grid_grid_Parent.AppendChild(customDataGrid_grid_Parent);
            // Add Parrent
            grid_Parent.AppendChild(dataGridDetailsPresenter_grid_Parent);
            template.VisualTree = grid_Parent;
            return template;
        }

        private void RowHeaderToggleButton_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;
            while (!(obj is DataGridRow) && obj != null)
            {
                obj = VisualTreeHelper.GetParent(obj);
            }
            if (obj is DataGridRow)
            {
                DataGridRow gridRow = obj as DataGridRow;
                if (gridRow.DetailsVisibility == Visibility.Visible)
                {
                    gridRow.DetailsVisibility = Visibility.Collapsed;
                }
                else
                {
                    gridRow.DetailsVisibility = Visibility.Visible;
                }
                SelectedIndex = gridRow.GetIndex();
            }
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //DataGridRow row = (DataGridRow)ItemContainerGenerator.ContainerFromItem(item);
            object o = e.Row.Item as object;
            GridViewDefinition grid = this.DetailsViewDefinition.ElementAt(0) as GridViewDefinition;
            CustomDataGrid customDataGrid = grid.DataGrid;
            PropertyInfo r = o.GetType().GetProperty(grid.RelationalColumn.ToString());
            if (r != null)
            {
                object obj = r.GetValue(o);
                dynamic d = obj;
                if (d.Count != 0)
                {
                    e.Row.HeaderTemplate = (DataTemplate)Resources["HeaderTemplate"];
                    e.Row.Template = (ControlTemplate)Resources["TemplateDataGridRow"];
                    //
                    DataTemplate dataTemplateDetails = new DataTemplate();
                    FrameworkElementFactory customDataGrid_grid_Parent = new FrameworkElementFactory(typeof(CustomDataGrid));
                    customDataGrid_grid_Parent.SetValue(CustomDataGrid.ItemsSourceProperty, new Binding(grid.RelationalColumn.ToString()));

                    foreach (var vn in typeof(DataGrid)
                        .GetFields(BindingFlags.Static | BindingFlags.Public)
                        .Where(p => p.FieldType.Equals(typeof(DependencyProperty))))
                    {
                        customDataGrid_grid_Parent.SetValue(
                            CustomDataGrid.,
                            null);
                    }

                    Console.WriteLine("===================================");

                    dataTemplateDetails.VisualTree = customDataGrid_grid_Parent;
                    dataTemplateDetails.Seal();
                    //
                    e.Row.DetailsTemplate = dataTemplateDetails;
                    //
                    this.SetDetailsVisibilityForItem(e.Row.Item, Visibility.Collapsed);
                }
            }
        }

        private void DataGridDetailsPresenter_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            //scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 3);
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}