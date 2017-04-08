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

        #region list of landsting

        public IPageContent GetLandstingById(Guid Key)
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

    }
}