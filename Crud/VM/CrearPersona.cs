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
    public class CrearPersona : INotifyPropertyChanged
    {
        #region Atributos
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNac;
        private int idDepart;
        private DelegateCommand insertarPersona;
        private DelegateCommand volverCommand;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; NotifyPropertyChanged("Nombre");
                insertarPersona.RaiseCanExecuteChanged();

            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; NotifyPropertyChanged("Apellidos");
                insertarPersona.RaiseCanExecuteChanged();
            }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; NotifyPropertyChanged("Telefono");
                insertarPersona.RaiseCanExecuteChanged();
            }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; NotifyPropertyChanged("Direccion");
                insertarPersona.RaiseCanExecuteChanged();
            }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; NotifyPropertyChanged("Foto");
                insertarPersona.RaiseCanExecuteChanged();
            }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; NotifyPropertyChanged("FechaNac");
                insertarPersona.RaiseCanExecuteChanged();
            }
        }
        public int IdDepart
        {
            get { return idDepart; }
            set { idDepart = value; NotifyPropertyChanged("IdDepart");
                insertarPersona.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand InsertarPersona
        {
            get { return insertarPersona; }
        }

        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }

        #endregion


        public CrearPersona()
        {
            insertarPersona = new DelegateCommand(crearPersonaExecute, canCrearPersonaCommand);
            volverCommand = new DelegateCommand(volverCommandExecute);
        }


        /// <summary>
        /// Función que ejecuta la creación de una nueva persona en la base de datos.
        /// Pre: Nada
        /// Post: Si la persona se crea correctamente en la base de datos, se muestra un mensaje de éxito al usuario.
        /// </summary>
        public async void crearPersonaExecute()
        {
            Personas personas = new Personas(0, Nombre, Apellidos, Telefono, Direccion, Foto, FechaNac, IdDepart);
            int insertado = ManejadoraPersonasBL.insetarPersonaBL(personas);
            if (insertado > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Persona insertada correctamente.", "Cerrar");
            }
        }

        /// <summary>
        /// Función que verifica si los campos necesarios para crear una persona están completos.
        /// Pre: Nada
        /// Post: Devuelve `true` si todos los campos requeridos están llenos y válidos, de lo contrario devuelve `false`.
        /// </summary>
        /// <returns>Booleano que indica si los campos necesarios están completos para crear la persona.</returns>
        public bool canCrearPersonaCommand()
        {
            bool canCreate = false;

            if (!String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Apellidos) && !String.IsNullOrEmpty(Telefono)
                && !String.IsNullOrEmpty(Direccion) && !String.IsNullOrEmpty(Foto) && FechaNac != null && IdDepart != 0)
            {
                canCreate = true;
            }
            return canCreate;
        }

        /// <summary>
        /// Función que maneja la navegación hacia la página principal.
        /// Pre: No hay requisitos previos específicos para volver a la página principal.
        /// Post: La aplicación navega hacia la página principal (MainPage).
        /// </summary>
        public async void volverCommandExecute()
        {
            await Shell.Current.GoToAsync("///MainPage");
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
