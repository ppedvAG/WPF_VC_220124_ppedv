using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
    //Die TemplatePart-Attribute definieren, welche Controls Teil des ControlTemplates sein müssen, dass diesem CustomControl zugeordnet wird
    [TemplatePart(Name ="Content", Type =typeof(ContentPresenter))]
    [TemplatePart(Name ="PopupContent", Type =typeof(ContentPresenter))]
    public class PopupControl : ContentControl
    {
        static PopupControl()
        {
            //Überschreiben des 'Standart-Styles' des Controls mit dem in Generic.xaml definierten Style durch Übergabe eines Type-Objekts der aktuellen Klasse
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupControl), new FrameworkPropertyMetadata(typeof(PopupControl)));
        }

        //DP für Inhalt in Popup
        public object PopupContent
        {
            get { return (object)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }
        public static readonly DependencyProperty PopupContentProperty =
            DependencyProperty.Register("PopupContent", typeof(object), typeof(PopupControl), new PropertyMetadata(null));


        public PopupControl()
        {
        }
    }
}
