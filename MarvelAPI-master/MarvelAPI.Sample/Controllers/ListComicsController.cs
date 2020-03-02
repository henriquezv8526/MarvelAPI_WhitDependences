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

    public class ListComicsController : Controller
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
        // GET: ListComics
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Get
        [HttpPost]
        public string getListComics()
        {
            try
            {
                
                APIController _api = new APIController();
                GetComicsViewModel _getComicsViewModel = new GetComicsViewModel();
                _getComicsViewModel.Format = ComicFormat.Comic;
                _getComicsViewModel.FormatType = ComicFormatType.Comic;
                _getComicsViewModel.Limit = 100;

                var _request = _api.Comics(_getComicsViewModel);

                var _seria = clsJson.Serialize(_request);
                var _root = clsJson.Deserialize<RootObject>(_seria);

                List<ListComicsModel> _lstComicsModel = new List<ListComicsModel>();
                
                foreach (var _item in _root.Data)
                {
                    string _ima = (_item.Images.FirstOrDefault() != null) ? _item.Images.FirstOrDefault().Path + '.' + _item.Images.FirstOrDefault().Extension : "";
                    if(string.IsNullOrEmpty( _ima))
                    {
                        _ima = "Default";
                    }

                    string _fLan = (_item.Dates.Where(x => x.Type == "onsaleDate").FirstOrDefault() != null) ? _item.Dates.Where(x => x.Type == "onsaleDate").FirstOrDefault().Date2.ToString() :"";
                    if (string.IsNullOrEmpty(_fLan))
                    {
                        _fLan = "";
                    }
                    else
                    {
                        _fLan = System.Convert.ToDateTime(_fLan).ToString();
                    }

                    ListComicsModel _itemComicModel = new ListComicsModel();
                    _itemComicModel.Id = _item.Id;
                    _itemComicModel.Imagen = _ima;
                    _itemComicModel.Nombre = _item.Title;
                    _itemComicModel.Volumen = _item.IssueNumber.ToString();
                    _itemComicModel.FechaLanzamiento = _fLan;
                    _itemComicModel.Paginas = _item.PageCount;
                    _itemComicModel.Descripcion = _item.Description;
                    _lstComicsModel.Add(_itemComicModel);

                    
                }


                return json = clsJson.Serialize(_lstComicsModel.OrderBy(x => x.Nombre));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string getListCharacterByIds(List<int> Ids)
        {
            try
            {
                List<CharacterDetailModel> _lstCharacterDetailModel = new List<CharacterDetailModel>();

                foreach (int _id in Ids)
                {
                    APIController _api = new APIController();
                    var _request = _api.Characters(_id);
                    var _seria = clsJson.Serialize(_request);
                    var _root = clsJson.Deserialize<CharacterModel>(_seria);

                    string _ima = (_root.Data.Thumbnail != null) ? _root.Data.Thumbnail.Path + '.' + _root.Data.Thumbnail.Extension : "";
                    if (string.IsNullOrEmpty(_ima))
                    {
                        _ima = "Default";
                    }

                    CharacterDetailModel _detail = new CharacterDetailModel();
                    _detail.Name = _root.Data.Name;
                    _detail.Image = _ima;
                    _lstCharacterDetailModel.Add(_detail);
                }
                return json = clsJson.Serialize(_lstCharacterDetailModel);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string getListComicsById(int Id)
        {
            try
            {

                APIController _api = new APIController();
                var _request = _api.Comic(Id);

                var _seria = clsJson.Serialize(_request);
                var _root = clsJson.Deserialize<RootObject2>(_seria);

                List<ListComicsDetailModel> _lstComicsModel = new List<ListComicsDetailModel>();

                
                string _ima = (_root.Data.Images.FirstOrDefault() != null) ? _root.Data.Images.FirstOrDefault().Path + '.' + _root.Data.Images.FirstOrDefault().Extension : "";
                if (string.IsNullOrEmpty(_ima))
                {
                   _ima = "Default";
                }
                
                string _fLan = (_root.Data.Dates.Where(x => x.Type == "onsaleDate").FirstOrDefault() != null) ? _root.Data.Dates.Where(x => x.Type == "onsaleDate").FirstOrDefault().Date.ToString() : "";
                if (string.IsNullOrEmpty(_fLan))
                {
                  _fLan = "";
                }
                else
                {
                  _fLan = System.Convert.ToDateTime(_fLan).ToString();
                }

                ListComicsDetailModel _itemComicModel = new ListComicsDetailModel();
                _itemComicModel.Id = _root.Data.Id;
                _itemComicModel.Imagen = _ima;
                _itemComicModel.Nombre = _root.Data.Title;
                _itemComicModel.Volumen = _root.Data.IssueNumber.ToString();
                _itemComicModel.FechaLanzamiento = _fLan;
                _itemComicModel.Paginas = _root.Data.PageCount;
                _itemComicModel.Descripcion = _root.Data.Description;
                _itemComicModel.CountCharacter = _root.Data.Characters.Available;

                if (_itemComicModel.CountCharacter > 0)
                {
                    List<int> _lstNew = new List<int>();
                    foreach (var _item in _root.Data.Characters.Items)
                    {
                        int _IdCharacter = 0;
                        string[] _vec = _item.ResourceURI.Split('/');
                        
                        try
                        {
                            _IdCharacter = Convert.ToInt32(_vec[_vec.Length - 1]);
                            _lstNew.Add(_IdCharacter);
                        }
                        catch {}
                    }
                    _itemComicModel.LstCharacterId = _lstNew;
                }
                else
                {
                    _itemComicModel.LstCharacterId = null;
                }

                _lstComicsModel.Add(_itemComicModel);

                return json = clsJson.Serialize(_lstComicsModel.OrderBy(x => x.Nombre));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string getComicsExistBranch(int codigo)
        {
            string _sucursal = "";
            try
            {
                Repository _repo = new Repository();

                List<ComicsStore> _list = _repo.GetComicsStoreById(codigo.ToString());

                if (_list != null && _list.Count > 0)
                    _sucursal = _list.FirstOrDefault().NombreSucursal;
                else
                    _sucursal = "No Disponible";
                
            }
            catch (Exception)
            {
                _sucursal = "No Disponible";
            }

            return json = clsJson.Serialize(_sucursal);
        }
    }

    #endregion
}
