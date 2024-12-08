using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Crud.VM.Utilidades;
using System.Threading.Tasks;
using BL;

namespace Crud.VM
{
    [QueryProperty(nameof(PersonaEditar), "personaEditar")]
    public class EditarPersonaVM:INotifyPropertyChanged
    {
        #region Atributos
        private Personas personaEditar;
        private DelegateCommand editarPersona;
        private DelegateCommand volverCommand;
        #endregion
        #region Propiedades
        public Personas PersonaEditar
        {
            get { return personaEditar; } 
            set { personaEditar = value; NotifyPropertyChanged("PersonaEditar");
                editarPersona.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand EditarPersona
        {
            get { return editarPersona; }
        }

        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }

        public EditarPersonaVM(){
            editarPersona = new DelegateCommand(editarPersonaExecute);
            volverCommand = new DelegateCommand(volverCommandExecute);
        }
        #endregion

        #region Funciones

        /// <summary>
        /// Función que ejecuta la edición de una persona en la base de datos.
        /// Pre: Nada
        /// Post: Si la persona se edita correctamente en la base de datos, se muestra un mensaje de éxito al usuario.
        /// </summary>
        public async void editarPersonaExecute()
        {
            if (PersonaEditar != null)
            {
                int editado = ManejadoraPersonasBL.editarPersonaBL(PersonaEditar);
                if (editado > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Persona editada correctamente.", "Cerrar");
                }
            }
        }

        /// <summary>
        /// Función que ejecuta la acción de volver a la página principal.
        /// Pre: Nada
        /// Post: La aplicación navega hacia la página principal (MainPage).
        /// </summary>
        public async void volverCommandExecute()
        {
            await Shell.Current.GoToAsync("///MainPage");
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
