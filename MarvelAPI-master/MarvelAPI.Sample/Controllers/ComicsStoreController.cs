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
    public class ComicsStoreController : Controller
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
        // GET: ComicsStore
        public ActionResult Index()
        {
            return View();
        }

        #endregion


        #region Get
        [HttpPost]
        public string getComicsForBranc()
        {
            try
            {
                Repository _repo = new Repository();

                
                APIController _api = new APIController();
                GetComicsViewModel _getComicsViewModel = new GetComicsViewModel();
                _getComicsViewModel.Format = ComicFormat.Comic;
                _getComicsViewModel.FormatType = ComicFormatType.Comic;
                _getComicsViewModel.Limit = 10;

                var  _request = _api.Comics(_getComicsViewModel);
                
                var _seria = clsJson.Serialize(_request);
                var _root = clsJson.Deserialize<RootObject>(_seria);
              
                List<ComicsStore> _list =  _repo.GetComicsStore();

                List<ComicsStoreModel> _lstComicsModel = new List<ComicsStoreModel>();

                foreach (var _item in _list)
                {
                    int _codigo = Convert.ToInt32(_item.Codigo);
                    var _search = _root.Data.Where(x => x.Id == _codigo).FirstOrDefault();

                    if (_search != null)
                    {
                        ComicsStoreModel _itemComicModel = new ComicsStoreModel();
                        _itemComicModel.Check = false;
                        _itemComicModel.IdProducto = _item.IdProducto;
                        _itemComicModel.Codigo = _codigo;
                        _itemComicModel.IdInventario = _item.IdInventario;
                        _itemComicModel.NombreInventario = _item.NombreInventario;
                        _itemComicModel.IdSucursal = _item.IdSucursal;
                        _itemComicModel.NombreSucursal = _item.NombreSucursal;
                        _itemComicModel.Ubicacion = _item.Ubicacion;
                        _itemComicModel.TituloComic = _search.Title;
                        _itemComicModel.Formato = _search.Format;
                        _itemComicModel.NumPaginas = _search.PageCount;
                        _lstComicsModel.Add(_itemComicModel);
                    }
                }

               
                return json = clsJson.Serialize(_lstComicsModel.OrderBy(x => x.TituloComic));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    #endregion
}