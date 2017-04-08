// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UmderlakareUmbCms.DependencyResolution {
    using Business.Services;
    using Controllers;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System.Web.Http;
    using Umbraco.Core;
    using Umbraco.Web;
    using UmderlakareUmbCms.Business.Services.Interfaces;

    public class DefaultRegistry : Registry {
		#region Constructors and Destructors

		public DefaultRegistry() {
			Scan(
				scan => {
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
					//scan.With(new ControllerConvention());
				});
			//For<IExample>().Use<Example>();
			For<IMembersService>().Use<MemberService>();
			For<ICategorysService>().Use<CategoryService>();
			For<ITopicsService>().Use<TopicService>();
			For<IPostsService>().Use<PostService>();
            For<IPageContentService>().Use<PageContentService>();
            //For<UmbracoContext>().Use(UmbracoContext.Current);
            //For<ApplicationContext>().Use(ApplicationContext.Current);


        }

		#endregion
	}
}