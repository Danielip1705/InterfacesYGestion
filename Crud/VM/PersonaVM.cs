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
        public Personas persona;
        private ObservableCollection<Personas> listaPersonas;
        private DelegateCommand agregarCommand;

        #region Propiedades
        public Personas Persona
        {
            get
            {
                return persona;
            }
            set
            {
                personasSelected = value;
                NotifyPropertyChanged("Persona");
            }
        }
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
            Persona = new Personas();
            PersonasSelected = new Personas();
            ListaPersonas = new ObservableCollection<Personas>(ListadoBD.ListadoCompletoPersonaDAL());
            agregarCommand = new DelegateCommand(agregarPersona,canExecuteAgregarPersona);
        }

        public void agregarPersona()
        {
            
              ManejadoraPersonasBL.insetarPersonaBL(persona);
            
        }

        public bool canExecuteAgregarPersona()
        {
            bool canExecute = false;

            if (String.IsNullOrEmpty(persona.Nombre)&& String.IsNullOrEmpty(persona.Apellidos)
                && String.IsNullOrEmpty(persona.Direccion)&& String.IsNullOrEmpty(persona.Telefono)&&
                String.IsNullOrEmpty(persona.Foto)&& persona.IdDepart!=0)
            {
                canExecute = true;
            }
            return canExecute;
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
