using Scriban.Runtime;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.XA.Foundation.Abstractions;
using Sitecore.XA.Foundation.Scriban;
using Sitecore.XA.Foundation.Scriban.Pipelines.GenerateScribanContext;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Sitecore.XA.Foundation.ScribanExtensions.Pipeline.GenerateScribanContext
{
    public class AddLinkFieldRendererFunction : FieldRendererBase, IGenerateScribanContextProcessor
    {
        protected readonly IPageMode PageMode;

        public AddLinkFieldRendererFunction(IPageMode pageMode) => PageMode = pageMode;

        public void Process(GenerateScribanContextPipelineArgs args)
        {
            this.RenderingWebEditingParams = args.RenderingWebEditingParams;
            AddLinkFieldRendererFunction.RenderField renderField = new RenderField(this.RenderFieldImpl);
            args.GlobalScriptObject.Import("sc_link_prop", (Delegate)renderField);
        }

        public string RenderFieldImpl(Sitecore.Data.Items.Item item, object field, string propertyName, ScriptArray parameters = null)
        {
            NameValueCollection parametesList = new NameValueCollection();
            if(parameters != null)
            {
                foreach(object parameter in (ScriptArray<object>)parameters)
                {
                    if(parameter is ScriptArray scriptArray && scriptArray.Count > 1)
                    {
                        parametesList.Add(scriptArray[0].ToString(), scriptArray[1].ToString());
                    }
                }
            }
            string fieldName = null;
            switch (field)
            {
                case string _:
                    fieldName = field as string;
                    break;
                case ScriptArray _:
                    using(List<Object>.Enumerator enumerator = (field as ScriptArray).GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            if(enumerator.Current is string current)
                            {
                                fieldName = fieldName ?? current;
                                bool experienceEditorEditing = this.PageMode.IsExperienceEditorEditing;
                                Field field1 = item.Fields[current];
                                if(field1 != null)
                                {
                                    if (experienceEditorEditing)
                                    {
                                        fieldName = current;
                                        break;
                                    }
                                    if (!string.IsNullOrWhiteSpace(field1.GetValue(true)))
                                    {
                                        fieldName = current;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            LinkField linkField = item.Fields[fieldName];
            Assert.IsNotNull(linkField, nameof(linkField));
            switch (propertyName.ToLowerInvariant())
            {
                case "title":
                    return linkField.Title;
                case "text":
                    return linkField.Text;
                case "url":
                    return linkField.Url;
                case "anchor":
                    return !string.IsNullOrEmpty(linkField.Anchor) && linkField.Anchor != "#" ? $"#{linkField.Anchor}" : "#";
                default:
                    return linkField.Url;
            }
        }

        private delegate string RenderField(Sitecore.Data.Items.Item item, object field, string property, ScriptArray parameters = null);
    }
}