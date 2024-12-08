﻿using BL;
using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.VM
{
    public class PersonaDepart : Personas
    {
        #region Atributos
        private string nombreDepart;
        #endregion

        #region Propiedades
        public string NombreDepart
        {
            get { return nombreDepart; }
            set { nombreDepart = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="per">Objeto persona a añadir a personaDepartamento</param>
        public PersonaDepart(Personas per)
        {
            string nombreDept = "";

            this.Id = per.Id;
            this.Nombre = per.Nombre;
            this.Apellidos = per.Apellidos;
            this.Telefono = per.Telefono;
            this.Direccion = per.Direccion;
            this.Foto = per.Foto;
            this.FechaNac = per.FechaNac;
            this.IdDepart = per.IdDepart;

            List<Departamentos> listaDepart = ListadoBD.listadoDepartamentosDAL();

            nombreDept = listaDepart.FirstOrDefault(dept => dept.Id == per.IdDepart).Nombre;

            nombreDepart = nombreDept;


        }
        /// <summary>
        /// Constructor con id de la persona
        /// </summary>
        /// <param name="idpersona">Id de la persona a añadir a personaDepart</param>
        public PersonaDepart(int idpersona)
        {

            Personas per = ManejadoraPersonasBL.buscarPersonaPorIdBL(idpersona);
            string nombreDept = "";

            this.Id = per.Id;
            this.Nombre = per.Nombre;
            this.Apellidos = per.Apellidos;
            this.Telefono = per.Telefono;
            this.Direccion = per.Direccion;
            this.Foto = per.Foto;
            this.FechaNac = per.FechaNac;
            this.IdDepart = per.IdDepart;


            Departamentos depart = ManejadoraDepartamentosDAL.buscarDepartamentoPorId(IdDepart);
            nombreDepart = depart.Nombre;


        }
        #endregion
    }
}
