using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace TakeAndDo.Helpers
{
    public static class TableHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, object model, string listName, List<string> columns = null)
        {
            TagBuilder table = new TagBuilder("table");
            Type type = model.GetType();
            List<PropertyInfo> modelProperties = type.GetProperties().ToList();
            PropertyInfo property = modelProperties.FirstOrDefault(p => p.Name == listName);
            List<object> list = new List<object>();

            try
            {                                
                list = property.GetValue(model) as List<object>;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unable to build the table {listName} from {type}: {ex.Message}.");
                return MvcHtmlString.Empty;
            }

            foreach (PropertyInfo listProperty in list.GetType().GetProperties())
            {

            }

            //foreach (object obj in list)
            //{
            //    if (columns != null && columns.Find((x) => x== ))
            //        continue;

            //}

            return MvcHtmlString.Create(table.ToString());

        }
    }
}