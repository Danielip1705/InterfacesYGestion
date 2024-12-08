using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using Crud.VM.Utilidades;
using DAL;
using BL;


namespace Crud.VM
{
    public class ListadoPersonaVM:INotifyPropertyChanged
    {
        private ObservableCollection<PersonaDepart> listaPersona;
        private PersonaDepart personaSelected;
        private DelegateCommand crearPersona;
        private DelegateCommand editarPersona;
        private DelegateCommand eliminarPersona;

        #region Propiedades
        public ObservableCollection<PersonaDepart> ListaPersona
        {
            get { return listaPersona; }
            set { listaPersona = value; NotifyPropertyChanged(); }
        }
        public PersonaDepart PersonaSelected
        {
            get { return personaSelected; }
            set { personaSelected = value; NotifyPropertyChanged(); }
        }
        public DelegateCommand CrearPersona
        {
            get { return crearPersona; }
        }
        public DelegateCommand EditarPersona
        {
            get { return editarPersona; }
        }
        public DelegateCommand EliminarPersona
        {
            get { return eliminarPersona; }
        }
        #endregion

        public ListadoPersonaVM()
        {
            cargarLista();
            crearPersona = new DelegateCommand(agregarPersonaCommand);

        }
        #region 

        private void cargarLista()
        {
            PersonaDepart personaDept = null;
            List<Personas> persona = ManejadoraPersonasBL.listadoCompletoPersonasBL();

            List<Departamentos> departamentos = ListadoBD.listadoDepartamentosDAL();

            listaPersona = new ObservableCollection<PersonaDepart>();

            foreach (Personas per in persona)
            {
                personaDept = new PersonaDepart(per);
                listaPersona.Add(personaDept);
            }
            NotifyPropertyChanged("ListaPersona");
        }

        public async void agregarPersonaCommand(){
            await Shell.Current.GoToAsync("///CreatePage");
        }
        #endregion
        #region Notify
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}

