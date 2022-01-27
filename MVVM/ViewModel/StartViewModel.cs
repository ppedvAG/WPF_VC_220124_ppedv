using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    internal class StartViewModel : INotifyPropertyChanged
    {
        public CustomCommand LadeDbCmd { get; set; }
        public CustomCommand OeffneDbCmd { get; set; }

        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; }}


        public StartViewModel()
        {
            LadeDbCmd = new CustomCommand
                (
                    p =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPersonen)));
                    },
                    p => AnzahlPersonen == 0
                );

            OeffneDbCmd = new CustomCommand
                (
                    p =>
                    {
                        //Neues Fenster

                        (p as Window).Close();
                    },
                    p => AnzahlPersonen >= 1
                );
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
