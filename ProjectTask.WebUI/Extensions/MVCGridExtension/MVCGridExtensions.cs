using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using NonFactors.Mvc.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectTask.WebUI.Extensions.MVCGridExtension
{
    public static class MvcGridExtensions
    {
        public static IHtmlGrid<T> ApplyDefaults<T>(this IHtmlGrid<T> grid)
        {
            return grid
                .Pageable(pager => { pager.RowsPerPage = 16; })
                .Empty("Нет данных для отображения")
                .AppendCss("table-hover")
                .Filterable()
                .Sortable();
        }

        public static IHtmlGrid<T> ApplyDefaultsWithoutFilter<T>(this IHtmlGrid<T> grid)
        {
            return grid
                .Pageable(pager => { pager.RowsPerPage = 16; })
                .Empty("Нет данных для отображения")
                .AppendCss("table-hover")
                .Sortable();
        }

        public static IGridColumn<T, IHtmlContent> AddAction<T>(this IGridColumnsOf<T> columns, Expression<Func<object, string>> href, string renderName)
        {
            return columns.Add(model => GenerateLink(columns.Grid.ViewContext, href.Compile().Invoke(1), renderName));
        }

        private static IHtmlContent GenerateLink(ViewContext context, string href, string renderName)
        {
            TagBuilder link = new TagBuilder("a");

            link.Attributes["href"] = href;

            TagBuilder icon = new TagBuilder("span");

            icon.InnerHtml.Append(renderName);

            link.InnerHtml.AppendHtml(icon);

            return link;
        }

    }
}
