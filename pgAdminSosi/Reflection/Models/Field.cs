namespace pgAdminSosi.Reflection.Models
{
    public class Field
    {
        public Field(string name, Type type, object value)
        {
            this.FieldName = name;
            this.FieldType = type;
            this.Value = value;
        }

        public string FieldName;

        public Type FieldType;
        public object Value;
    }
}
