using System.Reflection;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Strategies
{
    public class DxGridComponentAttributesGenerationStrategy : GenerationStrategy
    {
        public override void Do(string property, int num)
        {
            Builder.AddAttribute(num, "FieldName", property);
            Builder.AddAttribute(num, "Width", "200");
        }
    }
}
