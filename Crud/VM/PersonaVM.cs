using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BL;
using DAL;
using Crud.VM.Utilidades;

namespace Crud.VM
{
    public class PersonaVM : INotifyPropertyChanged
    {
        private Personas personasSelected;
        private ObservableCollection<Personas> listaPersonas;
        private DelegateCommand agregarCommand;

        #region Propiedades
        public Personas PersonasSelected
        {
            get 
            { 
                return personasSelected; 
            }
            set 
            {
                personasSelected = value;
                NotifyPropertyChanged("PersonaSelected");
            }
        }

        public ObservableCollection<Personas> ListaPersonas
        {
            get
            {
                return listaPersonas;
            }
            set
            {
                listaPersonas = value;
                NotifyPropertyChanged("ListaPersonas");
            }
        }

        public DelegateCommand AgregarCommand
        {
            get { return agregarCommand; }
        }
        #endregion

        public PersonaVM()
        {
            PersonasSelected = new Personas();
            ListaPersonas = new ObservableCollection<Personas>(ListadoBD.ListadoCompletoPersonaDAL());
        }

        public void agregarPersona()
        {
            
        }


        #region Notify
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}
