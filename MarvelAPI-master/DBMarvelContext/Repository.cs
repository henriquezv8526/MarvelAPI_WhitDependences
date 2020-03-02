using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMarvelContext
{
    public class Repository
    {

        #region Get
        public List<Sucursales> GetSucursales()
        {
            ContextMarvelVirtual _context = new ContextMarvelVirtual();
            List<Sucursales> _data = new List<Sucursales>();
            _data = _context.Sucursales.Where(x => x.Activo == true).ToList();
            return _data;
        }

        public List<Sucursales> GetSucursalById(int Id)
        {
            ContextMarvelVirtual _context = new ContextMarvelVirtual();
            List<Sucursales> _data = new List<Sucursales>();
            _data = _context.Sucursales.Where(x => x.Activo == true && x.IdSucursal == Id).ToList();
            return _data;
        }

        public List<Sucursales> GetComicsForBranc(int Id)
        {
            ContextMarvelVirtual _context = new ContextMarvelVirtual();
            List<Sucursales> _data = new List<Sucursales>();
            _data = _context.Sucursales.Where(x => x.Activo == true && x.IdSucursal == Id).ToList();
            return _data;
        }

        public List<ComicsStore> GetComicsStore()
        {
            ContextMarvelVirtual _context = new ContextMarvelVirtual();
            List<ComicsStore> _data = new List<ComicsStore>();
            _data = _context.Productos
                .Where(x => x.Activo == true && x.Inventarios.Activo == true && x.Inventarios.Sucursales.Activo == true)
                .Select(y => new ComicsStore { IdProducto = y.IdProducto , Codigo = y.Codigo, IdInventario = y.IdInventario, NombreInventario = y.Inventarios.Descripcion, IdSucursal = y.Inventarios.Sucursales.IdSucursal, NombreSucursal = y.Inventarios.Sucursales.Nombre, Ubicacion = y.Inventarios.Sucursales.Ubicacion } )
                .ToList();
            return _data;
        }

        public List<ComicsStore> GetComicsStoreById(string _codigoProducto)
        {
            ContextMarvelVirtual _context = new ContextMarvelVirtual();
            List<ComicsStore> _data = new List<ComicsStore>();
            _data = _context.Productos
                .Where(x => x.Activo == true && x.Inventarios.Activo == true && x.Inventarios.Sucursales.Activo == true && x.Codigo == _codigoProducto)
                .Select(y => new ComicsStore { IdProducto = y.IdProducto, Codigo = y.Codigo, IdInventario = y.IdInventario, NombreInventario = y.Inventarios.Descripcion, IdSucursal = y.Inventarios.Sucursales.IdSucursal, NombreSucursal = y.Inventarios.Sucursales.Nombre, Ubicacion = y.Inventarios.Sucursales.Ubicacion })
                .ToList();
            return _data;
        }
        #endregion

        #region Update

        public string UpdateSucursal(int Id, string Nombre, string Ubicacion, string Telefonos)
        {
            string _request = "";
            try
            {
                ContextMarvelVirtual _context = new ContextMarvelVirtual();

                var result = _context.Sucursales.SingleOrDefault(x => x.Activo == true && x.IdSucursal == Id);
                if (result != null)
                {
                    result.Nombre = Nombre;
                    result.Ubicacion = Ubicacion;
                    result.Telefonos = Telefonos;
                    _context.SaveChanges();
                    _request = "1";
                }
            }
            catch 
            {
                _request = "0";
            }
            return _request;
        }
        #endregion

        #region Delete

        public string DeleteSucursal(int Id)
        {
            string _request = "";
            try
            {
                ContextMarvelVirtual _context = new ContextMarvelVirtual();

                var result = _context.Sucursales.SingleOrDefault(x => x.Activo == true && x.IdSucursal == Id);
                if (result != null)
                {
                    result.Activo = false;
                    _context.SaveChanges();
                    _request = "1";
                }
            }
            catch
            {
                _request = "0";
            }
            return _request;
        }
        #endregion

        #region Add

        public string AddSucursal(string Nombre, string Ubicacion, string Telefonos)
        {
            string _request = "";
            try
            {
                ContextMarvelVirtual _context = new ContextMarvelVirtual();

                int _Id = _context.Sucursales.Max(x => x.IdSucursal) + 1;
                var _User = _context.Usuarios.FirstOrDefault();

                var _sucursalAdd = new Sucursales { IdSucursal = _Id, Nombre = Nombre, Ubicacion = Ubicacion, Telefonos = Telefonos, IdUsuarioAlta = _User.IdUsuario, FCreacion = DateTime.Now, Activo = true };
                _context.Sucursales.Add(_sucursalAdd);
                _context.SaveChanges();
                _request = "1";
            }
            catch
            {
                _request = "0";
            }
            return _request;
        }
        #endregion
    }
}