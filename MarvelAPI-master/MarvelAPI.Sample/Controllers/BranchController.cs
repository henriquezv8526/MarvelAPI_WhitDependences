using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DBMarvelContext;
using MarvelAPI.Sample.Models;

namespace MarvelAPI.Sample.Controllers
{
    public class BranchController : Controller
    {

        #region Variables
       
        /// <summary>
        /// Serializador para JSON
        /// </summary>
        JavaScriptSerializer clsJson = new JavaScriptSerializer();

        

        /// <summary>
        /// Variable que almacena cadenas JSON
        /// </summary>
        string json;

        #endregion

        #region View
        public ActionResult Index()
        {
            return View();
        }
        #endregion


        #region Get
        [HttpPost]
        public string getBranchs()
        {
            try
            {
                Repository _repo = new Repository();
                List<Sucursales> _list = _repo.GetSucursales();

                var result = _list.Select(x => new SucursalesModel
                {
                    IdSucursal = x.IdSucursal,
                    Nombre = x.Nombre,
                    Ubicacion = x.Ubicacion,
                    Telefonos = x.Telefonos,
                    IdUsuarioAlta = x.IdUsuarioAlta,
                    FCreacion = String.Format(x.FCreacion.ToString(), "dd/mm/aaaa"),
                    FModificacion = String.Format(x.FModificacion.ToString(), "dd/mm/aaaa"),
                    Activo = x.Activo
                });
                return json = clsJson.Serialize(result.ToList());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string getBranchById(int Id)
        {
            try
            {
                Repository _repo = new Repository();
                List<Sucursales> _list = _repo.GetSucursalById(Id);

                var result = _list.Select(x => new SucursalesModel
                {
                    IdSucursal = x.IdSucursal,
                    Nombre = x.Nombre,
                    Ubicacion = x.Ubicacion,
                    Telefonos = x.Telefonos,
                    IdUsuarioAlta = x.IdUsuarioAlta,
                    FCreacion = String.Format(x.FCreacion.ToString(), "dd/mm/aaaa"),
                    FModificacion = String.Format(x.FModificacion.ToString(), "dd/mm/aaaa"),
                    Activo = x.Activo
                });
                return json = clsJson.Serialize(result.ToList());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion


        #region Update
        [HttpPost]
        public string updateBranch(int Id, string Nombre, string Ubicacion, string Telefonos)
        {
            string _resultRejection = "0";
            try
            {
                Repository _repo = new Repository();
                _resultRejection = Convert.ToString(_repo.UpdateSucursal(Id, Nombre, Ubicacion, Telefonos));
            }
            catch
            {
                _resultRejection = "0";
            }
            return clsJson.Serialize(_resultRejection);
        }
        #endregion

        #region Delete
        [HttpPost]
        public string deleteBranch(int Id)
        {
            string _resultRejection = "0";
            try
            {
                Repository _repo = new Repository();
                _resultRejection = Convert.ToString(_repo.DeleteSucursal(Id));
            }
            catch
            {
                _resultRejection = "0";
            }
            return clsJson.Serialize(_resultRejection);
        }
        #endregion

        #region Add
        [HttpPost]
        public string addBranch(string Nombre, string Ubicacion, string Telefonos)
        {
            string _resultRejection = "0";
            try
            {
                Repository _repo = new Repository();
                _resultRejection = Convert.ToString(_repo.AddSucursal(Nombre, Ubicacion, Telefonos));
            }
            catch
            {
                _resultRejection = "0";
            }
            return clsJson.Serialize(_resultRejection);
        }
        #endregion
    }
}
