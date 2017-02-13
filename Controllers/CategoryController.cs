using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using UmderlakareUmbCms.Business.Services;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [RoutePrefix("api/v1/categorys")]
    public class CategoryController : ApiController
    {
        private  ICategorysService _categorysService;
        //CategoryService _categorysService = new CategoryService(new Dialogue.Logic.Services.CategoryService());

        
        public CategoryController(ICategorysService categorysService) : base()
        {
            _categorysService = categorysService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _categorysService.GetCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }
        [HttpGet]
        [Route("{parentId:guid}")]
        public IHttpActionResult GetSubCatByParentId(Guid parentId)
        {
            try
            {
                var subCat = _categorysService.GetAllSubCategories(parentId);
                return Ok(subCat);

            }
            catch (Exception)
            {

                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");

            }
        }
    }
}