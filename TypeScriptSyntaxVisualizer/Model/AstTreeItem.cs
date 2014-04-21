using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScriptSyntaxVisualizer.Model
{
    public class AstTreeItem
    {
        private JToken json;

        public AstTreeItem(JToken json)
        {
            this.json = json;
        }

        private List<AstTreeItem> members;
        public List<AstTreeItem> Members
        {
            get
            {
                if (members == null)
                {
                    var tmp = new List<AstTreeItem>();
                    foreach(var val in this.json.Values().Where((token)=>
                    {
                        return token is JArray || token is JObject;
                    }))
                    {
                        if(val is JArray)
                        {
                            var array = (JArray)val;
                            for(var i = 0; i< array.Count; i++)
                            {
                                tmp.Add(new AstTreeItem(array[i]));
                            }
                        }
                        else if (val is JObject)
                        {
                            tmp.Add(new AstTreeItem(val));
                        }
                    }
                    members = tmp;
                }
                return members;
            }
        }

        private Dictionary<string, string> properties;
        public Dictionary<string, string> Properties
        {
            get
            {
                if(properties == null)
                {
                    var tmp = new Dictionary<string, string>();
                    foreach(var item in json.OfType<JProperty>().Where((token) =>
                    {
                        return !(token.Value is JArray || token.Value is JObject);
                    }))
                    {
                        tmp.Add(item.Name, item.Value.ToString());
                    }
                    properties = tmp;
                }
                return properties;
            }
        }

        public string Title
        {
            get
            {
                return string.Format("{0} [{1}..{2}]", json["kind"], json["start"], json["end"]);
            }
        }
    }
}
