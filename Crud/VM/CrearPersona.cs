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


        public async void crearPersonaExecute()
        {
            Personas personas = new Personas(0, Nombre, Apellidos, Telefono, Direccion, Foto, FechaNac, IdDepart);
            int insertado = ManejadoraPersonasBL.insetarPersonaBL(personas);
            if (insertado > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito","Persona insertada correctamente.","Cerrar");
            }
        }

        public bool canCrearPersonaCommand(){
            bool canCreate = false;

            if(!String.IsNullOrEmpty(Nombre)&& !String.IsNullOrEmpty(Apellidos)&& !String.IsNullOrEmpty(Telefono)
                && !String.IsNullOrEmpty(Direccion)&& !String.IsNullOrEmpty(Foto)&& FechaNac!=null && IdDepart!=0)
            {
                canCreate = true;
            }
            return canCreate;
        }

        public async void volverCommandExecute(){
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
