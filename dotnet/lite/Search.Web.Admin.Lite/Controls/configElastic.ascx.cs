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
using Search.Web.Admin.Lite.Providers;
using Search.Web.Admin.Lite.Providers.Entities;

namespace Search.Web.Admin.Lite.Controls
{
    // public partial class configElastic : PortalModuleControl
    public partial class configElastic : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			/*
            CassandraProvider csPrd = new CassandraProvider("localhost");
            var types = csPrd.GetEngineTypes();
            foreach (var item in types)
            {
                Response.Write(string.Format("{0}, {1} <br/>", item.id, item.name));
            }
            Response.Write(string.Format("<br/>------------------------------------<br/>"));
            var newId = csPrd.AddNewEngine(new Providers.Entities.Engine() { name = "Test2" + DateTime.Now.ToString(), typeid = types[1].id });
            //var engs = csPrd.GetEngines();
            var eng = csPrd.GetEngine(newId);
            eng.name = DateTime.Now.ToString();
            csPrd.UpdateEngine(eng);
            var engs = csPrd.GetEngines();
            foreach (var item in engs)
            {
                Response.Write(string.Format("{0}, {1} <br/>", item.id, item.name));
            }
            Response.Write(string.Format("<br/>------------------------------------<br/>"));
            var newItmId = csPrd.AddNewEngineItem(new Providers.Entities.EngineItem() { name = "ItemTest1" + DateTime.Now.ToString(), engineid = newId });
            //var itms = csPrd.GetEngineItems();
            var engItm = csPrd.GetEngineItem(newItmId);
            engItm.name = DateTime.Now.ToString();
            csPrd.UpdateEngineItem(engItm);
            var itms = csPrd.GetEngineItems();
            foreach (var item in itms)
            {
                Response.Write(string.Format("{0}, {1} <br/>", item.id, item.name));
            }
            csPrd.DeleteEngineItem(engItm);
            csPrd.DeleteEngine(eng);
            return;
			*/
			
            //Load local node :
            var node = new Uri(txt_eUrl.Text);
            var settings = new ConnectionSettings(node);
            settings.DefaultIndex("my-app");
            var client = new ElasticClient(settings);

            //json modified and taken from https://github.com/Appleseed/search-web-admin/blob/master/schema/engine/json/engine.map.lite.json
            var json = @"{
                ""Engine"": {
      
                    ""IndexesSection"": {
                        ""add"": {
                            ""indexes"": {
                                ""add"": [
                      
                                    {
                                        ""_name"": """",
                                        ""_location"": """",
                                        ""_type"": """",
                                        ""_collectionName"": """"
                                    }
                                ]
                            },
                            ""_name"": """"
                        }
                    },
                     ""rssIndexServiceSection"": {
                        ""add"": {
                            ""Websites"": {
                                ""add"": {
                                    ""_name"": """",
                                    ""_siteMapUrl"": """",
                                    ""_indexPath"": """"
                                }
                            },
                            ""_name"": """"
                        }
                    },
                    ""WebsiteIndexServiceSection"": {
                        ""add"": {
                            ""Websites"": {
                                ""add"": 
                                    {
                                        ""_name"": """",
                                        ""_siteMapUrl"": """",
                                        ""_indexPath"": """"
                                    }
                    
                            },
                            ""_name"": """"
                        }
                    },
                    ""_environment"": """"
                }
            }";

            var jsonIndex = @"{
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

            var searchIndexAlias = client.Search<IndexAlias>(s => s
                .From(0)
                //.Sort(ss => ss.Ascending(p => p.Name))
                .Query(q => q.MatchAll())
            );

            var indexAliasResults = "";

            foreach (var hit in searchIndexAlias.Hits)
            {
                Console.WriteLine(hit.Source);
                indexAliasResults += "Name: " + hit.Source.Name + "  ";
                indexAliasResults += "Location: " + hit.Source.Location + "  ";
                indexAliasResults += "Type: " + hit.Source.Location + "  ";
                indexAliasResults += "Collection Name: " + hit.Source.CollectionName + "  " + "<br>";
            }

            lbl_aliasResults.Text = indexAliasResults;

            var searchResultsSiteMap = client.Search<SiteMap>(s => s
                .From(0)
                //.Sort(ss => ss.Ascending(p => p.Name))
                .Query(q => q.MatchAll())
            );

            var siteMapResults = "";

            foreach (var hit in searchResultsSiteMap.Hits)
            {
                Console.WriteLine(hit.Source);
                siteMapResults += "Name: " + hit.Source.Name + "  ";
                siteMapResults += "URL: " + hit.Source.Url + "  ";
                siteMapResults += "Index Path: " + hit.Source.IndexPath + "  " + "<br>";
            }

            lbl_siteMapResults.Text = siteMapResults;

            var searchResultsRss = client.Search<RssFeed>(s => s
                .From(0)
                //.Sort(ss => ss.Ascending(p => p.Name))
                .Query(q => q.MatchAll())
            );

            var rssResults = "";

            foreach (var hit in searchResultsRss.Hits)
            {
                Console.WriteLine(hit.Source);
                rssResults += "Name: " + hit.Source.Name + "  ";
                rssResults += "URL: " + hit.Source.Url + "  ";
                rssResults += "Index Path: " + hit.Source.IndexPath + "  " + "<br>";
            }

            lbl_rssResults.Text = rssResults;


        }

        public class IndexAlias
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public string Type { get; set; }
            public string CollectionName { get; set; }
        }

        public class SiteMap
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string IndexPath { get; set; }
        }

        public class RssFeed
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string IndexPath { get; set; }
        }

        protected void addIndexAlias(object sender, System.EventArgs e)
        {
            //Load local node :
            var node = new Uri(txt_eUrl.Text);
            var settings = new ConnectionSettings(
                node
            );
            settings.DefaultIndex("my-app");
            var client = new ElasticClient(settings);

            var indexAlias = new IndexAlias
            {
                Name = txt_aliasName.Text,
                Location = txt_aliasLocation.Text,
                Type = txt_aliasType.Text,
                CollectionName = txt_aliasCollection.Text
            };

            var index = client.Index(indexAlias);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void addSiteMap(object sender, System.EventArgs e)
        {
            //Load local node :
            var node = new Uri(txt_eUrl.Text);
            var settings = new ConnectionSettings(
                node
            );
            settings.DefaultIndex("my-app");
            var client = new ElasticClient(settings);

            var siteMap = new SiteMap
            {
                Name = txt_siteMapName.Text,
                Url = txt_siteMapUrl.Text,
                IndexPath = txt_siteMapIndexPath.Text
            };

            var index = client.Index(siteMap);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void addRssFeed(object sender, System.EventArgs e)
        {
            //Load local node :
            var node = new Uri(txt_eUrl.Text);
            var settings = new ConnectionSettings(
                node
            );
            settings.DefaultIndex("my-app");
            var client = new ElasticClient(settings);

            var rssFeed = new RssFeed
            {
                Name = txt_rssName.Text,
                Url = txt_rssUrl.Text,
                IndexPath = txt_rssIndexPath.Text
            };

            var index = client.Index(rssFeed);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}