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
    public class ListadoPersonaVM : INotifyPropertyChanged
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
            set
            {
                personaSelected = value; NotifyPropertyChanged();
                editarPersona.RaiseCanExecuteChanged();
                eliminarPersona.RaiseCanExecuteChanged();
            }
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
            editarPersona = new DelegateCommand(editarPersonaExecute, canExecuteEditar);
            eliminarPersona = new DelegateCommand(eliminarPersonaExecute, canExecuteEliminar);
        }


        #region Funciones
        /// <summary>
        /// Función que carga la lista de personas junto con el nombre del departamento a partir de las listas de personas y departamentos.
        /// Pre: Se necesita que las listas de personas y departamentos estén disponibles en la base de datos.
        /// Post: Se asigna la lista cargada de objetos de tipo PersonaDepart a la propiedad ListaPersona.
        /// </summary>
        /// 
        private void cargarLista()
        {
            PersonaDepart personaDept = null;
            List<Personas> persona = ManejadoraPersonasBL.listadoCompletoPersonasBL();
            List<Departamentos> departamentos = ManejadoraDepartamentoBL.getListadoDepartametosBL();

            listaPersona = new ObservableCollection<PersonaDepart>();

            foreach (Personas per in persona)
            {
                personaDept = new PersonaDepart(per);
                listaPersona.Add(personaDept);
            }
            NotifyPropertyChanged("ListaPersona");
        }

        /// <summary>
        /// Función que ejecuta la navegación hacia la página de creación de persona.
        /// Pre: Nada
        /// Post: Se navega hacia la página de creación de persona.
        /// </summary>
        public async void agregarPersonaCommand()
        {
            await Shell.Current.GoToAsync("///CreatePage");
        }

        /// <summary>
        /// Función que ejecuta la navegación hacia la página de edición de persona, pasando los datos de la persona seleccionada.
        /// Pre: Nada
        /// Post: Se navega hacia la página de edición con los datos de la persona seleccionada.
        /// </summary>
        public async void editarPersonaExecute()
        {
            Dictionary<string, Object> personaEditar = new Dictionary<string, Object>();

            Personas persona = ManejadoraPersonasBL.buscarPersonaPorIdBL(personaSelected.Id);

            personaEditar.Add("personaEditar", persona);

            await Shell.Current.GoToAsync("///EditarPage", personaEditar);
        }

        /// <summary>
        /// Función que determina si el botón de editar debe estar habilitado o no.
        /// Pre: Nada
        /// Post: Retorna true si hay una persona seleccionada, habilitando el botón de editar.
        /// </summary>
        /// <returns>True si hay una persona seleccionada, false de lo contrario.</returns>
        public bool canExecuteEditar()
        {
            bool canExecute = false;

            if (personaSelected != null)
            {
                canExecute = true;
            }
            return canExecute;
        }

        /// <summary>
        /// Función que ejecuta la eliminación de la persona seleccionada, pidiendo confirmación al usuario.
        /// Pre: Nada
        /// Post: Si el usuario confirma la eliminación, se elimina la persona de la base de datos.
        /// </summary>
        public async void eliminarPersonaExecute()
        {
            bool eliminar = await Application.Current.MainPage.DisplayAlert("Eliminar", "¿Seguro que quieres eliminar a esta persona?", "Aceptar", "Cancelar");
            if (eliminar)
            {
                ManejadoraPersonasBL.borrarPersonasBL(personaSelected.Id);
                personaSelected = null;
                cargarLista();
                await Application.Current.MainPage.DisplayAlert("Éxito", "Persona eliminada correctamente.", "Cerrar");
            }
        }

        /// <summary>
        /// Función que determina si el botón de eliminar debe estar habilitado o no.
        /// Pre: Nada
        /// Post: Retorna true si hay una persona seleccionada, habilitando el botón de eliminar.
        /// </summary>
        /// <returns>True si hay una persona seleccionada, false de lo contrario.</returns>
        public bool canExecuteEliminar()
        {
            bool canExecute = false;
            if (personaSelected != null)
            {
                canExecute = true;
            }
            return canExecute;
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

