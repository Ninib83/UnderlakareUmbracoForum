﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using UmderlakareUmbCms.Business.Services;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [RoutePrefix("api/v1/categories")]
    public class CategoryController : ApiController
    {

        // Fixa Dependency injection


        private  ICategorysService _categorysService;
        //CategoryService _categorysService = new CategoryService(new Dialogue.Logic.Services.CategoryService());

        
        public CategoryController(ICategorysService categorysService) 
        {
            _categorysService = categorysService;
        }

        #region HttpGet

        [HttpGet]
        [Route("AllCategories")]
        public IHttpActionResult GetAllMainAndSubCategories()
        {
            try
            {
                var parentCat = _categorysService.GetAllMainAndSubCategories();
                return Ok(parentCat);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }


        [HttpGet]
        [Route("subCategories")]
        public IHttpActionResult GetAllSubCategories()
        {
            try
            {
                var subCat = _categorysService.GetAllSubCategories();
                return Ok(subCat);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }


        [HttpGet]
        [Route("mainCategory/{id:int}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _categorysService.GetMainCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }

        [HttpGet]
        [Route("subCategory/{id:int}")]
        public IHttpActionResult GetSubCategoryById(int id)
        {
            try
            {
                var category = _categorysService.GetSubCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }

        #endregion
    }
}