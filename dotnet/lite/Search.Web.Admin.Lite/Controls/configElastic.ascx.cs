using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Appleseed
using Appleseed.Framework;
using Appleseed.Framework.Settings;
using Appleseed.Framework.Content.Data;
using Appleseed.Framework.Data;
using Appleseed.Framework.DataTypes;
using Appleseed.Framework.Web.UI.WebControls;
using Appleseed.Framework.Security;

//Nest
using Nest;

namespace Search.Web.Admin.Lite.Controls
{
    // public partial class configElastic : PortalModuleControl
    public partial class configElastic : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            //Load local node :
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            settings.DefaultIndex("my-app");
            var client = new ElasticClient(settings);
            client.DeleteIndex("my-app");
            var searchResults = client.Search<SiteMap>();

            test.Text = searchResults.ToString();

            //json modified and taken from https://github.com/Appleseed/search-web-admin/blob/master/schema/engine/json/engine.map.lite.json
            var json = @"{
                ""Engine"": {
      
                    ""IndexesSection"": {
                        ""add"": {
                            ""indexes"": {
                                ""add"": [
                      
                                    {
                                        ""_name"": ""indexalias1"",
                                        ""_location"": ""http://localhost:8983/solr/appleseed-public"",
                                        ""_type"": ""Solr"",
                                        ""_collectionName"": ""appleseed-public""
                                    }
                                ]
                            },
                            ""_name"": ""My Index""
                        }
                    },
                     ""rssIndexServiceSection"": {
                        ""add"": {
                            ""Websites"": {
                                ""add"": {
                                    ""_name"": ""Featured"",
                                    ""_siteMapUrl"": """",
                                    ""_indexPath"": ""{indexalias1}""
                                }
                            },
                            ""_name"": ""My RSS Feeds""
                        }
                    },
                    ""WebsiteIndexServiceSection"": {
                        ""add"": {
                            ""Websites"": {
                                ""add"": 
                                    {
                                        ""_name"": ""Anant Corporation"",
                                        ""_siteMapUrl"": ""http://anant.us/sitemap.axd"",
                                        ""_indexPath"": ""{indexalias1}""
                                    }
                    
                            },
                            ""_name"": ""My Sitemaps""
                        }
                    },
                    ""_environment"": ""Production""
                }
            }";

            //client.CreateIndex(json);
            var indexResponse = client.LowLevel.Index<string>("my-app", "type-name", json);

            //if (!indexResponse.Success)
            //    Console.WriteLine(indexResponse.DebugInformation);

            /*

            var searchResultsSiteMap = client.Search<SiteMap>(s => s
                .AllIndices()
            );
            //test.Text = searchResultsSiteMap.Documents;

            var searchResultsRss = client.Search<RssFeed>(s => s
                .AllIndices()
            );
            */
        }

        public class SiteMap
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class RssFeed
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
        }

        protected void addSiteMap()
        {
            //Load local node :
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(
                node
            //defaultIndex: "my-application"
            );
            var client = new ElasticClient(settings);

            var siteMap = new SiteMap
            {
                Id = "1",
                Name = txt_siteMapName.Text,
                Url = txt_siteMapUrl.Text
            };

            var index = client.Index(siteMap);
        }

        protected void addRssFeed()
        {
            //Load local node :
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(
                node
            //defaultIndex: "my-application"
            );
            var client = new ElasticClient(settings);

            var rssFeed = new RssFeed
            {
                Id = "1",
                Name = txt_rssName.Text,
                Url = txt_rssUrl.Text
            };

            var index = client.Index(rssFeed);
        }
    }
}