using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;

using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Business.Services
{
    public class PageContentService : IPageContentService
    {

        #region list of At tjänst

        public IPageContent GetAtTjanstById(Guid Key)
        {
            var page = ApplicationContext.Current.Services.ContentService.GetById(Key);
            
            List<PropertieT> listOfProperties = new List<PropertieT>();

            List<ChildPropertie> listOfChildProperties = new List<ChildPropertie>();

            foreach (var child in page.Children())
            {
                List<ChildPropertieChild> listOfChildInChild = new List<ChildPropertieChild>();

                foreach (var item in child.Children())
                {
                    List<PropertieT> listOfChildrenProperties = new List<PropertieT>();

                    foreach (var typ in item.PropertyTypes)
                    {
                        foreach (var itemVal in item.Properties)
                        {
                            if (itemVal.Alias == typ.Alias)
                            {
                                var prop = new PropertieT(typ.Id, typ.Name, itemVal.Value);
                                listOfChildrenProperties.Add(prop);
                            }


                        }

                    }

                    var c = new ChildPropertieChild(item.Id, item.Name, listOfChildrenProperties);
                    listOfChildInChild.Add(c);
                }

                foreach (var v in child.Properties)
                {

                    var ch = new ChildPropertie(child.Id, child.Name, v.Value, listOfChildInChild);
                    listOfChildProperties.Add(ch);
                }

            }

            foreach (var propertieType in page.PropertyTypes)
            {

                foreach (var propValue in page.Properties)
                {
                    if (propValue.Alias == propertieType.Alias)
                    {
                        var properties = new PropertieT(propertieType.Id, propertieType.Name, propValue.Value);
                        listOfProperties.Add(properties);
                    }
                }
            }
            return new PageContent(page.Key, page.Name, listOfProperties, listOfChildProperties);

        }

        #endregion

        #region list of landsting

        public ILandstingPageContent GetLandstingById(Guid Key)
        {
            var page = ApplicationContext.Current.Services.ContentService.GetById(Key);

            List<PropertieT> listOfProperties = new List<PropertieT>();
            List<PropertieT> listOfChildProperties = new List<PropertieT>();
            List<ChildPropertieChild> listOfChildInChild = new List<ChildPropertieChild>();


            foreach (var propertieType in page.PropertyTypes)
            {
                foreach (var propValue in page.Properties)
                {
                    if (propValue.Alias == propertieType.Alias)
                    {
                        var properties = new PropertieT(propertieType.Id, propertieType.Name, propValue.Value);
                        listOfProperties.Add(properties);
                    }
                }

            }

            foreach (var child in page.Children())
            {
                foreach (var propertyType in page.PropertyTypes)
                {
                    foreach (var pChild in child.PropertyTypes)
                    {
                        foreach (var item in child.Properties)
                        {
                            if (item.Alias == pChild.Alias)
                            {
                                var properties = new PropertieT(pChild.Id, pChild.Name, item.Value);
                                listOfChildProperties.Add(properties);
                            }

                        }

                    }

                    var c = new ChildPropertieChild(child.Id, child.Name, listOfChildProperties);
                    listOfChildInChild.Add(c);
                }
            }


            return new LandstingPageContent(page.Key, page.Name, listOfProperties, listOfChildInChild);

        }

        #endregion

        #region list of properties

        public IPageContent GetById(Guid Key)
        {
            var page = ApplicationContext.Current.Services.ContentService.GetById(Key);

            List<PropertieT> listOfProperties = new List<PropertieT>();

            foreach (var propertieType in page.PropertyTypes)
            {
                foreach (var propValue in page.Properties)
                {
                    if (propValue.Alias == propertieType.Alias)
                    {
                        var properties = new PropertieT(propertieType.Id, propertieType.Name, propValue.Value);
                        listOfProperties.Add(properties);
                    }
                }
            }
            return new PageContent(page.Key, page.Name, listOfProperties, null);
        }

        #endregion

    }
}