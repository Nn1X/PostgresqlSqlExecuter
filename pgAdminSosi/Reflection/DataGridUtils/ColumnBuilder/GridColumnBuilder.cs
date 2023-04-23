using DevExpress.Blazor;
using pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Attributes;
using pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Strategies;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using pgAdminSosi.Reflection.Models;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder
{
    /// <summary>
    /// Класс генерации колонок <see cref="DxGrid"/> на основе стратегий
    /// </summary>
    public class GridColumnBuilder
    {
        /// <summary>
        ///  Генерирует колонки <see cref="DxGrid"/> на основе стратегий <see cref="IGenetationStrategy"/>
        /// </summary>
        /// <param name="model">Объект модели на основе которой строятся колонки</param>
        /// <param name="strategies">Стратегии генерации</param>
        /// <param name="excludeColumns">Колонки, которые исключены из генерации</param>
        /// <returns><see cref="RenderFragment"/> сгенерированных колонок</returns>
        public static RenderFragment BuildColumns(DynamicClass model, IGenetationStrategy[] strategies, List<string> excludeColumns = null)
        {
            List<string> properties = model.GetFieldNames().ToList();

            RenderFragment columns = f =>
            {
                foreach (var strategy in strategies)
                    strategy.Builder = f;

                for(var i = 0; i < properties.Count; i++)
                {
                    f.OpenComponent(i, typeof(DxGridDataColumn));

                    foreach (var strategy in strategies)
                        strategy.Do(properties[i], i);

                    f.CloseComponent();
                }
            };

            return columns;
        }
    }
}
