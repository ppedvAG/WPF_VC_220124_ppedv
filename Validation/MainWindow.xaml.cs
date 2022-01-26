using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Validation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((this.DataContext as Person).Alter.ToString());
        }
    }

    public class ValidationRuleCollection : Collection<ValidationRule> { }

    public class ValidationMarkup : MarkupExtension
    {
        private Binding binding;

        public ValidationMarkup(Binding binding, ValidationRuleCollection validationRules)
        {
            this.binding = binding;

            foreach (var item in validationRules)
            {
                binding.ValidationRules.Add(item);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return binding.ProvideValue(serviceProvider);
        }
    }
}
